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
    
    public partial class FinishedGood
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public FinishedGood()
        {
            this.FinishedGood_QcTest = new HashSet<FinishedGood_QcTest>();
            this.FinishedGood_Quarantine = new HashSet<FinishedGood_Quarantine>();
        }
    
        public int FinishedGoodId { get; set; }
        public string FinishedGoodItemKey { get; set; }
        public string FinishedGoodDescriptionShort { get; set; }
        public string FinishedGoodDescriptionMedium { get; set; }
        public string FinishedGoodDescriptionLong { get; set; }
        public string FinishedGoodSizePrint { get; set; }
        public decimal FinishedGoodSizeNumeric { get; set; }
        public int FinishedGoodSizeUOMId { get; set; }
        public int ItemStatusId { get; set; }
        public int ItemTypeId { get; set; }
        public int BrandId { get; set; }
        public int BulkId { get; set; }
        public int ReportSortId { get; set; }
        public int PackagingUnitId { get; set; }
        public int PackagingUOMId { get; set; }
        public int BottleId { get; set; }
        public decimal ChainPrice { get; set; }
        public decimal SRP { get; set; }
        public decimal MasterCasePrice { get; set; }
        public string EachUPC { get; set; }
        public string MasterCaseUPC { get; set; }
        public string InnerUPC { get; set; }
        public decimal EachHeightInches { get; set; }
        public decimal EachWidthInches { get; set; }
        public decimal EachDepthInches { get; set; }
        public Nullable<decimal> EachCubicInches { get; set; }
        public Nullable<decimal> EachHeightCm { get; set; }
        public Nullable<decimal> EachWidthCm { get; set; }
        public Nullable<decimal> EachDepthCm { get; set; }
        public Nullable<decimal> EachCubicCm { get; set; }
        public decimal EachWeightOz { get; set; }
        public Nullable<decimal> EachWeightGrams { get; set; }
        public string FinishedGoodMakeBuy { get; set; }
        public int VendorId { get; set; }
        public bool isTaxableNYS { get; set; }
        public bool isTaxableCanada { get; set; }
        public bool ReceivingBoxLabelsRequired { get; set; }
        public int StorageConditionId { get; set; }
        public int QcTestId { get; set; }
        public int ExpirationMonths { get; set; }
        public decimal PctOfLifeForRetesting { get; set; }
        public bool areMultipleBinsRequired { get; set; }
        public bool isLotTracked { get; set; }
        public string PalletHeight { get; set; }
        public decimal LastCost { get; set; }
        public decimal StandardCost { get; set; }
        public decimal AverageCost { get; set; }
        public decimal FuturePoCost { get; set; }
        public int MonthlyUsage { get; set; }
        public int GLCodeRevenue { get; set; }
        public int GLCodeCost { get; set; }
        public System.DateTime FinishedGoodAddedDate { get; set; }
        public System.DateTime FinishedGoodChangedDate { get; set; }
        public Nullable<System.DateTime> FinishedGoodDeletedDate { get; set; }
        public int FinishedGoodModifiedById { get; set; }
        public bool isDeleted { get; set; }
    
        public virtual Bottle2 Bottle2 { get; set; }
        public virtual Brand Brand { get; set; }
        public virtual Bulk Bulk { get; set; }
        public virtual ItemStatu ItemStatu { get; set; }
        public virtual PackagingUnit PackagingUnit { get; set; }
        public virtual PackagingUOM PackagingUOM { get; set; }
        public virtual QcTest QcTest { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FinishedGood_QcTest> FinishedGood_QcTest { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FinishedGood_Quarantine> FinishedGood_Quarantine { get; set; }
    }
}
