using System;

namespace coreEscuela
{
    class Escuela
    {
        public String nombre;
        public String ciudad;
        public int añoFundacion;
        public String ceo;
        public void Timbrar()
        {
            Console.Beep(2000,3000);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var miEscuela = new Escuela();
            miEscuela.nombre = "Ptalzi Academy";
            miEscuela.ciudad = "Pizarro 7270";
            miEscuela.añoFundacion = 2012;
            Console.WriteLine("TIMBRE");
            miEscuela.Timbrar();

            //Console.WriteLine("Hello World!");
        }
    }
}
