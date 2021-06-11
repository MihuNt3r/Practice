using System;

namespace BusinessLogicLayer.Exceptions
{
    public class MatchCreationException : Exception
    {
        public MatchCreationException(string message) : base(message)
        {
        }
    }
}
