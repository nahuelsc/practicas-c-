using System;
using System.Collections.Generic;

namespace CorEscuela.Entidades
{
    public class Cursos
    {
        public string Nombre { get; set; }
        public string UniqueId { get; private set; }
        public TipoJornada Jornada { get; set; }
        public List<Asignatura> Asignaturas { get; set; }
        public List<Alumnos> Alumnos { get; set; }
        public Cursos()
        {
            UniqueId = Guid.NewGuid().ToString();
        }
    }
}