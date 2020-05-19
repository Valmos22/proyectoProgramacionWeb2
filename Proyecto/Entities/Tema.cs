using System;
using System.Collections.Generic;

namespace Proyecto.Entities
{
    public partial class Tema
    {
        public Tema()
        {
            Grupo = new HashSet<Grupo>();
        }

        public int Id { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<Grupo> Grupo { get; set; }
    }
}
