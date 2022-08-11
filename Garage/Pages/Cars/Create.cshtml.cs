using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Garage.Data;
using Garage.Models;

namespace Garage.Pages
{
    public class CreateModel : PageModel
    {
        private readonly Garage.Data.GarageContext _context;

        public CreateModel(Garage.Data.GarageContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            var fullNameList = _context.Customers.Select(s => new { s.ID, Fullname = s.FirstName + " " + s.LastName });
            ViewData["CustomerID"] = new SelectList(fullNameList, "ID", "Fullname");
            return Page();
        }

        [BindProperty]
        public Car Car { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Car.Add(Car);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
