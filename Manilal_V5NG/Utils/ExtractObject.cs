using System;
using System.Collections.Generic;

namespace Manilal_V5NG.Utils
{
    public static class ExtractObject
    {
        static public object GetValFromObj(this object obj, string propertyName)
        {
            var dict = (IDictionary<string, object>)obj;
            return dict[propertyName];
        }
    }
}