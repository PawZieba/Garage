using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Garage.Data;
using Garage.Models;

namespace Garage.Pages.Repairs
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
        ViewData["CarID"] = new SelectList(_context.Car, "ID", "ID");
            return Page();
        }

        [BindProperty]
        public Repair Repair { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Repair.CarID = id;
            _context.Repair.Add(Repair);
            await _context.SaveChangesAsync();

            return RedirectToPage($"../Cars/Details", new { id = id });
        }
    }
}
