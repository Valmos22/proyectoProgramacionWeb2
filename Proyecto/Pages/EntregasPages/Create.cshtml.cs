using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Proyecto.Data;
using Proyecto.Entities;

namespace Proyecto.Pages.EntregasPages
{
    public class CreateModel : PageModel
    {
        private readonly Proyecto.Data.ProyectoPDCContext _context;

        public CreateModel(Proyecto.Data.ProyectoPDCContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["GrupoId"] = new SelectList(_context.Grupo, "Id", "Id");
        ViewData["IntegracionId"] = new SelectList(_context.Integracion, "Id", "Id");
            return Page();
        }

        /*--------------Esta parte es para subir el archivo--------------------*/
        
        
        /*--------------Esta parte es para subir el archivo fin-----------------*/


        [BindProperty]
        public Entrega Entrega { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Entrega.Add(Entrega);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");


        }


    }
}
