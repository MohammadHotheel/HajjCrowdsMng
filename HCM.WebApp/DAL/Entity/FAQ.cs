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
    
    public partial class FAQ
    {
        public int Id { get; set; }
        public Nullable<int> SaudiStudentAssociationId { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public string LastUpdatedBy { get; set; }
        public Nullable<System.DateTime> LastUpdatedDate { get; set; }
        public Nullable<bool> DeletedFlag { get; set; }
    
        public virtual SaudiStudentAssociation SaudiStudentAssociation { get; set; }
    }
}
