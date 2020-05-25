using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace Proyecto.Pages
{
    public class IndexPageModel : PageModel
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private ISession _session => _httpContextAccessor.HttpContext.Session;

        private bool v_tema;
        private bool v_estudiante;
        private bool v_asesor;
        private bool v_entrega;
        private bool v_grupo;
        private bool v_integracion;


        public IndexPageModel(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;

            V_tema = Proyecto.Code.Utilidades.TienePermisos(_session.GetString("Permissions"), "V_TEMA");
            V_estudiante = Proyecto.Code.Utilidades.TienePermisos(_session.GetString("Permissions"), "V_ESTUDIANTE");
            V_asesor = Proyecto.Code.Utilidades.TienePermisos(_session.GetString("Permissions"), "V_ASESOR");
            V_entrega = Proyecto.Code.Utilidades.TienePermisos(_session.GetString("Permissions"), "V_ENTREGA");
            V_grupo = Proyecto.Code.Utilidades.TienePermisos(_session.GetString("Permissions"), "V_GRUPO");
            V_integracion = Proyecto.Code.Utilidades.TienePermisos(_session.GetString("Permissions"), "V_INTEGRACION");
        }


        [BindProperty]
        public bool V_tema { get => v_tema; set => v_tema = value; }
        public bool V_estudiante { get => v_estudiante; set => v_estudiante = value; }
        public bool V_asesor { get => v_asesor; set => v_asesor = value; }
        public bool V_entrega { get => v_entrega; set => v_entrega = value; }
        public bool V_grupo { get => v_grupo; set => v_grupo = value; }
        public bool V_integracion { get => v_integracion; set => v_integracion = value; }

        public void OnGet()
        {

        }
    }
}
