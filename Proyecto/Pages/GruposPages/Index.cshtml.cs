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
    public class IndexModel : PageModel
    {
        private readonly Proyecto.Data.ProyectoPDCContext _context;

        public IndexModel(Proyecto.Data.ProyectoPDCContext context)
        {
            _context = context;
        }

        public IList<Grupo> Grupo { get;set; }

        public async Task OnGetAsync()
        {
            Grupo = await _context.Grupo
                .Include(g => g.Docente)
                .Include(g => g.Tema).ToListAsync();
        }
    }
}
