using System;
using System.Linq;
using System.Collections.Generic;

namespace MintPlayer.Reflection.Extensions
{
    public static class TypeExtensions
    {
        /// <summary>Returns all interfaces implemented or inherited by the current type.</summary>
        /// <param name="type">Type to investigate</param>
        /// <param name="directOnly">Whether to exclude interfaces implemented by inherited members.</param>
        /// <returns></returns>
        public static IEnumerable<Type> GetInterfaces(this Type type, bool excludeInherited)
        {
            if (excludeInherited)
            {
                // Get all interfaces for the baseType (this includes ALL inherited interfaces)
                var typeBasetypeInterfaces = type.BaseType.GetInterfaces();

                // Get interfaces for type to investigate
                var typeInterfaces = type.GetInterfaces();

                // Get all sub-interfaces for those interfaces
                var typeInterfacesInterfaces = typeInterfaces.SelectMany(t => t.GetInterfaces());

                // Result = Interfaces for type to investigate - All interfaces for the basetype - All interfaces for the subinterfaces
                var interfaces = typeInterfaces.Except(typeBasetypeInterfaces).Except(typeInterfacesInterfaces);

                return interfaces;
            }
            else
            {
                return type.GetInterfaces();
            }
        }
    }
}
