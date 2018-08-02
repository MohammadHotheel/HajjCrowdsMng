//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HCM.WebApp.DAL.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class ServiceInformation
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ServiceInformation()
        {
            this.ServiceDetails = new HashSet<ServiceDetail>();
        }
    
        public int Id { get; set; }
        public Nullable<int> SaudiStudentAssociationId { get; set; }
        public Nullable<int> ServiceCategoryId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Section { get; set; }
        public string Address { get; set; }
        public string Longitude { get; set; }
        public string Latitude { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public string LastUpdatedBy { get; set; }
        public Nullable<System.DateTime> LastUpdatedDate { get; set; }
        public Nullable<bool> DeletedFlag { get; set; }
    
        public virtual SaudiStudentAssociation SaudiStudentAssociation { get; set; }
        public virtual ServiceCategory ServiceCategory { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ServiceDetail> ServiceDetails { get; set; }
    }
}