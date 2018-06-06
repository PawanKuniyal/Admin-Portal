using System.Web.Mvc;
using RestSharp;
using Newtonsoft.Json;
using Helpa.Models;
using Helpa.ViewModel.ReturnModel;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using Microsoft.AspNet.Identity;
using System.Web;
using System.Data.Entity;
using System.Web.Security;

namespace Helpa.Controllers
{
    [Authorize(Roles ="ADMIN")]
    public class AccountController : Controller
    {
        HelpaEntity he = new HelpaEntity();
        public AccountController()
        {
        }

        //
        // GET: /Account/Login
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)

        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        //[ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            //string email = "admin";
            //if (email == model.Email)
            //{
            //    Session["UserName"] = email;
            //    return RedirectToAction("About", "Home");
            //}

            string requestBody = "grant_type=password" + "&username=" + model.Email + "&password=" + model.Password + "&deviceId=WindowsOS";
          
            var client = new RestClient("http://192.168.2.254:127/Token");
            var request = new RestRequest(Method.POST);
            request.AddHeader("content-type", "application/x-www-form-urlencoded");
            request.AddParameter("application/x-www-form-urlencoded", requestBody, ParameterType.RequestBody);

            var response = client.Execute(request);
            string data = response.Content;
            if (string.IsNullOrEmpty(data) || data=="")
            {

                TempData["Mgs"] =  "Server Not Responding";
                return RedirectToAction("Login");
            }
                if (data.Contains("incorrect") )
            {
                TempData["Mgs"] = "UserName or Password Incorrect";
                return RedirectToAction("Login");
            }
           // if(data=={ "error":"invalid_grant","error_description":"The user name or password is incorrect."})

            var json = JsonConvert.DeserializeObject<TokenAccess>(data);

            SignInUser(json.UserName, false);
            Session["UserName"] = json.UserName;
            Session["Email"] = model.Email;


            return RedirectToAction("About", "Home");
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        [AllowAnonymous]
        public ActionResult LogOff()
        {
            bool check = false;
            try
            {
                
                // Setting.    
                var ctx = Request.GetOwinContext();
                var authenticationManager = ctx.Authentication;
                // Sign Out.    
                authenticationManager.SignOut();
                Session.Remove("UserName");
                check = true;
            }
           
            catch (Exception ex)
            {
                // Info    
                throw ex;
            }
            // Info.    

            return Json(check, JsonRequestBehavior.AllowGet);
        }

        private void SignInUser(string userName, bool isPersistent)
        {
            var claims = new List<Claim>();
            try
            {
                claims.Add(new Claim(ClaimTypes.Name, userName));
                var claimIdentity = new ClaimsIdentity(claims, DefaultAuthenticationTypes.ApplicationCookie);
                var ctx = Request.GetOwinContext();
                var autheticationManager = ctx.Authentication;
                autheticationManager.SignIn(new Microsoft.Owin.Security.AuthenticationProperties()
                {
                    IsPersistent = isPersistent
                }, claimIdentity);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        //public ActionResult Login()
        //{
        //    FormsAuthentication.SignOut();
        //    Session.Abandon(); // it will clear the session at the end of request
        //    return RedirectToAction("index", "Account");
        //}
    }
}