using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Garage.Data;
using Garage.Models;

namespace Garage.Pages
{
    public class IndexModel : PageModel
    {
        private readonly Garage.Data.GarageContext _context;

        public IndexModel(Garage.Data.GarageContext context)
        {
            _context = context;
        }

        public IList<Car> Car { get;set; }

        public async Task OnGetAsync()
        {
            Car = await _context.Car
                .Include(c => c.Customer).ToListAsync();
        }
    }
}
