//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PipingRockERP
{
    using System;
    using System.Collections.Generic;
    
    public partial class Bulk_Quarantine
    {
        public int Bulk_QuarantineId { get; set; }
        public int BulkId { get; set; }
        public int QuarantineId { get; set; }
        public System.DateTime Bulk_QuarantineAddedDate { get; set; }
        public System.DateTime Bulk_QuarantineChangedDate { get; set; }
        public Nullable<System.DateTime> Bulk_QuarantineDeletedDate { get; set; }
        public int Bulk_QuarantineModifiedById { get; set; }
        public bool isDeleted { get; set; }
    
        public virtual Bulk Bulk { get; set; }
        public virtual Quarantine Quarantine { get; set; }
    }
}