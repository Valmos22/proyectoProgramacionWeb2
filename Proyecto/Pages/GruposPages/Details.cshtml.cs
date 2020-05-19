using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proyecto.Data;
using Proyecto.Entities;

namespace Proyecto.Pages.GruposPages
{
    public class DetailsModel : PageModel
    {
        private readonly Proyecto.Data.ProyectoPDCContext _context;

        public DetailsModel(Proyecto.Data.ProyectoPDCContext context)
        {
            _context = context;
        }

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
            return Page();
        }
    }
}
