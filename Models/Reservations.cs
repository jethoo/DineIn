using System;
using System.Collections.Generic;

namespace dineIN.Models
{
    public partial class Reservations
    {
        public int ReservationId { get; set; }
        public DateTime Date { get; set; }
        public string Email { get; set; }
        public int? Table { get; set; }

        public virtual Customers EmailNavigation { get; set; }
    }
}
