using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proyecto.Data;
using Proyecto.Entities;

namespace Proyecto.Pages.TemaPages
{
    public class DeleteModel : PageModel
    {
        private readonly Proyecto.Data.ProyectoPDCContext _context;

        public DeleteModel(Proyecto.Data.ProyectoPDCContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Tema Tema { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Tema = await _context.Tema.FirstOrDefaultAsync(m => m.Id == id);

            if (Tema == null)
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

            Tema = await _context.Tema.FindAsync(id);

            if (Tema != null)
            {
                _context.Tema.Remove(Tema);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
