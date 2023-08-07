using System;

namespace DaleStore.Core.Excepciones
{
    public class NegocioException : Exception
    {
        public NegocioException()
        {

        }
        public NegocioException(string mensaje) : base(mensaje)
        {

        }
    }
}
