using System;

namespace BusinessLogicLayer.Exceptions
{
    public class DuplicateException : Exception
    {
        public DuplicateException(string message) : base(message)
        {
        }
    }
}
