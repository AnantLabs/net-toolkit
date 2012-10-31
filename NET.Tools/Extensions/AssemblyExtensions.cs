using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.IO;

namespace NET.Tools
{
    /// \addtogroup extensions
    /// @{

    /// <summary>
    /// Extensions for Assembly
    /// </summary>
    public static class AssemblyExtensions
    {
        public static FileInfo GetFileName(this Assembly asm)
        {
            return new FileInfo(asm.Location);
        }

        public static PropertyInfo[] GetAllProperties(this Assembly asm, BindingFlags binding)
        {
            List<PropertyInfo> lst = new List<PropertyInfo>();
            foreach (Type t in asm.GetTypes())
                foreach (PropertyInfo pi in t.GetProperties(binding))
                    lst.Add(pi);

            return lst.ToArray();
        }

        public static MethodInfo[] GetAllMethods(this Assembly asm, BindingFlags binding)
        {
            List<MethodInfo> lst = new List<MethodInfo>();
            foreach (Type t in asm.GetTypes())
                foreach (MethodInfo mi in t.GetMethods(binding))
                    lst.Add(mi);

            return lst.ToArray();
        }

        public static MemberInfo[] GetAllMembers(this Assembly asm, BindingFlags binding)
        {
            List<MemberInfo> lst = new List<MemberInfo>();
            foreach (Type t in asm.GetTypes())
                foreach (MemberInfo mi in t.GetMembers(binding))
                    lst.Add(mi);

            return lst.ToArray();
        }

        public static FieldInfo[] GetAllFields(this Assembly asm, BindingFlags binding)
        {
            List<FieldInfo> lst = new List<FieldInfo>();
            foreach (Type t in asm.GetTypes())
                foreach (FieldInfo mi in t.GetFields(binding))
                    lst.Add(mi);

            return lst.ToArray();
        }

        public static EventInfo[] GetAllEvents(this Assembly asm, BindingFlags binding)
        {
            List<EventInfo> lst = new List<EventInfo>();
            foreach (Type t in asm.GetTypes())
                foreach (EventInfo mi in t.GetEvents(binding))
                    lst.Add(mi);

            return lst.ToArray();
        }

        /// <summary>
        /// Gets all types in assembly
        /// </summary>
        /// <param name="asm"></param>
        /// <param name="type">Type description</param>
        /// <param name="link">Link for type description parameter (OR / AND)</param>
        /// <returns>Array of found types</returns>
        public static Type[] GetTypes(this Assembly asm, AssemblyType type, AssemblyLink link)
        {
            List<Type> lst = new List<Type>();
            foreach (Type t in asm.GetTypes())
            {
                if ((type & AssemblyType.Interface) != 0)
                    if (t.IsInterface)
                    { //Is condition?
                        if (link == AssemblyLink.OR) 
                        { //Only OR
                            if (!lst.Contains(t))
                                lst.Add(t);
                        }
                    }
                    else //No? 
                        if (link == AssemblyLink.AND) //Only AND
                            continue; //Goon

                if ((type & AssemblyType.Class) != 0)
                    if (t.IsClass)
                    { //Is condition?
                        if (link == AssemblyLink.OR)
                        { //Only OR
                            if (!lst.Contains(t))
                                lst.Add(t);
                        }
                    }
                    else //No? 
                        if (link == AssemblyLink.AND) //Only AND
                            continue; //Goon

                if ((type & AssemblyType.Enumeration) != 0)
                    if (t.IsEnum)
                    { //Is condition?
                        if (link == AssemblyLink.OR)
                        { //Only OR
                            if (!lst.Contains(t))
                                lst.Add(t);
                        }
                    }
                    else //No? 
                        if (link == AssemblyLink.AND) //Only AND
                            continue; //Goon

                if ((type & AssemblyType.Abstract) != 0)
                    if (t.IsAbstract)
                    { //Is condition?
                        if (link == AssemblyLink.OR)
                        { //Only OR
                            if (!lst.Contains(t))
                                lst.Add(t);
                        }
                    }
                    else //No? 
                        if (link == AssemblyLink.AND) //Only AND
                            continue; //Goon

                if ((type & AssemblyType.Nested) != 0)
                    if (t.IsNested)
                    { //Is condition?
                        if (link == AssemblyLink.OR)
                        { //Only OR
                            if (!lst.Contains(t))
                                lst.Add(t);
                        }
                    }
                    else //No? 
                        if (link == AssemblyLink.AND) //Only AND
                            continue; //Goon

                if ((type & AssemblyType.NotPublic) != 0)
                    if (t.IsNotPublic)
                    { //Is condition?
                        if (link == AssemblyLink.OR)
                        { //Only OR
                            if (!lst.Contains(t))
                                lst.Add(t);
                        }
                    }
                    else //No? 
                        if (link == AssemblyLink.AND) //Only AND
                            continue; //Goon

                if ((type & AssemblyType.Public) != 0)
                    if (t.IsPublic)
                    { //Is condition?
                        if (link == AssemblyLink.OR)
                        { //Only OR
                            if (!lst.Contains(t))
                                lst.Add(t);
                        }
                    }
                    else //No? 
                        if (link == AssemblyLink.AND) //Only AND
                            continue; //Goon

                if ((type & AssemblyType.Sealed) != 0)
                    if (t.IsSealed)
                    { //Is condition?
                        if (link == AssemblyLink.OR)
                        { //Only OR
                            if (!lst.Contains(t))
                                lst.Add(t);
                        }
                    }
                    else //No? 
                        if (link == AssemblyLink.AND) //Only AND
                            continue; //Goon

                if ((type & AssemblyType.Primitive) != 0)
                    if (t.IsPrimitive)
                    { //Is condition?
                        if (link == AssemblyLink.OR)
                        { //Only OR
                            if (!lst.Contains(t))
                                lst.Add(t);
                        }
                    }
                    else //No? 
                        if (link == AssemblyLink.AND) //Only AND
                            continue; //Goon

                if ((type & AssemblyType.Pointer) != 0)
                    if (t.IsPointer)
                    { //Is condition?
                        if (link == AssemblyLink.OR)
                        { //Only OR
                            if (!lst.Contains(t))
                                lst.Add(t);
                        }
                    }
                    else //No? 
                        if (link == AssemblyLink.AND) //Only AND
                            continue; //Goon

                if ((type & AssemblyType.Serializable) != 0)
                    if (t.IsSerializable)
                    { //Is condition?
                        if (link == AssemblyLink.OR)
                        { //Only OR
                            if (!lst.Contains(t))
                                lst.Add(t);
                        }
                    }
                    else //No? 
                        if (link == AssemblyLink.AND) //Only AND
                            continue; //Goon

                if ((type & AssemblyType.ValueType) != 0)
                    if (t.IsValueType)
                    { //Is condition?
                        if (link == AssemblyLink.OR)
                        { //Only OR
                            if (!lst.Contains(t))
                                lst.Add(t);
                        }
                    }
                    else //No? 
                        if (link == AssemblyLink.AND) //Only AND
                            continue; //Goon

                if ((type & AssemblyType.Visible) != 0)
                    if (t.IsVisible)
                    { //Is condition?
                        if (link == AssemblyLink.OR)
                        { //Only OR
                            if (!lst.Contains(t))
                                lst.Add(t);
                        }
                    }
                    else //No? 
                        if (link == AssemblyLink.AND) //Only AND
                            continue; //Goon

                if ((type & AssemblyType.MarshalByRef) != 0)
                    if (t.IsMarshalByRef)
                    { //Is condition?
                        if (link == AssemblyLink.OR)
                        { //Only OR
                            if (!lst.Contains(t))
                                lst.Add(t);
                        }
                    }
                    else //No? 
                        if (link == AssemblyLink.AND) //Only AND
                            continue; //Goon

                if ((type & AssemblyType.GenericType) != 0)
                    if (t.IsGenericType)
                    { //Is condition?
                        if (link == AssemblyLink.OR)
                        { //Only OR
                            if (!lst.Contains(t))
                                lst.Add(t);
                        }
                    }
                    else //No? 
                        if (link == AssemblyLink.AND) //Only AND
                            continue; //Goon

                if ((type & AssemblyType.Imported) != 0)
                    if (t.IsImport)
                    { //Is condition?
                        if (link == AssemblyLink.OR)
                        { //Only OR
                            if (!lst.Contains(t))
                                lst.Add(t);
                        }
                    }
                    else //No? 
                        if (link == AssemblyLink.AND) //Only AND
                            continue; //Goon

                if ((type & AssemblyType.COMObject) != 0)
                    if (t.IsCOMObject)
                    { //Is condition?
                        if (link == AssemblyLink.OR)
                        { //Only OR
                            if (!lst.Contains(t))
                                lst.Add(t);
                        }
                    }
                    else //No? 
                        if (link == AssemblyLink.AND) //Only AND
                            continue; //Goon

                if ((type & AssemblyType.ByRef) != 0)
                    if (t.IsByRef)
                    { //Is condition?
                        if (link == AssemblyLink.OR)
                        { //Only OR
                            if (!lst.Contains(t))
                                lst.Add(t);
                        }
                    }
                    else //No? 
                        if (link == AssemblyLink.AND) //Only AND
                            continue; //Goon

                if ((type & AssemblyType.AutoClass) != 0)
                    if (t.IsAutoClass)
                    { //Is condition?
                        if (link == AssemblyLink.OR)
                        { //Only OR
                            if (!lst.Contains(t))
                                lst.Add(t);
                        }
                    }
                    else //No? 
                        if (link == AssemblyLink.AND) //Only AND
                            continue; //Goon

                if ((type & AssemblyType.AutoLayout) != 0)
                    if (t.IsAutoLayout)
                    { //Is condition?
                        if (link == AssemblyLink.OR)
                        { //Only OR
                            if (!lst.Contains(t))
                                lst.Add(t);
                        }
                    }
                    else //No? 
                        if (link == AssemblyLink.AND) //Only AND
                            continue; //Goon

                if ((type & AssemblyType.AnsiClass) != 0)
                    if (t.IsAnsiClass)
                    { //Is condition?
                        if (link == AssemblyLink.OR)
                        { //Only OR
                            if (!lst.Contains(t))
                                lst.Add(t);
                        }
                    }
                    else //No? 
                        if (link == AssemblyLink.AND) //Only AND
                            continue; //Goon

                if ((type & AssemblyType.Array) != 0)
                    if (t.IsArray)
                    { //Is condition?
                        if (link == AssemblyLink.OR)
                        { //Only OR
                            if (!lst.Contains(t))
                                lst.Add(t);
                        }
                    }
                    else //No? 
                        if (link == AssemblyLink.AND) //Only AND
                            continue; //Goon

                //Last action for AND
                if (link == AssemblyLink.AND)
                    if (!lst.Contains(t)) //Add
                        lst.Add(t);
            }

            return lst.ToArray();
        }

        /// <summary>
        /// Gets all types in assembly with OR link
        /// </summary>
        /// <param name="asm"></param>
        /// <param name="type">Type description</param>
        /// <returns>Array of found types</returns>
        public static Type[] GetTypes(this Assembly asm, AssemblyType type)
        {
            return GetTypes(asm, type, AssemblyLink.OR);
        }
    }
    /// @}

    /// <summary>
    /// \addtogroup enums
    /// @{
    /// </summary>
    public enum AssemblyType : int
    {
        /// <summary>
        /// Search enumerations
        /// </summary>
        Enumeration = 1,
        /// <summary>
        /// Search classes
        /// </summary>
        Class = 2,
        /// <summary>
        /// Search interfaces
        /// </summary>
        Interface = 4,
        /// <summary>
        /// Search abstract classes
        /// </summary>
        Abstract = 8,
        /// <summary>
        /// Search public classes / interfaces / structs
        /// </summary>
        Public = 16,
        /// <summary>
        /// Search not public classes / interfaces / structs
        /// </summary>
        NotPublic = 32,
        /// <summary>
        /// Search nested classes / interfaces / structs
        /// </summary>
        Nested = 64, 
        /// <summary>
        /// Search sealed classes / structs
        /// </summary>
        Sealed = 128,
        /// <summary>
        /// Search pointer
        /// </summary>
        Pointer = 256,
        /// <summary>
        /// Search primitives
        /// </summary>
        Primitive = 512,
        /// <summary>
        /// Search serializable classes / structs
        /// </summary>
        Serializable = 1024,
        /// <summary>
        /// Search value types
        /// </summary>
        ValueType = 1024 * 2,
        /// <summary>
        /// Search visible classes / interfaces / structs
        /// </summary>
        Visible = 1024 * 4,
        /// <summary>
        /// Search classes / structs that inherited from MarshalByRef class
        /// </summary>
        MarshalByRef = 1024 * 8,
        /// <summary>
        /// Search generic types
        /// </summary>
        GenericType = 1024 * 16,
        /// <summary>
        /// Search imported
        /// </summary>
        Imported = 1024 * 32,
        /// <summary>
        /// Search com objects
        /// </summary>
        COMObject = 1024 * 64,
        /// <summary>
        /// Search ref by
        /// </summary>
        ByRef = 1024 * 128,
        /// <summary>
        /// Search auto classes
        /// </summary>
        AutoClass = 1024 * 256,
        /// <summary>
        /// Search auto layout
        /// </summary>
        AutoLayout = 1024 * 512,
        /// <summary>
        /// Search ansi classes
        /// </summary>
        AnsiClass = 1024 * 1024,
        /// <summary>
        /// Search arrays
        /// </summary>
        Array = 1024 * 1024 * 2
    }

    /// <summary>
    /// The link of assembly type informations
    /// </summary>
    public enum AssemblyLink
    {
        /// <summary>
        /// OR-Link
        /// </summary>
        OR,
        /// <summary>
        /// AND-Link
        /// </summary>
        AND
    }
    /// @}
}
