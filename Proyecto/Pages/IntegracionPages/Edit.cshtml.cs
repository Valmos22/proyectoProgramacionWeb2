using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Proyecto.Data;
using Proyecto.Entities;

namespace Proyecto.Pages.IntegracionPages
{
    public class EditModel : PageModel
    {
        private readonly Proyecto.Data.ProyectoPDCContext _context;

        public EditModel(Proyecto.Data.ProyectoPDCContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Integracion Integracion { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Integracion = await _context.Integracion.FirstOrDefaultAsync(m => m.Id == id);

            if (Integracion == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Integracion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IntegracionExists(Integracion.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool IntegracionExists(int id)
        {
            return _context.Integracion.Any(e => e.Id == id);
        }
    }
}
