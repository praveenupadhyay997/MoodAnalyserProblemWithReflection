// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Program.cs" company="Bridgelabz">
//   Copyright © 2018 Company
// </copyright>
// <creator Name="Praveen Kumar Upadhyay"/>
// --------------------------------------------------------------------------------------------------------------------
using System;

namespace MoodAnalyserProblem
{
    class Program
    {
        /// <summary>
        /// Defining a global instance type for Mood Analyser Class
        /// </summary>
        public static MoodAnalyserClass moodAnalyser;
        /// <summary>
        /// Defines the entry point of the application.
        /// </summary>
        /// <param name="args">The arguments.</param>
        static void Main(string[] args)
        {

            moodAnalyser = new MoodAnalyserClass("I am in sad mood");
            Console.WriteLine("The mood of your customer is {0}", moodAnalyser.analyseMood());
            moodAnalyser = new MoodAnalyserClass("I am in happy mood");
            Console.WriteLine("The mood of your customer is {0}", moodAnalyser.analyseMood());
            moodAnalyser = new MoodAnalyserClass("I am in any mood");
            Console.WriteLine("The mood of your customer is {0}", moodAnalyser.analyseMood());

            Console.WriteLine("\n ============================================================");
            //Displaying all the metadata using the reflection
            MoodAnalyserReflectionClass.ReflectMoodAnalyser();

            //Creating MoodAnalyserClass object at run time
            MoodAnalyserReflector.CreateMoodAnalyserObject("MoodAnalyserProblem.MoodAnalyserClass", "MoodAnalyserClass", "I am in happy mood today");
            Console.WriteLine("\n ============================================================");
            //Invoking Method using reflections
            var messageBeforeChange = MoodAnalyserReflector.InvokeMethod("MoodAnalyserProblem.MoodAnalyserClass", "MoodAnalyserClass","I am in a happy mood", "analyseMood");
            Console.WriteLine("The mood during initialising is {0}", messageBeforeChange);

            // Calling the changing mood dynamically method to change the mood messages dynamically
            var message =MoodAnalyserReflector.ChangingTheMoodDynamically("I am Sad today", "message");
            Console.WriteLine("The mood after changing it dynamically is {0}",message);
            Console.ReadKey();
        }
    }
}
