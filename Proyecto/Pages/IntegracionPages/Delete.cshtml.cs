using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proyecto.Data;
using Proyecto.Entities;

namespace Proyecto.Pages.IntegracionPages
{
    public class DeleteModel : PageModel
    {
        private readonly Proyecto.Data.ProyectoPDCContext _context;

        public DeleteModel(Proyecto.Data.ProyectoPDCContext context)
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Integracion = await _context.Integracion.FindAsync(id);

            if (Integracion != null)
            {
                _context.Integracion.Remove(Integracion);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
