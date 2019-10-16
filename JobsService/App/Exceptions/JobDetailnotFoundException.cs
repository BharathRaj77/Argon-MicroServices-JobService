using System;
using System.Collections.Generic;
using System.Text;

namespace App.Exceptions
{
    public sealed class JobDetailnotFoundException : ApplicationException
    {
        internal JobDetailnotFoundException(string messgae) : base(messgae) { }
    }
}
