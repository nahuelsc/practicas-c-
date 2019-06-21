using System;
using System.Collections.Generic;
using CorEscuela.Util;

namespace CorEscuela.Entidades
{
    public class Escuela: ObjetoEscuelaBase, ILugar
    {
        /* public string UniqueId { get; private set; } = Guid.NewGuid().ToString();
        string nombre;
        public string Nombre
        {
            get { return "Copia: "+ nombre; }
            set { nombre = value.ToUpper() ;}
        } */
        public int AñoCreacion { get; set; }
        public string Ciudad { get; set; }
        public string Direccion { get; set; }
        public string Pais { get; set; }
        public TiposEscuela TipoEscuela { get; set; }

        // esto era pasandole al atributo un array 
        //public Cursos[] Curso { get; set; }
        // esto es pasandole una coleccion tipo lista
        public List<Cursos> Curso { get; set; }

        // una forma de constructor
        /* public Escuela(string nombre, int año)
        {
            this.nombre = nombre;
            AñoCreacion = año;
        } */
        public Escuela(string nombre, int año) => (Nombre, AñoCreacion) = (nombre, año);
        // constructor para que cuando se crea el objeto instanciado se le pase ciertos parametros
        public Escuela(string nombre, int año, TiposEscuela tipo, string pais="", string ciudad="")
        {
            //asignaciones
            (Nombre, AñoCreacion) = (nombre, año);
            Pais = pais;
            Ciudad = ciudad;
        }

        public override string ToString()
        {
            return $"Nombre: {Nombre}, Tipo: {TipoEscuela}, \nPais: {Pais}, Ciudad: {Ciudad}";
        }

        public void LimpiarLugar()
        {
            Printer.DrawLine();
            Console.WriteLine("Limpiando Escuela...");
            foreach (var curso in Curso)
            {
                curso.LimpiarLugar();
            }
            Printer.WriteTitle($"Escuela {Nombre} esta Limpia");
            Printer.Beep(1000, cantidad: 3);
        }
    }
}