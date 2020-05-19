using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proyecto.Data;
using Proyecto.Entities;

namespace Proyecto.Pages.EntregasPages
{
    public class DeleteModel : PageModel
    {
        private readonly Proyecto.Data.ProyectoPDCContext _context;

        public DeleteModel(Proyecto.Data.ProyectoPDCContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Entrega Entrega { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Entrega = await _context.Entrega
                .Include(e => e.Grupo)
                .Include(e => e.Integracion).FirstOrDefaultAsync(m => m.Id == id);

            if (Entrega == null)
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

            Entrega = await _context.Entrega.FindAsync(id);

            if (Entrega != null)
            {
                _context.Entrega.Remove(Entrega);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
