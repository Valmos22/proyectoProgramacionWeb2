using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
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

        public IndexModel(IHttpContextAccessor httpContextAccessor, Proyecto.Data.ProyectoPDCContext context)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;

            V_crear = Proyecto.Code.Utilidades.TienePermisos(_session.GetString("Permissions"), "V_CREAR");
            V_edit = Proyecto.Code.Utilidades.TienePermisos(_session.GetString("Permissions"), "V_EDIT");
            V_eliminar = Proyecto.Code.Utilidades.TienePermisos(_session.GetString("Permissions"), "V_ELIMINAR");
        }

        public IList<Grupo> Grupo { get;set; }

        public async Task OnGetAsync()
        {
            Grupo = await _context.Grupo
                .Include(g => g.Docente)
                .Include(g => g.Tema).ToListAsync();
        }

        private readonly IHttpContextAccessor _httpContextAccessor;
        private ISession _session => _httpContextAccessor.HttpContext.Session;

        private bool v_crear;
        private bool v_edit;
        private bool v_eliminar;

        [BindProperty]
        public bool V_edit { get => v_edit; set => v_edit = value; }
        public bool V_crear { get => v_crear; set => v_crear = value; }
        public bool V_eliminar { get => v_eliminar; set => v_eliminar = value; }
    }
}
