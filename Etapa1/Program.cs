using System;
using System.Collections.Generic;
using CorEscuela.Entidades;
using CorEscuela.Util;
using static System.Console;

namespace CorEscuela
{
    class Program
    {
        private static Cursos cursotemp;

        static void Main(string[] args)
        {
                var engine = new EscuelaEngine();
                engine.Inicializar();

                Printer.WriteTitle("BIENVENIDOS A LA ESCUELA");
                Printer.Beep(10000, cantidad:10);   
                imprimirCursosEscuela(engine.Escuela);

                /* var escuela = new Escuela("Platzi Academy", 2012,TiposEscuela.Primaria,
                            ciudad: "Bogota", pais: "Colombia");

                // es una coleccion
                var listaCursos = new List<Cursos>(){
                                new Cursos(){Nombre = "101", Jornada = TipoJornada.Mañana},
                                new Cursos(){Nombre = "201", Jornada = TipoJornada.Mañana},
                                new Cursos(){Nombre = "301", Jornada = TipoJornada.Mañana}
                };
                escuela.Curso = listaCursos;
                escuela.Curso.Add( new Cursos{Nombre = "102", Jornada = TipoJornada.Tarde});
                escuela.Curso.Add(new Cursos { Nombre = "202", Jornada = TipoJornada.Tarde});

                // otra coleccion
                var otraColeccion = new List<Cursos>(){
                                    new Cursos(){Nombre = "401", Jornada = TipoJornada.Mañana},
                                    new Cursos(){Nombre = "501", Jornada = TipoJornada.Mañana},
                                    new Cursos(){Nombre = "501", Jornada = TipoJornada.Tarde}
                };

                //cursotemp = new Cursos{Nombre = "101-Vacacional", Jornada = TipoJornada.Noche};
                escuela.Curso.AddRange(otraColeccion);
                //escuela.Curso.Add(cursotemp); */
                

                /* imprimirCursosEscuela(escuela);
                //WriteLine("Curso hash" + cursotemp.GetHashCode());
                //escuela.Curso.Remove(cursotemp);

                // una manera de buscar el indice y borrarlo
                //Predicate<Cursos> miAlgoritmo = Predicado;
                //escuela.Curso.RemoveAll(Predicado);
                
                // otra manera
                escuela.Curso.RemoveAll(delegate (Cursos cur)
                                        {
                                            return cur.Nombre == "301";
                                        });

                // otra manera mas reducida, llamada expresion lambda
                escuela.Curso.RemoveAll((cur)=> cur.Nombre == "501" && cur.Jornada == TipoJornada.Mañana); */
                
                // array
                /* escuela.Curso = new Cursos[]{
                                new Cursos(){Nombre = "101"},
                                new Cursos(){Nombre = "201"},
                                new Cursos(){Nombre = "301"}
                }; */


            // otra manera de asignacion
            /* escuela.Pais = "Colombia";
            escuela.Ciudad = "Bogota"; */

            // una forma de declarar el arreglo
            /* var arregloCursos = new Cursos[]{
                    new Cursos()
                        {
                            Nombre = "101"

                        },
                    new Cursos()
                        {
                            Nombre = "201"

                        },
                    new Cursos()
                        {
                            Nombre = "301"

                        }
            }; */
            
            // otra forma
            /* Cursos[] arregloCursos = {
                    new Cursos(){Nombre = "101"},
                    new Cursos(){Nombre = "201"},
                    new Cursos(){Nombre = "301"}
            }; */

            /* Console.WriteLine(escuela);
            System.Console.WriteLine("While ===================");
            imprimirArregloWhile(arregloCursos);
            System.Console.WriteLine("Do While ===================");
            imprimirArregloDoWhile(arregloCursos);
            System.Console.WriteLine("For ===================");
            imprimirArregloFor(arregloCursos);
            System.Console.WriteLine("ForEach ===================");
            imprimirArregloForEach(arregloCursos); */
        }

        private static void imprimirCursosEscuela(Escuela escuela)
        {
            Printer.WriteTitle("Cursos de la Escuela");
            
            if(escuela != null && escuela.Curso != null)
            {
                foreach (var curso in escuela.Curso)
                {
                    WriteLine($"Nombre {curso.Nombre}, Id {curso.UniqueId}");

                }
            }
        }

        /* private static void imprimirArregloWhile(Cursos[] arregloCursos)
        {
            var contador = 0;
            while (contador < arregloCursos.Length)
            {
                Console.WriteLine($"Nombre {arregloCursos[contador].Nombre}, Id {arregloCursos[contador].UniqueId}");
                contador++;
            }
        }

        private static void imprimirArregloDoWhile(Cursos[] arregloCursos)
        {
            var contador = 0;
            do
            {
                Console.WriteLine($"Nombre {arregloCursos[contador].Nombre}, Id {arregloCursos[contador].UniqueId}");
                contador++;
            }while (contador < arregloCursos.Length);
            
        }

        private static void imprimirArregloFor(Cursos[] arregloCursos)
        {
            for (int i = 0; i < arregloCursos.Length; i++)
            {
                Console.WriteLine($"Nombre {arregloCursos[i].Nombre}, Id {arregloCursos[i].UniqueId}");
                
            }
        }

        private static void imprimirArregloForEach(Cursos[] arregloCursos)
        {
            foreach (var curso in arregloCursos)
            {
                Console.WriteLine($"Nombre {curso.Nombre}, Id {curso.UniqueId}");
                
            }

        } */
    }
}
