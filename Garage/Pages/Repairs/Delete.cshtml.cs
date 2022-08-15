using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Garage.Data;
using Garage.Models;

namespace Garage.Pages.Repairs
{
    public class DeleteModel : PageModel
    {
        private readonly Garage.Data.GarageContext _context;

        public DeleteModel(Garage.Data.GarageContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Repair Repair { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Repair = await _context.Repair
                .Include(r => r.Car).FirstOrDefaultAsync(m => m.ID == id);

            if (Repair == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Repair = await _context.Repair.FindAsync(id);

            if (Repair != null)
            {
                _context.Repair.Remove(Repair);
                await _context.SaveChangesAsync();
            }

            //return RedirectToPage("./Index");
            return RedirectToPage($"../Cars/Details", new {id = Repair.CarID});
        }
    }
}
