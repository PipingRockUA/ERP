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
    
    public partial class QcTest
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public QcTest()
        {
            this.Bulks = new HashSet<Bulk>();
            this.Bulk_QcTest = new HashSet<Bulk_QcTest>();
            this.FinishedGoods = new HashSet<FinishedGood>();
            this.FinishedGood_QcTest = new HashSet<FinishedGood_QcTest>();
            this.QcTest11 = new HashSet<QcTest>();
        }
    
        public int QcTestId { get; set; }
        public string QcTest1 { get; set; }
        public int QcTestParentId { get; set; }
        public System.DateTime QcTestAddedDate { get; set; }
        public System.DateTime QcTestChangedDate { get; set; }
        public Nullable<System.DateTime> QcTestDeletedDate { get; set; }
        public int QcTestModifiedById { get; set; }
        public bool isDeleted { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Bulk> Bulks { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Bulk_QcTest> Bulk_QcTest { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FinishedGood> FinishedGoods { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FinishedGood_QcTest> FinishedGood_QcTest { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<QcTest> QcTest11 { get; set; }
        public virtual QcTest QcTest2 { get; set; }
    }
}
