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
    
    public partial class FinishedGood_BuyItems
    {
        public int FinishedGood_BuyItemsId { get; set; }
        public int FinishedGoodId { get; set; }
        public Nullable<int> VendorId { get; set; }
        public int CsTraysperLayer { get; set; }
        public int NbrLayerLow { get; set; }
        public int NbrLayerMedium { get; set; }
        public int NbrLayerHigh { get; set; }
        public Nullable<System.DateTime> LastPurchaseDate { get; set; }
        public Nullable<decimal> LastPurchaseUnitCost { get; set; }
        public System.DateTime FinishedGood_BuyItemsAddedDate { get; set; }
        public System.DateTime FinishedGood_BuyItemsChangedDate { get; set; }
        public Nullable<System.DateTime> FinishedGood_BuyItemsDeletedDate { get; set; }
        public int FinishedGood_BuyItemsModifiedById { get; set; }
    
        public virtual FinishedGood FinishedGood { get; set; }
    }
}
