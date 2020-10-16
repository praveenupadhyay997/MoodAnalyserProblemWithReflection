// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MoodAnalyserReflectionClass.cs" company="Bridgelabz">
//   Copyright © 2018 Company
// </copyright>
// <creator Name="Praveen Kumar Upadhyay"/>
// --------------------------------------------------------------------------------------------------------------------
namespace MoodAnalyserProblem
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Reflection;

    public class MoodAnalyserReflectionClass
    {
        /// <summary>
        /// Reflection method to get all the details of MethodAnalyserClass
        /// </summary>
        public static void ReflectMoodAnalyser()
        {
            Type type = Type.GetType("MoodAnalyserProblem.MoodAnalyserClass");

            ///Printing the fullname
            Console.WriteLine("FullName is {0} " ,type.FullName);

            ///Printing the Class name
            Console.WriteLine("Name is {0} " , type.Name);

            ///Getting details of methods of Mood Analyser Class
            MethodInfo[] methodDetails = type.GetMethods();
            Console.WriteLine("Methods present in Method Analyser class");
            foreach (MethodInfo method in methodDetails)
            {
                Console.WriteLine(method.ReturnType.Name + " " + method.Name);
            }

            ///Getting details of properties of Method Analyser Class
            Console.WriteLine("Properties present in Method Analyser class");
            PropertyInfo[] propertyDetails = type.GetProperties();
            foreach (PropertyInfo property in propertyDetails)
            {
                Console.WriteLine("Methods are {0} {1} " , property.PropertyType.Name , " " + property.Name);
            }

            ///Getting details of Constructors of Method Analyser Class
            Console.WriteLine("Constructors present in Method Analyser class");
            ConstructorInfo[] constructorDetails = type.GetConstructors();
            foreach (ConstructorInfo constructor in constructorDetails)
            {
                Console.WriteLine(constructor.ToString());
            }
        }
    }
}
