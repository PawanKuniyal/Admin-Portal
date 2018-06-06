using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Linq.Dynamic;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Reflection;
using System.IO;
using System.Data.Entity;
using Helpa.Models;

namespace Helpa.Controllers
{
    public class ManageUsersController : Controller
    {
        //[Authorize(Roles = "Admin")]
        HelpaEntity he = new HelpaEntity();
        // GET: ManageUsers
        public ActionResult Index(int page = 1, string sort = "FirstName", string sortdir = "asc", string search = "")
        {
            int pagesize = 10;
            int totalRecord = 0;
            if (page < 1) page = 1;
            int skip = (page * pagesize) - pagesize;
            var data = GetAspNetUser(search, sort, sortdir, skip, pagesize, out totalRecord);
            foreach (var dd in data)
            {
                if (dd.RowStatus == true)
                {
                    dd.ButtonText = "Active";
                    dd.ButtonColor = "Blue";
                }
                else
                {
                    dd.ButtonText = "Deactive";
                    dd.ButtonColor = "Red";
                }
            }

            ViewBag.TotalRows = totalRecord;
            ViewBag.search = search;
            return View(data);
        }
        public List<Test> GetAspNetUser(string search, string sort, string sortdir, int skip, int pagesize, out int totalRecord)
        {
            using (HelpaEntity dc = new Helpa.HelpaEntity())
            {
                var v = (from user in dc.AspNetUsers.ToList()
                         join userLog in dc.UserLogs.ToList()
on user.Id equals userLog.UserId
                         select new Test
                         {
                             Id = user.Id,
                             RowStatus = user.RowStatus,
                             UserName = user.UserName,
                             Email = user.Email,
                             UserLogId = userLog.UserLogId,
                             DeviceName = userLog.DeviceId,
                             LoginTime = userLog.CreatedDate,
                             UserRole = userLog.AspNetUser.AspNetRoles.Select(x => x.Name).ToString()
                         }).Where(x => x.UserName.Contains(search) || x.Email.Contains(search)).OrderBy(x => x.UserName).ToList();

                string Email = Session["Email"].ToString();
                v = v.Where(x => x.Email != Email).ToList();
                v = v.Skip(skip).Take(pagesize).ToList();
                var k = v.OrderByDescending(x => x.LoginTime).GroupBy(x => x.Email).ToList();
                v = new List<Test>();
                foreach (var item in k)
                {
                    v.Add(item.FirstOrDefault());

                }
                totalRecord = v.Count();
              
                return v;
            }
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            AspNetUser Obj = new AspNetUser();
            Obj = he.AspNetUsers.Find(id);
            return View(Obj);
        }

        [HttpPost]
        public ActionResult Save(AspNetUser model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    he.AspNetUsers.Add(model);
                    he.SaveChanges();
                }
                catch (Exception ex)
                {
                    TempData["Failure"] = ex;
                    throw;
                }
            }
            else
            {
                TempData["Failure"] = "Record Not Saved";
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Export()
        {

            var data = (from a in he.AspNetUsers
                        select new 
                        {
                            UserName = a.UserName,
                            Email = a.Email,
                            PhoneNumber = a.PhoneNumber,
                            description =a.Description
                        }).ToList();

            DataTable dt = ToDataTable(data);
            CreateCSVFile(dt, "d:\\" + "Register" + ".csv" + "");
            //da.Fill(dt);
            string csv = string.Empty;

            foreach (DataColumn column in dt.Columns)
            {
                //Add the Header row for CSV file.
                csv += column.ColumnName + ',';
            }

            //Add new line.
            csv += "\r\n";

            foreach (DataRow row in dt.Rows)
            {
                foreach (DataColumn column in dt.Columns)
                {
                    //Add the Data rows.
                    csv += row[column.ColumnName].ToString().Replace(",", ";") + ',';
                }

                //Add new line.
                csv += "\r\n";
            }

            //Download the CSV file.
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment;filename=SqlExport.csv");
            Response.Charset = "";
            Response.ContentType = "application/text";
            Response.Output.Write(csv);
            Response.Flush();
            Response.End();


            return View();
        }
        public DataTable ToDataTable<T>(List<T> items)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);
            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in Props)
            {
                //Setting column names as Property names  
                dataTable.Columns.Add(prop.Name);
            }
            foreach (T item in items)
            {
                var values = new object[Props.Length];
                for (int i = 0; i < Props.Length; i++)
                {

                    values[i] = Props[i].GetValue(item, null);
                }
                dataTable.Rows.Add(values);
            }
            return dataTable;
        }
        public void CreateCSVFile(DataTable dt, string strFilePath)
        {
            StreamWriter sw = new StreamWriter(strFilePath, false);
            int iColCount = dt.Columns.Count;
            for (int i = 0; i < iColCount; i++)
            {
                sw.Write(dt.Columns[i]);
                if (i < iColCount - 1)
                {
                    sw.Write(",");
                }
            }
            sw.Write(sw.NewLine);
            // Now write all the rows.
            foreach (DataRow dr in dt.Rows)
            {
                for (int i = 0; i < iColCount; i++)
                {
                    if (!Convert.IsDBNull(dr[i]))
                    {
                        sw.Write(dr[i].ToString());
                    }
                    if (i < iColCount - 1)
                    {
                        sw.Write(",");
                    }
                }
                sw.Write(sw.NewLine);
            }
            sw.Close();
        }


        [HttpGet]
        public ActionResult ViewProfile(int id)
        {
            AspNetUser Obj = new AspNetUser();
            Obj = he.AspNetUsers.Find(id);

            return View(Obj);
        }
        [HttpGet]
        public ActionResult Device(int id)
        {
            UserLog userlogo = new UserLog();
            userlogo = he.UserLogs.Find(id);

            return View(userlogo);
        }
        [HttpGet]
        public ActionResult Status(int id)
        {
            AspNetUser Obj = new AspNetUser();

            Obj = he.AspNetUsers.Find(id);
            if (Obj.RowStatus == false)
            {
                Obj.RowStatus = true;
            }
            else
            {
                Obj.RowStatus = false;
            }

            he.AspNetUsers.Attach(Obj);
            he.Entry(Obj).State = EntityState.Modified;
            he.SaveChanges();

            return RedirectToAction("Index", "ManageUsers");
        }
    }
    //public class Test

    //{
    //    public int Id { get; set; }

    //    public bool RowStatus { get; set; }
    //    public string UserName { get; set; }
    //    public string Email { get; set; }
    //    public int UserLogId { get; set; }
    //    public string ButtonText { get; set; }
    //    public string ButtonColor { get; set; }
    //}
}
