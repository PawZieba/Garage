using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Garage.Data;
using Garage.Pages;

namespace Garage.Pages.Customers
{
    public class DetailsModel : PageModel
    {
        private readonly Garage.Data.GarageContext _context;

        public DetailsModel(Garage.Data.GarageContext context)
        {
            _context = context;
        }

        public Models.Customers Customers { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Customers = await _context.Customers.FirstOrDefaultAsync(m => m.ID == id);

            if (Customers == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
