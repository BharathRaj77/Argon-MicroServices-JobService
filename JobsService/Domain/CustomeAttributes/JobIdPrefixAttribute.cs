using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.CustomeAttributes
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    public class JobIdPrefixAttribute : Attribute
    {
        private readonly string _name;
        /// <summary>
        /// returns the Prefix value of the selected enum
        /// </summary>
        /// <param name="name">
        /// </param>
        
        public JobIdPrefixAttribute(string name)
        {
            this._name = name;
        }
        public string Value
        {
            get { return this._name; }
        }
    }
}
