namespace Bistrotic.Infrastructure.Reflection
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    /// <summary>
    /// Class ReflectionHelper.
    /// </summary>
    public static class ReflectionHelper
    {
        /// <summary>
        /// Gets the concrete classes.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="assembly">The assembly.</param>
        /// <returns>Type[].</returns>
        public static Type[] GetConcreteClasses(this Type type, Assembly assembly)
        {
            return GetInterfaceConcreteClassTypes(assembly, type);
        }

        /// <summary>
        /// Gets the concrete classes.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="assemblies">The assemblies.</param>
        /// <returns>Type[].</returns>
        /// <exception cref="ArgumentNullException">assemblies</exception>
        /// <exception cref="System.ArgumentNullException">assemblies</exception>
        public static Type[] GetConcreteClasses(this Type type, IEnumerable<Assembly> assemblies)
        {
            _ = assemblies ?? throw new ArgumentNullException(nameof(assemblies));

            return assemblies.SelectMany(p => GetInterfaceConcreteClassTypes(p, type)).ToArray();
        }

        /// <summary>
        /// Gets the concrete classes.
        /// </summary>
        /// <typeparam name="TInterface">The type of the t interface.</typeparam>
        /// <param name="assembly">The assembly.</param>
        /// <returns>Type[].</returns>
        public static Type[] GetConcreteClasses<TInterface>(this Assembly assembly)
        {
            return GetInterfaceConcreteClassTypes<TInterface>(assembly);
        }

        /// <summary>
        /// Gets the interface concrete class types.
        /// </summary>
        /// <typeparam name="TInterface">The type of the t interface.</typeparam>
        /// <param name="assembly">The assembly.</param>
        /// <returns>System.Type[].</returns>
        public static Type[] GetInterfaceConcreteClassTypes<TInterface>(Assembly assembly)
        {
            return GetInterfaceConcreteClassTypes(assembly, typeof(TInterface));
        }

        /// <summary>
        /// Gets the interface concrete class types.
        /// </summary>
        /// <param name="assembly">The assembly.</param>
        /// <param name="interfaceType">Type of the interface.</param>
        /// <returns>System.Type[].</returns>
        /// <exception cref="ArgumentNullException">assembly</exception>
        /// <exception cref="ArgumentNullException">interfaceType</exception>
        /// <exception cref="ArgumentException">
        /// The type {interfaceType.Name} is not an interface. - interfaceType
        /// </exception>
        /// <exception cref="System.ArgumentNullException">assembly</exception>
        /// <exception cref="System.ArgumentNullException">interfaceType</exception>
        /// <exception cref="System.ArgumentException">
        /// The type {interfaceType.Name} is not an interface. - interfaceType
        /// </exception>
        /// <exception cref="System.ArgumentNullException">assembly</exception>
        /// <exception cref="ArgumentNullException">interfaceType</exception>
        public static Type[] GetInterfaceConcreteClassTypes(Assembly assembly, Type interfaceType)
        {
            _ = assembly ?? throw new ArgumentNullException(nameof(assembly));
            _ = interfaceType ?? throw new ArgumentNullException(nameof(interfaceType));

            if (!interfaceType.IsInterface)
            {
                throw new ArgumentException($"The type {interfaceType.Name} is not an interface.", nameof(interfaceType));
            }
            return assembly.GetTypes()
                        .Where(p => p.IsClass && p.HasInterface(interfaceType))
                        .ToArray();
        }

        /// <summary>
        /// Gets the interface generic arguments.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="genericInterfaceType">Type of the generic interface.</param>
        /// <returns>Type[].</returns>
        /// <exception cref="ArgumentNullException">type</exception>
        /// <exception cref="ArgumentNullException">genericInterfaceType</exception>
        /// <exception cref="ArgumentException">
        /// The type {genericInterfaceType.Name} is not a generic interface. - genericInterfaceType
        /// </exception>
        /// <exception cref="ArgumentException">
        /// The type {genericInterfaceType.Name} is not assignable from {type.Name}. - genericInterfaceType
        /// </exception>
        /// <exception cref="System.ArgumentNullException">type</exception>
        /// <exception cref="System.ArgumentNullException">genericInterfaceType</exception>
        /// <exception cref="System.ArgumentException">
        /// The type {genericInterfaceType.Name} is not a generic interface. - genericInterfaceType
        /// </exception>
        /// <exception cref="System.ArgumentException">
        /// The type {genericInterfaceType.Name} is not assignable from {type.Name}. - genericInterfaceType
        /// </exception>
        public static Type[] GetInterfaceGenericArguments(this Type type, Type genericInterfaceType)
        {
            _ = type ?? throw new ArgumentNullException(nameof(type));
            _ = genericInterfaceType ?? throw new ArgumentNullException(nameof(genericInterfaceType));
            if (!genericInterfaceType.IsInterface || !genericInterfaceType.IsGenericType)
            {
                throw new ArgumentException($"The type {genericInterfaceType.Name} is not a generic interface.", nameof(genericInterfaceType));
            }
            foreach (Type t in type.GetInterfaces())
            {
                if (t.IsGenericType && t.GetGenericTypeDefinition() == genericInterfaceType)
                {
                    return t.GetGenericArguments();
                }
            }
            throw new ArgumentException($"The type {genericInterfaceType.Name} is not assignable from {type.Name}.", nameof(genericInterfaceType));
        }

        /// <summary>
        /// Determines whether the specified interface type has interface.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="interfaceType">Type of the interface.</param>
        /// <returns><c>true</c> if the specified interface type has interface; otherwise, <c>false</c>.</returns>
        /// <exception cref="ArgumentNullException">type</exception>
        /// <exception cref="ArgumentNullException">interfaceType</exception>
        /// <exception cref="ArgumentException">
        /// The type {interfaceType.Name} is not an interface. - interfaceType
        /// </exception>
        /// <autogeneratedoc/>
        public static bool HasInterface(this Type type, Type interfaceType)
        {
            _ = type ?? throw new ArgumentNullException(nameof(type));
            _ = interfaceType ?? throw new ArgumentNullException(nameof(interfaceType));

            if (!interfaceType.IsInterface)
            {
                throw new ArgumentException($"The type {interfaceType.Name} is not an interface.", nameof(interfaceType));
            }
            if (interfaceType.IsAssignableFrom(type))
            {
                return true;
            }
            if (interfaceType.IsGenericType && type
                                                    .GetInterfaces()
                                                    .Any(p => p.IsGenericType && p.GetGenericTypeDefinition() == interfaceType))
            {
                return true;
            }
            return false;
        }
    }
}