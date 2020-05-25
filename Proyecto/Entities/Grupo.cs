﻿using System;
using System.Collections.Generic;

namespace Proyecto.Entities
{
    public partial class Grupo
    {
        public Grupo()
        {
            Entrega = new HashSet<Entrega>();
        }

        public int Id { get; set; }
        public int TemaId { get; set; }
        public string Estudiante1 { get; set; }
        public string Estudiante2 { get; set; }
        public string Estudiante3 { get; set; }
        public int? DocenteId { get; set; }
        public bool Active { get; set; }

        public virtual Docente Docente { get; set; }
        public virtual Tema Tema { get; set; }
        public virtual ICollection<Entrega> Entrega { get; set; }
    }
}
