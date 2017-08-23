using System;

namespace WMP.NHBC.DevDetective.CFEntityFramework.Models
{
    public partial class FacilityInventoryItemTypes
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public bool IsActive { get; set; }
        public string Sku { get; set; }
        public int? QuantityOnHand { get; set; }
        public int? QuantityOnOrder { get; set; }
        public int? InventoryItemTypeId { get; set; }
        public int FacilityId { get; set; }
        public decimal Price { get; set; }

        public virtual Facilities Facility { get; set; }
        public virtual InventoryItemTypes InventoryItemType { get; set; }
    }
}
