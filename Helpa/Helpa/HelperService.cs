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
    
    public partial class HelperService
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HelperService()
        {
            this.HelperServiceScopes = new HashSet<HelperServiceScope>();
        }
    
        public int HelperServiceId { get; set; }
        public int ServiceId { get; set; }
        public int HelperId { get; set; }
        public Nullable<int> LocationId { get; set; }
        public int LocationType { get; set; }
        public bool HourPrice { get; set; }
        public Nullable<decimal> MinHourPrice { get; set; }
        public Nullable<decimal> MaxHourPrice { get; set; }
        public bool DayPrice { get; set; }
        public Nullable<decimal> MinDayPrice { get; set; }
        public Nullable<decimal> MaxDayPrice { get; set; }
        public bool MonthlyPrice { get; set; }
        public Nullable<decimal> MinMonthPrice { get; set; }
        public Nullable<decimal> MaxMonthPrice { get; set; }
        public bool Status { get; set; }
        public string RowStatus { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
    
        public virtual Location1 Location { get; set; }
        public virtual Helper Helper { get; set; }
        public virtual Service Service { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HelperServiceScope> HelperServiceScopes { get; set; }
    }
}
