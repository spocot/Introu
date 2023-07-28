using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Introu.Extensions
{
    internal static class TypeExtensions
    {
        public static bool ImplementsGenericInterface(this Type type, Type genericInterfaceType)
        {
            // First check if the type itself is the generic interface type
            if (type.IsGenericType && type.GetGenericTypeDefinition() == genericInterfaceType)
                return true;

            // Otherwise, check all interfaces for this type.
            return type.GetInterfaces().Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == genericInterfaceType);
        }
    }
}
