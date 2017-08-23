using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace WMP.NHBC.DevDetective.Models
{
    
    public class InventoryItemTypeModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<System.DateTime> UpdateDate { get; set; }
        public bool IsActive { get; set; }
        public string SKU { get; set; }
    }
}