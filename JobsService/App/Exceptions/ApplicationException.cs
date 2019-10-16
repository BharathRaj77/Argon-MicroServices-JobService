using System;
using System.Collections.Generic;
using System.Text;

namespace App.Exceptions
{
    public class ApplicationException : Exception
    {
        internal ApplicationException(string message) : base(message) { }
    }
}
