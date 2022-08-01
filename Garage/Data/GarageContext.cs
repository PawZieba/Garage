using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Garage.Pages;
using Garage.Models;

namespace Garage.Data
{
    public class GarageContext : DbContext
    {
        public GarageContext (DbContextOptions<GarageContext> options)
            : base(options)
        {
        }

        public DbSet<Garage.Models.Customer> Customers { get; set; }

        public DbSet<Garage.Models.Car> Car { get; set; }
    }
}
