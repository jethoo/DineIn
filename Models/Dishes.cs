using System;
using System.Collections.Generic;

namespace dineIN.Models
{
    public partial class Dishes
    {
        public Dishes()
        {
            Customers = new HashSet<Customers>();
        }

        public int DishId { get; set; }
        public string DishName { get; set; }
        public string DishDetails { get; set; }

        public virtual ICollection<Customers> Customers { get; set; }
    }
}
