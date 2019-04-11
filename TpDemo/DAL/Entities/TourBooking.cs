using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TpDemo.DAL.Entities
{
    public class TourBooking
    {
        public int Id { get; set; }
        public decimal Sum { get; set; }
        public int Age { get; set; }
        public int MaxNumberOfPersonInRoom { get; set; }
        public string Notes { get; set; }

        public int TourId { get; set; }
        public Tour Tour { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
    }
}
