using System;
using System.Collections.Generic;

namespace Proyecto.Entities
{
    public partial class Docente
    {
        public Docente()
        {
            Grupo = new HashSet<Grupo>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Codigo { get; set; }
        public bool Active { get; set; }

        public virtual ICollection<Grupo> Grupo { get; set; }
    }
}
