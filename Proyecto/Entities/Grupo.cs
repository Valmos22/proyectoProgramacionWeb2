﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Proyecto.Entities
{
    public partial class Grupo
    {
        public Grupo()
        {
            Entrega = new HashSet<Entrega>();
        }

        public int Id { get; set; }

        [Display(Name = "Tema")]
        public int TemaId { get; set; }

        [Display(Name = "Integrante 1")]
        public string Estudiante1 { get; set; }

        [Display(Name = "Integrante 2")]
        public string Estudiante2 { get; set; }

        [Display(Name = "Integrante 3")]
        public string Estudiante3 { get; set; }

        [Display(Name = "Asesor")]
        public int? DocenteId { get; set; }
        public bool Active { get; set; }

        public virtual Docente Docente { get; set; }
        public virtual Tema Tema { get; set; }
        public virtual ICollection<Entrega> Entrega { get; set; }
    }
}
