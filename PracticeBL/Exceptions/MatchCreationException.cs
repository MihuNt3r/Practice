using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeBL.Exceptions
{
    public class MatchCreationException : Exception
    {
        public MatchCreationException(string message) : base(message)
        {
        }
    }
}
