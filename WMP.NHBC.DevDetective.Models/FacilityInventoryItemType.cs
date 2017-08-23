using System;

namespace WMP.NHBC.DevDetective.Models
{
    public class FacilityInventoryItemTypeModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public bool IsActive { get; set; }
        public string SKU { get; set; }
        public int? QuantityOnHand { get; set; }
        public int? QuantityOnOrder { get; set; }
        public int? InventoryItemTypeId { get; set; }
        public int FacilityId { get; set; }
    }
}
