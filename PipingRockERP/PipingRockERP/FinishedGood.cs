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
        public int FinishedGoodId { get; set; }
        public string FinishedGoodItemKey { get; set; }
        public string FinishedGoodDescriptionShort { get; set; }
        public string FinishedGoodDescriptionMedium { get; set; }
        public string FinishedGoodDescriptionLong { get; set; }
        public int ItemStatusId { get; set; }
        public int ItemFormId { get; set; }
        public int ItemTypeId { get; set; }
        public int BrandId { get; set; }
        public int BulkId { get; set; }
        public int ReportSortId { get; set; }
        public int PackagingLevelId { get; set; }
        public bool IsPurchasable { get; set; }
        public int BottleId { get; set; }
        public Nullable<decimal> ChainPrice { get; set; }
        public Nullable<decimal> SRP { get; set; }
        public Nullable<decimal> MasterCaseCost { get; set; }
        public string EachUPC { get; set; }
        public string MasterCaseUPC { get; set; }
        public string InnerUPC { get; set; }
        public Nullable<decimal> EachHeightInches { get; set; }
        public Nullable<decimal> EachWidthInches { get; set; }
        public Nullable<decimal> EachDepthInches { get; set; }
        public Nullable<decimal> EachWeightOz { get; set; }
        public Nullable<decimal> EachWeightGrams { get; set; }
        public int SuppliesId { get; set; }
        public string FinishedGoodMakeBuy { get; set; }
        public bool isTaxableNYS { get; set; }
        public bool isTaxableCanada { get; set; }
        public bool ReceivingBoxLabelsRequired { get; set; }
        public int StorageConditionId { get; set; }
        public int QcTestId { get; set; }
        public int ExpirationMonths { get; set; }
        public decimal PctOfLifeForRetesting { get; set; }
        public int QuarantineTypeId { get; set; }
        public bool areMultipleBinsRequired { get; set; }
        public System.DateTime FinishedGoodAddedDate { get; set; }
        public System.DateTime FinishedGoodChangedDate { get; set; }
        public Nullable<System.DateTime> FinishedGoodDeletedDate { get; set; }
        public int FinishedGoodModifiedById { get; set; }
        public bool isDeleted { get; set; }
    
        public virtual Bottle Bottle { get; set; }
        public virtual Brand Brand { get; set; }
        public virtual Bulk Bulk { get; set; }
        public virtual ItemStatu ItemStatu { get; set; }
        public virtual PackagingLevel PackagingLevel { get; set; }
        public virtual QcTest QcTest { get; set; }
        public virtual Supply Supply { get; set; }
    }
}
