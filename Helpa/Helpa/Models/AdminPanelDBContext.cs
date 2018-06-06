using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Helpa.Models
{
    public class AdminPanelDBContext :DbContext
    {
        public DbSet<Setting> setting { get; set; }
    }
}