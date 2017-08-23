using System;
using System.Collections.Generic;

namespace WMP.NHBC.DevDetective.CFEntityFramework.Models
{
    public partial class InventoryItemTypes
    {
        public InventoryItemTypes()
        {
            FacilityInventoryItemTypes = new HashSet<FacilityInventoryItemTypes>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public bool IsActive { get; set; }
        public string Sku { get; set; }

        public decimal Price { get; set; } = 5m;

        public virtual ICollection<FacilityInventoryItemTypes> FacilityInventoryItemTypes { get; set; }
    }
}
