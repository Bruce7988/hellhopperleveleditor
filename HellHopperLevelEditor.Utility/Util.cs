using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;

namespace HellHopperLevelEditor.Utility
{
    public static class Util
    {
        public static string GetPropertyName<TProperty>(Expression<Func<TProperty>> property)
        {
            return property.GetMemberInfo().Name;
        }
    }
}
