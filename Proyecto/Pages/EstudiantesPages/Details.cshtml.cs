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
    public class DetailsModel : PageModel
    {
        private readonly Proyecto.Data.ProyectoPDCContext _context;

        public DetailsModel(Proyecto.Data.ProyectoPDCContext context)
        {
            _context = context;
        }

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
    }
}
