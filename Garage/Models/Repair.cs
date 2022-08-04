using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Garage.Models
{
    public class Repair
    {
        public int ID { get; set; }
        [DisplayFormat(DataFormatString = "{0:d}")] 
        public DateTime RepairDate { get; set; }
        public int MileAge { get; set; }
        public string Description { get; set; }
        public int CarID { get; set; }
        public Car Car { get; set; }
    }
}
