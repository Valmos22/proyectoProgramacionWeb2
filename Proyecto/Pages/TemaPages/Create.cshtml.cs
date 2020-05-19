﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Proyecto.Data;
using Proyecto.Entities;

namespace Proyecto.Pages.TemaPages
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
            return Page();
        }

        [BindProperty]
        public Tema Tema { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Tema.Add(Tema);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}