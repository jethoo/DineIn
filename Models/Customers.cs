using System;
using System.Collections.Generic;

namespace dineIN.Models
{
    public partial class Customers
    {
        public Customers()
        {
            Reservations = new HashSet<Reservations>();
        }

        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string DishName { get; set; }

        public virtual Dishes DishNameNavigation { get; set; }
        public virtual ICollection<Reservations> Reservations { get; set; }
    }
}
