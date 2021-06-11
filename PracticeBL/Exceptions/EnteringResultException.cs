using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeBL.Exceptions
{
    public class EnteringResultException : Exception
    {
        public EnteringResultException(string message) : base(message)
        {
        }
    }
}
