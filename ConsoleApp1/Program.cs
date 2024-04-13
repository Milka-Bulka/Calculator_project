using System;
using System.Reflection;

namespace ConsoleApp1
{
    public class Program
    {
        static void Main(string[] args)
        {
            Assembly SampleAssembly = Assembly.LoadFrom("BinCalc.dll");
            Type[] types = SampleAssembly.GetTypes();
            /* BCalc   BinCalc.BCalc
               <>c     BinCalc.BCalc+<>c */
            foreach (Type type in types)
                Console.WriteLine(type.Name + "\t" + type.FullName);

            Console.WriteLine("\nFields");
            FieldInfo[] ts = types[0].GetFields();
            /* DoBinOperation  BinCalc.BCalc
               Equals  System.Object
               GetHashCode     System.Object
               GetType System.Object
               ToString        System.Object */
            foreach (FieldInfo fi in ts) 
                Console.WriteLine(fi.Name + "\t" + fi.FieldType);

            Console.WriteLine("\nMetods");
            MethodInfo[] ms = types[0].GetMethods();
            /* DoBinOperation  System.Reflection.ParameterInfo[]       System.String
               Equals  System.Reflection.ParameterInfo[]       System.Boolean
               GetHashCode     System.Reflection.ParameterInfo[]       System.Int32
               GetType System.Reflection.ParameterInfo[]       System.Type
               ToString        System.Reflection.ParameterInfo[]       System.String */
            foreach (MethodInfo mi in ms)
                Console.WriteLine(mi.Name + "\t" + mi.DeclaringType);

            Console.WriteLine("\nMetods info");
            foreach (MethodInfo mi in ms)
                Console.WriteLine(mi.Name + "\t" + mi.GetParameters() + "\t" + mi.ReturnType);
        }
    }
}
