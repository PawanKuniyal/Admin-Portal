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
    
    public partial class JobLocation
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public JobLocation()
        {
            this.Jobs = new HashSet<Job>();
        }
    
        public int JobLocationId { get; set; }
        public string JobLocationName { get; set; }
        public System.Data.Entity.Spatial.DbGeography JobLocationGeography { get; set; }
        public string RowStatus { get; set; }
        public System.DateTime CreatedDate { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Job> Jobs { get; set; }
    }
}
