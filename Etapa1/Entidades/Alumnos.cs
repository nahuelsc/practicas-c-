using System;
using System.Collections.Generic;

namespace CorEscuela.Entidades
{
    public class Alumnos
    {
        public string Nombre { get; set; }
        public string UniqueId { get; private set; }
        public List<Evaluaciones> Evaluaciones {get; set; }

        public Alumnos()
        {
            UniqueId = Guid.NewGuid().ToString();
            Evaluaciones = new List<Evaluaciones>();
        }
    }
}