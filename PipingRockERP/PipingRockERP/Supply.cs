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
    
    public partial class Supply
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Supply()
        {
            this.FinishedGoods = new HashSet<FinishedGood>();
        }
    
        public int SuppliesId { get; set; }
        public string SuppliesItemKey { get; set; }
        public string SuppliesDesc { get; set; }
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
        public System.DateTime SuppliesAddedDate { get; set; }
        public System.DateTime SuppliesChangedDate { get; set; }
        public Nullable<System.DateTime> SuppliesDeletedDate { get; set; }
        public int SuppliesModifiedById { get; set; }
        public bool isDeleted { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FinishedGood> FinishedGoods { get; set; }
        public virtual ItemSubType ItemSubType { get; set; }
    }
}