using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Garage.Data;
using Garage.Models;

namespace Garage.Pages.Customers
{
    public class IndexModel : PageModel
    {
        private readonly Garage.Data.GarageContext _context;

        public IndexModel(Garage.Data.GarageContext context)
        {
            _context = context;
        }

        public IList<Models.Customer> Customers { get;set; }

        public async Task OnGetAsync()
        {
            Customers = await _context.Customers
                .Include(customer => customer.Cars)
                .ToListAsync();

            //Searching
            var searchString = from c in _context.Customers
                               select c;

            if (!string.IsNullOrEmpty(SearchString))
            {
                searchString = searchString.Where(s => s.FirstName.Contains(SearchString) || s.LastName.Contains(SearchString));
            }

            Customers = await searchString.ToListAsync();
            //End searching
        }

        //Add searching
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
    }
}
