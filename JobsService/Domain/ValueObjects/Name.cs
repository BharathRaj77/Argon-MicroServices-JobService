using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.ValueObjects
{
    public sealed class Name
    {
        private string _text;
        public Name(string text)
        {
            if(string.IsNullOrWhiteSpace(text))
                throw new NameShouldNotBeEmptyException("The 'Name' field is required. Supplied an empty value.");
            _text = text;
        }
        public static implicit operator Name(string text)
        {
            return new Name(text);
        }

        public static implicit operator string(Name name)
        {
            return name._text;
        }
    }
}
