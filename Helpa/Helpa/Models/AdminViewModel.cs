using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Helpa.Models
{
    public class Admin
    {
        public int id { get; set; }
        public bool RowStatus { get; set; }
        public bool GenderId { get; set; }
        public string ProfileImage { get; set; }
        public string Description { get; set; }
        public string Email { get; set; }
        public string EmailConfirmed { get; set; }


    }
}