using System;

namespace BusinessLogicLayer.Exceptions
{
    public class EnteringResultException : Exception
    {
        public EnteringResultException(string message) : base(message)
        {
        }
    }
}
