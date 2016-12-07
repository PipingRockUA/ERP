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
    
    public partial class Bulk
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Bulk()
        {
            this.FinishedGoods = new HashSet<FinishedGood>();
        }
    
        public int BulkId { get; set; }
        public string ItemKey { get; set; }
        public string BulkDescriptionShort { get; set; }
        public string BulkDescriptionMedium { get; set; }
        public string BulkDescriptionLong { get; set; }
        public int ItemStatusId { get; set; }
        public int ItemTypeId { get; set; }
        public int PurchaseUnitOfMeasureId { get; set; }
        public int StockUnitOfMeasureId { get; set; }
        public int ProductionUnitOfMeasureId { get; set; }
        public int SaleUnitOfMeasureId { get; set; }
        public int ItemFormId { get; set; }
        public bool ReceivingBoxLabelsRequired { get; set; }
        public int StorageConditionId { get; set; }
        public int QcTestId { get; set; }
        public int ExpirationMonths { get; set; }
        public int RetestingMonths { get; set; }
        public decimal PctOfLifeForRetesting { get; set; }
        public int QuarantineTypeId { get; set; }
        public System.DateTime BulkAddedDate { get; set; }
        public System.DateTime BulkChangedDate { get; set; }
        public Nullable<System.DateTime> BulkDeletedDate { get; set; }
        public int BulkModifiedById { get; set; }
        public bool isDeleted { get; set; }
    
        public virtual ItemForm ItemForm { get; set; }
        public virtual ItemStatu ItemStatu { get; set; }
        public virtual ItemType ItemType { get; set; }
        public virtual QcTest QcTest { get; set; }
        public virtual QuarantineType QuarantineType { get; set; }
        public virtual StorageCondition StorageCondition { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FinishedGood> FinishedGoods { get; set; }
    }
}
