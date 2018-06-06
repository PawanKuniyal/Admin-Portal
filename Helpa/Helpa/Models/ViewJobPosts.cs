using Helpa;
using System;
using System.Collections.Generic;
using System.IdentityModel;
using System.Linq;
using System.Web;

namespace Helpa.Models
{
    public class ViewJobPosts
    {
        //public int JobId { get; set; }
        //public int CreatedUserId { get; set; }
        //public string JobTiltle { get; set; }
        //public string JobDescription { get; set; }
        //public char JobType { get; set; }
        //public char HelperType { get; set; }
        //public int LocationId { get; set; }
        //public int TimeId { get; set; }
        //public int PriceId { get; set; }
        //public bool Status { get; set; }
        //public char RowStatus { get; set; }
        //public DateTime CreatedDate { get; set; }
        //public DateTime ExpiryDate { get; set; }
        //public DateTime UpdatedDate { get; set; }

        public IEnumerable<Location> location { get; set; }       
        public IEnumerable<JobPrice> jobprice { get; set; }
        public IEnumerable<JobTime> jobtime { get; set; }
        //public IEnumerable<JobServices> jobservice { get; set; }
        public IEnumerable<JobScope> jobscope { get; set; }
        public IEnumerable<Scope> scoper { get; set; }
        public IEnumerable<Job> job { get; set; }
    }
}