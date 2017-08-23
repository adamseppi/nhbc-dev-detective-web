using System;
using System.Collections.Generic;

namespace WMP.NHBC.DevDetective.CFEntityFramework.Models
{
    public partial class Tenants
    {
        public Tenants()
        {
            Facilities = new HashSet<Facilities>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<Facilities> Facilities { get; set; }
    }
}
