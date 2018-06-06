using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Helpa.Models;
using System.Data;

namespace Helpa.Views.ViewModel.Home
{
    public class SettingViewModel
    {
        public List<Setting> GetAllSetting()
        {
            AdminPanelDBContext db = new AdminPanelDBContext();
            return db.setting.ToList();
        }

        internal Setting GetSettingDetailsById(int id)
        {
            AdminPanelDBContext db = new Models.AdminPanelDBContext();
            return db.setting.Find(id);
        }

        internal void UpdateSettingDetails(Setting setting)
        {
            AdminPanelDBContext db = new Models.AdminPanelDBContext();
            //db.Entry(setting).State = System.Data.EntityState.Modified;
            var v =  db.setting.Where(x => x.Id == setting.Id).FirstOrDefault();
            db.SaveChanges();
           
        }
    }
}