using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Helpa.Models
{
    public class ManageUSearch
    {
        public int id { get; set; }
        public bool RowStatus { get; set; }
        public  bool GenderId { get; set; }
        public string ProfileImage { get; set; }
        public string Description { get; set; }
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }
        public string SecurityStamp { get; set; }
        public string PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public DateTime LockoutEndDateUtc { get; set; }
        public bool LockoutEnabled { get; set; }
        public int AccessFailedCount { get; set; }
        public string UserName { get; set; }    
        public int LocationId { get; set; }
        
    }
    public class Test

    {
        public int Id { get; set; }
        public DateTime LoginTime { get; set; }
        public bool RowStatus { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public int UserLogId { get; set; }
        public string ButtonText { get; set; }
        public string ButtonColor { get; set; }
        public string DeviceName { get; set; }
        public string UserRole { get; set; }
        public int DeviceId { get; set; }
    }
}