using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
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

        public EditModel(IHttpContextAccessor httpContextAccessor, Proyecto.Data.ProyectoPDCContext context)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;

            V_tema = Proyecto.Code.Utilidades.TienePermisos(_session.GetString("Permissions"), "V_TEMA");
            V_estudiante = Proyecto.Code.Utilidades.TienePermisos(_session.GetString("Permissions"), "V_ESTUDIANTE");
            V_asesor = Proyecto.Code.Utilidades.TienePermisos(_session.GetString("Permissions"), "V_ASESOR");
            V_entrega = Proyecto.Code.Utilidades.TienePermisos(_session.GetString("Permissions"), "V_ENTREGA");
            V_grupo = Proyecto.Code.Utilidades.TienePermisos(_session.GetString("Permissions"), "V_GRUPO");
            V_integracion = Proyecto.Code.Utilidades.TienePermisos(_session.GetString("Permissions"), "V_INTEGRACION");

            V_edit = Proyecto.Code.Utilidades.TienePermisos(_session.GetString("Permissions"), "V_EDIT");
        }

        //---------------------------------------------------------------------------

        private readonly IHttpContextAccessor _httpContextAccessor;
        private ISession _session => _httpContextAccessor.HttpContext.Session;

        private bool v_tema;
        private bool v_estudiante;
        private bool v_asesor;
        private bool v_entrega;
        private bool v_grupo;
        private bool v_integracion;
        private bool v_edit;


        [BindProperty]
        public bool V_tema { get => v_tema; set => v_tema = value; }
        public bool V_estudiante { get => v_estudiante; set => v_estudiante = value; }
        public bool V_asesor { get => v_asesor; set => v_asesor = value; }
        public bool V_entrega { get => v_entrega; set => v_entrega = value; }
        public bool V_grupo { get => v_grupo; set => v_grupo = value; }
        public bool V_integracion { get => v_integracion; set => v_integracion = value; }

        public bool V_edit { get => v_edit; set => v_edit = value; }

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
