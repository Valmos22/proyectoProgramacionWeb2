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

namespace Proyecto.Pages.GruposPages
{
    public class EditModel : PageModel
    {
        private readonly Proyecto.Data.ProyectoPDCContext _context;

        public EditModel(Proyecto.Data.ProyectoPDCContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Grupo Grupo { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Grupo = await _context.Grupo
                .Include(g => g.Docente)
                .Include(g => g.Tema).FirstOrDefaultAsync(m => m.Id == id);

            if (Grupo == null)
            {
                return NotFound();
            }
           ViewData["DocenteId"] = new SelectList(_context.Docente, "Id", "Nombre");
           ViewData["TemaId"] = new SelectList(_context.Tema, "Id", "Descripcion");
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

            _context.Attach(Grupo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GrupoExists(Grupo.Id))
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

        private bool GrupoExists(int id)
        {
            return _context.Grupo.Any(e => e.Id == id);
        }
    }
}
