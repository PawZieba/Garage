using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Garage.Models
{
    public class Car
    {
        public int ID { get; set; }
        public string Producer { get; set; }
        public string Model { get; set; }
        public string VIN { get; set; }
        public string LicencePlate { get; set; }
        public int CustomerID { get; set; }
        public Customer Customer { get; set; }
    }
}
