using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Garage.Models
{
    public class Repair
    {
        public int ID { get; set; }
        public DateTime RepairDate { get; set; }
        public int MileAge { get; set; }
        public string Description { get; set; }
        public int CarID { get; set; }
        public Car Car { get; set; }
    }
}
