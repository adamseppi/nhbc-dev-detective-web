using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WMP.NHBC.DevDetective.CFEntityFramework.Models
{
    public partial class Facilities
    {
        public Facilities()
        {
            FacilityInventoryItemTypes = new HashSet<FacilityInventoryItemTypes>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public bool IsActive { get; set; }
        public int? ParentFacilityId { get; set; }
        public int TenantId { get; set; }

        [NotMapped]
        public decimal TotalRevenue { get; set; }

        public virtual ICollection<FacilityInventoryItemTypes> FacilityInventoryItemTypes { get; set; } = new List<FacilityInventoryItemTypes>();
        public virtual Facilities ParentFacility { get; set; }
        public virtual ICollection<Facilities> InverseParentFacility { get; set; }
        public virtual ICollection<FacilitySale> Sales { get; set; } = new List<FacilitySale>();
        public virtual Tenants Tenant { get; set; }
    }
}
