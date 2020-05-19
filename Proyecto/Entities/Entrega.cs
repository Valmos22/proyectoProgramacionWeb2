﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Proyecto.Entities
{
    public partial class Entrega
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        [Display(Name = "Numero Entrega")]
        public string NroEntrega { get; set; }

        [Display(Name = "Subir Documento")]
        public byte[] Documento { get; set; }

        [Display(Name = "Grupo")]
        public int? GrupoId { get; set; }

        [Display(Name = "Integracion")]
        public int? IntegracionId { get; set; }

        public DateTime FechaEntrega { get; set; }
        public decimal? Nota { get; set; }
        public bool Active { get; set; }

        public virtual Grupo Grupo { get; set; }
        public virtual Integracion Integracion { get; set; }
    }
}
