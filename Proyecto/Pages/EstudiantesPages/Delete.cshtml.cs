using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proyecto.Data;
using Proyecto.Entities;

namespace Proyecto.Pages.EstudiantesPages
{
    public class DeleteModel : PageModel
    {
        private readonly Proyecto.Data.ProyectoPDCContext _context;

        public DeleteModel(Proyecto.Data.ProyectoPDCContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Estudiante Estudiante { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Estudiante = await _context.Estudiante.FirstOrDefaultAsync(m => m.Id == id);

            if (Estudiante == null)
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

            Estudiante = await _context.Estudiante.FindAsync(id);

            if (Estudiante != null)
            {
                _context.Estudiante.Remove(Estudiante);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
