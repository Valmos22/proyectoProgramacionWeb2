using System;
using System.Collections.Generic;

namespace Proyecto.Entities
{
    public partial class Estudiante
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public bool Active { get; set; }
    }
}
