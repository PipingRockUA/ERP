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
    
    public partial class Bottle2
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Bottle2()
        {
            this.BottlesPerCases = new HashSet<BottlesPerCase>();
            this.FinishedGoods = new HashSet<FinishedGood>();
        }
    
        public int BottleId { get; set; }
        public System.Guid ItemGUID { get; set; }
        public string BottleItemKey { get; set; }
        public string BottleDescription { get; set; }
        public int BottlesSmallTray { get; set; }
        public int BottlesLargeTray { get; set; }
        public int WrappedBottlesTrayLarge { get; set; }
        public int WrappedBottlesTraySmall { get; set; }
        public int LayersUnWrapped { get; set; }
        public int LayersWrapped { get; set; }
        public int ItemStatusId { get; set; }
        public int ItemTypeId { get; set; }
        public int ItemSubTypeId { get; set; }
        public decimal BottleLengthInches { get; set; }
        public decimal BottleWidthInches { get; set; }
        public decimal BottleHieghtInches { get; set; }
        public decimal BottleCubicInches { get; set; }
        public decimal BottleLengthCm { get; set; }
        public decimal BottleWidthCm { get; set; }
        public decimal BottleHieghtCm { get; set; }
        public decimal BottleCubicCm { get; set; }
        public decimal BottleLengthWrappedInches { get; set; }
        public decimal BottleWidthWrappedInches { get; set; }
        public decimal BottleDepthWrappedInches { get; set; }
        public decimal BottleCubicInchWrappedInches { get; set; }
        public decimal BottleLengthWrappedCm { get; set; }
        public decimal BottleWidthWrappedCm { get; set; }
        public decimal BottleDepthWrappedCm { get; set; }
        public decimal BottleCubicInchWrappedCm { get; set; }
        public decimal BottleLabelSquareInches { get; set; }
        public decimal LabelSquareInches { get; set; }
        public decimal LabelSquareCm { get; set; }
        public string BottleSize { get; set; }
        public int PrintFrames { get; set; }
        public int NumberOfPrintingPositions { get; set; }
        public System.DateTime BottleAddedDate { get; set; }
        public System.DateTime BottleChangedDate { get; set; }
        public Nullable<System.DateTime> BottleDeletedDate { get; set; }
        public int BottleModifiedById { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BottlesPerCase> BottlesPerCases { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FinishedGood> FinishedGoods { get; set; }
    }
}
