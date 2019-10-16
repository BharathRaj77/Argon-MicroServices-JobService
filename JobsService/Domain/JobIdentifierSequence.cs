using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public sealed class JobIdentifierSequence
    {
        public int Id { get; private set; }
        public JobIdentifierSequence(int id)
        {
            Id = id;
        }
    }
}
