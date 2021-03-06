﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TpDemo.DAL.Entities
{
    public class Tour
    {
        public int Id { get; set; }
        public string HotelNames { get; set; }
        public string CityNames { get; set; }
        public string CountryNames { get; set; }

        public DateTime BeginDate { get; set; }
        public DateTime FinishDate { get; set; }
        public bool HotTour { get; set; }
        public string Description { get; set; }
        public string Transports { get; set; }

        public List<TourBooking> TourBookings { get; set; }
    }
}
