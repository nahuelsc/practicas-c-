using System;
using System.Collections.Generic;
using CorEscuela.Util;

namespace CorEscuela.Entidades
{
    public class Cursos: ObjetoEscuelaBase, ILugar
    {
        /* public string Nombre { get; set; }
        public string UniqueId { get; private set; } */
        public TipoJornada Jornada { get; set; }
        public List<Asignatura> Asignaturas { get; set; }
        public List<Alumnos> Alumnos { get; set; }
        public string Direccion { get; set; }

        public void LimpiarLugar()
        {
            Printer.DrawLine();
            Console.WriteLine("Limpiando Establecimineto...");
            Console.WriteLine($"Curso {Nombre} esta Limpio");
        }


        /* public Cursos()
        {
            UniqueId = Guid.NewGuid().ToString();
        } */
    }
}