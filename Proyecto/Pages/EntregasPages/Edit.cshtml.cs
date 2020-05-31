using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Proyecto.Data;
using Proyecto.Entities;

namespace Proyecto.Pages.EntregasPages
{
    public class EditModel : PageModel
    {
        private readonly Proyecto.Data.ProyectoPDCContext _context;

        private IHostingEnvironment ihostingEnvironment;

        public string FileName { get; set; }

        String cadenaConexion = "Data Source=(localdb)\\mssqllocaldb; Initial Catalog=ProyectoPDC; Integrated Security=True";

        public EditModel(IHttpContextAccessor httpContextAccessor, Proyecto.Data.ProyectoPDCContext context, IHostingEnvironment ihostingEnvironment)
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

            this.ihostingEnvironment = ihostingEnvironment;
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
        public async Task<IActionResult> OnPostAsync(IFormFile photo)
        {

            byte[] imagenOriginal = null;
            string base64String = " ";
            string nombreArchivo = " ";
            string ruta = " ";

            if (photo != null)
            {

                long Tamanio = photo.Length;
                imagenOriginal = new byte[Tamanio];

                base64String = Convert.ToBase64String(imagenOriginal, 0, imagenOriginal.Length);
                Console.WriteLine(base64String);
                Console.WriteLine(photo.ContentType);
                Console.WriteLine(photo.FileName);
                Console.WriteLine(imagenOriginal.GetValue(32));
                //byte number;

                FileName = photo.FileName;
                var path = Path.Combine(ihostingEnvironment.WebRootPath, "Documento", FileName);
                var stream = new FileStream(path, FileMode.Create);
                await photo.CopyToAsync(stream);

                nombreArchivo = FileName;
                ruta = path;

            }


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

            if (photo != null)
            {

                SqlConnection conexionSQL = new SqlConnection(cadenaConexion);
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "UPDATE Entrega SET Documento = @Documento, NombreArchivo = @NombreArchivo,  RUTA = @RUTA WHERE Id=@Id";
                cmd.Parameters.AddWithValue("@Id", Entrega.Id);
                cmd.Parameters.Add("@Documento", SqlDbType.VarBinary).Value = imagenOriginal;
                cmd.Parameters.Add("@NombreArchivo", SqlDbType.VarChar).Value = nombreArchivo;
                cmd.Parameters.Add("@Ruta", SqlDbType.VarChar).Value = ruta;

                cmd.CommandType = CommandType.Text;
                cmd.Connection = conexionSQL;
                conexionSQL.Open();

                cmd.ExecuteNonQuery();

            }



            return RedirectToPage("./Index");
        }

        private bool EntregaExists(int id)
        {
            return _context.Entrega.Any(e => e.Id == id);
        }
    }
}
