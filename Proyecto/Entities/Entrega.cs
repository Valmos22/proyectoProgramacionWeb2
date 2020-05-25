using System;
using System.Collections.Generic;

namespace Proyecto.Entities
{
    public partial class Entrega
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string NroEntrega { get; set; }
        public byte[] Documento { get; set; }
        public int? GrupoId { get; set; }
        public int? IntegracionId { get; set; }
        public DateTime FechaEntrega { get; set; }
        public decimal? Nota { get; set; }
        public bool Active { get; set; }

        public virtual Grupo Grupo { get; set; }
        public virtual Integracion Integracion { get; set; }
    }
}
