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

namespace Proyecto.Pages.EntregasPages
{
    public class EditModel : PageModel
    {
        private readonly Proyecto.Data.ProyectoPDCContext _context;

        public EditModel(Proyecto.Data.ProyectoPDCContext context)
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
           ViewData["GrupoId"] = new SelectList(_context.Grupo, "Id", "Id");
           ViewData["IntegracionId"] = new SelectList(_context.Integracion, "Id", "Id");
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

            _context.Attach(Entrega).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EntregaExists(Entrega.Id))
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

        private bool EntregaExists(int id)
        {
            return _context.Entrega.Any(e => e.Id == id);
        }
    }
}
