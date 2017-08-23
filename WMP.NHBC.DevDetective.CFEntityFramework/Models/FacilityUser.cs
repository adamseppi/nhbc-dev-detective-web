using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace WMP.NHBC.DevDetective.CFEntityFramework.Models
{
    public class FacilityUser
    {
        public virtual Facilities Facility { get; set; }
        [Key]
        public int  FacilityId { get; set; }
        [Key]
        public string UserId { get; set; }
    }

    public class FacilitySale
    {
        [Key]
        public Guid Id { get; set; }
        
        public DateTime CreatedDate { get; set; }
        public bool Completed { get; set; }

        public string CustomerName { get; set; }
        public decimal Price { get; set; }

        public int FacilityId { get; set; }
        public virtual ICollection<FacilitySaleItem> FacilitySaleItems { get; set; } = new List<FacilitySaleItem>();

        public virtual Facilities Facility { get; set; }
    }

    public class FacilitySaleItem
    {
        [Key]
        public int Id { get; set; }
       

        public int FacilityInventoryItemTypeId { get; set; }
        public Guid FacilitySaleId { get; set; }

        public int Quantity { get; set; }

        public string Notes { get; set; }

        public decimal Price { get; set; }

        public virtual FacilityInventoryItemTypes FacilityInventoryItemType { get; set; }

        public virtual FacilitySale FacilitySale { get; set; }
        

    }

    public class FacilityOrderItem
    {
        public int Quantity { get; set; }
        public string ProductName { get; set; }
        public int ProductId { get; set; }
    }
}