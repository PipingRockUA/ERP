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
    
    public partial class PackagingUnit
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PackagingUnit()
        {
            this.BottlesPerCases = new HashSet<BottlesPerCase>();
            this.FinishedGoods = new HashSet<FinishedGood>();
        }
    
        public int PackagingUnitId { get; set; }
        public string PackagingUnitItemKey { get; set; }
        public string PackagingUnitDesc { get; set; }
        public int ItemTypeId { get; set; }
        public int ItemSubTypeId { get; set; }
        public int QuantityPerLayer { get; set; }
        public decimal Height { get; set; }
        public int LayersHigh { get; set; }
        public int LayersMed { get; set; }
        public int LayersLow { get; set; }
        public int NumberBoxesHigh { get; set; }
        public int NumberBoxesMed { get; set; }
        public int NumberBoxesLow { get; set; }
        public System.DateTime PackagingUnitAddedDate { get; set; }
        public System.DateTime PackagingUnitChangedDate { get; set; }
        public Nullable<System.DateTime> PackagingUnitDeletedDate { get; set; }
        public int PackagingUnitModifiedById { get; set; }
        public bool isDeleted { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BottlesPerCase> BottlesPerCases { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FinishedGood> FinishedGoods { get; set; }
        public virtual ItemSubType ItemSubType { get; set; }
    }
}
