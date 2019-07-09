using System;
using System.Linq;
using System.Collections.Generic;
using CorEscuela.Entidades;

namespace CorEscuela.app
{
    public class Reporteador
    {
        Dictionary<LlaveDiccionario, IEnumerable<ObjetoEscuelaBase>> _diccionario;
        public Reporteador(Dictionary<LlaveDiccionario, IEnumerable<ObjetoEscuelaBase>> dicObjEsc)
        {
            if(dicObjEsc == null)
            {
                throw new ArgumentException(nameof(dicObjEsc));
            }
            _diccionario = dicObjEsc;
        }
        public IEnumerable<Evaluaciones> GetListaEvaluaciones()
        {
            if(_diccionario.TryGetValue(LlaveDiccionario.Evaluaciones,
                                            out IEnumerable<ObjetoEscuelaBase> lista))
            {
                return lista.Cast<Evaluaciones>();
            }
            else
            {
                return new List<Evaluaciones>();
            }
        }
        public IEnumerable<string> GetListaAsignaturas()
        {
            return GetListaAsignaturas(out var dummy);
        }
        public IEnumerable<string> GetListaAsignaturas(
                        out IEnumerable<Evaluaciones> listaEvaluaciones)
        {
            listaEvaluaciones = GetListaEvaluaciones();

            return (from Evaluaciones ev in listaEvaluaciones
                   select ev.Asignatura.Nombre).Distinct();
        }
        public Dictionary<string, IEnumerable<Evaluaciones>> GetDicEvaluacionesXAsig()
        {
            var dicRta = new Dictionary<string, IEnumerable<Evaluaciones>>();
            
            var listaAsig = GetListaAsignaturas(out var listaEval);

            foreach (var asig in listaAsig)
            {
                var evalAsig = from eval in listaEval
                               where eval.Asignatura.Nombre == asig
                               select eval;

                dicRta.Add(asig, evalAsig);
            }

            return dicRta;
        }

        public Dictionary<string, IEnumerable<object>> GetPromeAlumPorAsignatura()
        {
            var rta = new Dictionary<string, IEnumerable<object>>();
            var dicEvalXAsig = GetDicEvaluacionesXAsig();

            foreach (var asigConEval in dicEvalXAsig)
            {
                var promsAlumn = from eval in asigConEval.Value
                            group eval by new {
                                        eval.Alumno.UniqueId,
                                        eval.Alumno.Nombre
                            }
                            into grupoEvalsAlumno
                            select new AlumnoPromedio
                            {
                                alumnoId = grupoEvalsAlumno.Key.UniqueId,
                                alumnoNombre = grupoEvalsAlumno.Key.Nombre,
                                promedio = grupoEvalsAlumno.Average(Evaluaciones => Evaluaciones.Nota)
                            };
                rta.Add(asigConEval.Key, promsAlumn);
            }

            return rta;

        }

        public IEnumerable<object> GetMejoresPromedioXAsig(string nombreAsig, int num = 5)
        {
            //var rtaMejorProm = new Dictionary<string, IEnumerable<object>>();
            var tomarPromedios = GetPromeAlumPorAsignatura();

            var rta = tomarPromedios.GetValueOrDefault(nombreAsig).OrderByDescending(prom => ((AlumnoPromedio)
                                                                                prom).promedio).Take(num);
            return rta;

           /*  foreach (var promedio in tomarPromedios)
            {
                var dummy = from ev in promedio.Value
                            orderby ev
                            select ev
            } */
        }
    }
}