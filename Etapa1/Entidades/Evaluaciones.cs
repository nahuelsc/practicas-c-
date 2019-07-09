using System;

namespace CorEscuela.Entidades
{
    public class Evaluaciones: ObjetoEscuelaBase
    {
        /* public string Nombre { get; set; }
        public string UniqueId { get; private set; } */
        public Alumnos Alumno { get; set; }
        public Asignatura Asignatura { get; set; }
        public float Nota { get; set; }
        
        /* public Evaluaciones()
        {
            UniqueId = Guid.NewGuid().ToString();
        } */

        public override string ToString()
        {
            return $"{Nota}, {Alumno.Nombre}, {Asignatura.Nombre}";
        }
    }
    
}