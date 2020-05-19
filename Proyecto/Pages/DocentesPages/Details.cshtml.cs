using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proyecto.Data;
using Proyecto.Entities;

namespace Proyecto.Pages.DocentesPages
{
    public class DetailsModel : PageModel
    {
        private readonly Proyecto.Data.ProyectoPDCContext _context;

        public DetailsModel(Proyecto.Data.ProyectoPDCContext context)
        {
            _context = context;
        }

        public Docente Docente { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Docente = await _context.Docente.FirstOrDefaultAsync(m => m.Id == id);

            if (Docente == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
