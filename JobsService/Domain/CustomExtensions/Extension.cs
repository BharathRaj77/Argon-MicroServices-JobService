using Domain.CustomeAttributes;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Extensions
{
    public static class Extension
    {
        public static string GetJobIdPrefix(this JobTypeEnum enumValue)
        {
            var attributevalue = enumValue.GetEnumAttribute<JobIdPrefixAttribute>();
            return attributevalue == null ? string.Empty : attributevalue.Value;
        }
        public static TAttr GetEnumAttribute<TAttr>(this Enum value) where TAttr : Attribute
        {
            var type = value.GetType();
            var name = Enum.GetName(type, value);

            return type.GetField(name)
                       .GetCustomAttributes(false)
                       .OfType<TAttr>()
                       .SingleOrDefault();
        }
    }
}
