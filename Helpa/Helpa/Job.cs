//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Helpa
{
    using System;
    using System.Collections.Generic;
    
    public partial class Job
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Job()
        {
            this.JobServices = new HashSet<JobService>();
            this.Recievers = new HashSet<Reciever>();
        }
    
        public int JobId { get; set; }
        public int CreatedUserId { get; set; }
        public string JobTiltle { get; set; }
        public string JobDescription { get; set; }
        public string JobType { get; set; }
        public string HelperType { get; set; }
        public int LocationId { get; set; }
        public int TimeId { get; set; }
        public int PriceId { get; set; }
        public bool Status { get; set; }
        public string RowStatus { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public System.DateTime ExpiryDate { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
    
        public virtual JobLocation JobLocation { get; set; }
        public virtual JobPrice JobPrice { get; set; }
        public virtual JobTime JobTime { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<JobService> JobServices { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Reciever> Recievers { get; set; }
    }
}
