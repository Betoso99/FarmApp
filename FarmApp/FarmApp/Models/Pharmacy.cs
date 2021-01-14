using System;
using System.Collections.Generic;
using System.Text;

namespace FarmApp.Models
{
    public class Pharmacy
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PharmacyChain { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Schedule { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
    }
}
