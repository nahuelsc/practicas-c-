using System.Dynamic;
using System;
using System.Collections.Generic;
using System.Linq;
using CorEscuela.Entidades;
using static System.Console;

namespace CorEscuela
{
    public sealed class EscuelaEngine
    {
        public Escuela Escuela { get; set; }

        public EscuelaEngine()
        {

        }

        public void Inicializar()
        {
            Escuela = new Escuela("Platzi Academy", 2012, TiposEscuela.Primaria,
                            ciudad: "Bogota", pais: "Colombia");
            CargarCursos();
            CargarAsignaturas();
            CargarEvaluaciones();
        }

        public Dictionary<string, IEnumerable<ObjetoEscuelaBase>> GetDiccionarioObjetos()
        {
            var diccionario = new Dictionary<string, IEnumerable<ObjetoEscuelaBase>>();



            
            diccionario.Add("Escuela", Escuela);
            diccionario.Add("Cursos", Escuela.Curso.Cast<ObjetoEscuelaBase>());
            
            return diccionario;
        }
        //sobre carga de metodos    
        public IReadOnlyList<ObjetoEscuelaBase> GetObjetosEscuela(
                bool traeEvaluaciones = true,
                bool traeAlumnos = true,
                bool traeAsignaturas = true,
                bool traeCursos = true
                )
        {
            return GetObjetosEscuela(out int dummy, out dummy, out dummy, out dummy);
        }
        public IReadOnlyList<ObjetoEscuelaBase> GetObjetosEscuela(
                out int conteoEvaluaciones,
                bool traeEvaluaciones = true,
                bool traeAlumnos = true,
                bool traeAsignaturas = true,
                bool traeCursos = true
                )
        {
            return GetObjetosEscuela(out conteoEvaluaciones, out int dummy, out dummy, out dummy);
        }
        public IReadOnlyList<ObjetoEscuelaBase> GetObjetosEscuela(
                out int conteoEvaluaciones,
                out int conteoAlumnos,
                out int conteoAsignaturas,
                bool traeEvaluaciones = true,
                bool traeAlumnos = true,
                bool traeAsignaturas = true,
                bool traeCursos = true
                )
        {
            return GetObjetosEscuela(out conteoEvaluaciones, out conteoAlumnos, out conteoAsignaturas, out int dummy);
        }
        public IReadOnlyList<ObjetoEscuelaBase> GetObjetosEscuela(
            out int conteoEvaluaciones,
            out int conteoAlumnos,
            out int conteoAsignaturas,
            out int conteoCursos,
            bool traeEvaluaciones = true,
            bool traeAlumnos  = true,
            bool traeAsignaturas  = true,
            bool traeCursos  = true
            )
        {
            /* conteoEvaluaciones = 0;
            conteoAlumnos = 0;
            conteoAsignaturas = 0;
            conteoCursos = 0; */
            conteoEvaluaciones = conteoAlumnos = conteoAsignaturas = conteoCursos = 0;

            var listObj = new List<ObjetoEscuelaBase>();
            listObj.Add(Escuela);

            if(traeCursos)
                listObj.AddRange(Escuela.Curso);
            conteoCursos += Escuela.Curso.Count;

            foreach (var curso in Escuela.Curso)
            {
                conteoAsignaturas += curso.Asignaturas.Count;
                if(traeAsignaturas)
                    listObj.AddRange(curso.Asignaturas);

                conteoAlumnos += curso.Alumnos.Count;
                if(traeAlumnos)
                    listObj.AddRange(curso.Alumnos);

                if(traeEvaluaciones)
                {
                    foreach (var alumno in curso.Alumnos)
                    {
                        listObj.AddRange(alumno.Evaluaciones);
                        conteoEvaluaciones += alumno.Evaluaciones.Count;
                    }
                }
            }

            return listObj;
        }

        public IReadOnlyList<ObjetoEscuelaBase> GetObjetosEscuela()
        {
            var listObj = new List<ObjetoEscuelaBase>();
            listObj.Add(Escuela);
            listObj.AddRange(Escuela.Curso);


            foreach (var curso in Escuela.Curso)
            {
                listObj.AddRange(curso.Asignaturas);
                listObj.AddRange(curso.Alumnos);

                foreach (var alumno in curso.Alumnos)
                {
                    listObj.AddRange(alumno.Evaluaciones);
                }
            }

            return listObj.AsReadOnly();
        }

#region Metodos de carga
        private void CargarEvaluaciones()
        {
            foreach (var curso in Escuela.Curso)
            {
                //foreach (var asignatura in curso.Asignaturas)
                foreach (var alumno in curso.Alumnos)
                {
                    //foreach (var alumno in curso.Alumnos)
                    foreach (var asignatura in curso.Asignaturas)
                    {
                        Random rnd = new Random();
                        //float aleatorio = rnd.Next(0, 5);
                        for (int i = 0; i < 5; i++)
                        {
                            var ev = new Evaluaciones
                            {
                                Asignatura = asignatura,
                                Nombre = $"{asignatura.Nombre} ev#{i + 1}",
                                Nota = (float)(5 * rnd.NextDouble()),
                                Alumno = alumno
                            };
                            alumno.Evaluaciones.Add(ev);
                            WriteLine($"{curso.Nombre}, {alumno.Nombre}, {ev.Nombre}, {ev.Nota}");
                            
                        }
                    }
                }
            }
        }
        
        private void CargarAsignaturas()
        {
            var listaAsignatura = new List<Asignatura>(){
                                new Asignatura(){Nombre = "Matematicas"},
                                new Asignatura(){Nombre = "Educacion Fisica"},
                                new Asignatura(){Nombre = "Castellano"},
                                new Asignatura(){Nombre = "Ciencias Naturales"}
            };
            foreach (var curso in Escuela.Curso)
            {
                curso.Asignaturas = listaAsignatura;
            }
        }

        private List<Alumnos> GenerarAlumnosAlAzar(int cantidad)
        {
            string[] nombre1 = {"Nahuel","Laura","Diego","Maria","Josefina"};
            string[] apellido1 = { "Schimpf", "Gonzalez", "Perez", "Rodrigues", "Gracia" };
            string[] nombre2 = { "Carlos", "Hernan", "Adrian", "Graciela", "Mariela" };

            var listaAlumnos = from n1 in nombre1
                               from n2 in nombre2
                               from a1 in apellido1
                               select new Alumnos{Nombre = $"{n1} {n2} {a1}"};
            return listaAlumnos.OrderBy( (al) => al.UniqueId).Take(cantidad).ToList();
        }

        private void CargarCursos()
        {
            Escuela.Curso = new List<Cursos>(){
                            new Cursos(){Nombre = "101", Jornada = TipoJornada.Mañana},
                            new Cursos(){Nombre = "201", Jornada = TipoJornada.Mañana},
                            new Cursos(){Nombre = "301", Jornada = TipoJornada.Mañana},
                            new Cursos(){Nombre = "401", Jornada = TipoJornada.Tarde},
                            new Cursos(){Nombre = "501", Jornada = TipoJornada.Tarde}
            };

            Random rnd = new Random();
            foreach (var c in Escuela.Curso)
            {
                int cantidadRandom = rnd.Next(5, 20);
                c.Alumnos = GenerarAlumnosAlAzar(cantidadRandom);
            }
        }
    }
    #endregion
}