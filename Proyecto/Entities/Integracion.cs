using System;
using System.Collections.Generic;

namespace Proyecto.Entities
{
    public partial class Integracion
    {
        public Integracion()
        {
            Entrega = new HashSet<Entrega>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }


        public string Asignatura1 { get; set; }
        public string Asignatura2 { get; set; }
        public string Asignatura3 { get; set; }

        public virtual ICollection<Entrega> Entrega { get; set; }
    }
}
