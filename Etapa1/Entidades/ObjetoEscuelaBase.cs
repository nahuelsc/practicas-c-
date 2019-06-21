using System;

namespace CorEscuela.Entidades
{
    public  abstract class ObjetoEscuelaBase
    {
        public string Nombre { get; set; }
        public string UniqueId { get; private set; }

        public ObjetoEscuelaBase()
        {
            UniqueId = Guid.NewGuid().ToString();
        }

        public override string ToString()
        {
            return $"{Nombre}, {UniqueId}";
        }
    }
}