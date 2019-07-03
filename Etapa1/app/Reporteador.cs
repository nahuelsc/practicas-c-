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
    }
}