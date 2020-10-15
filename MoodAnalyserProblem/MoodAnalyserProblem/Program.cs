using System;

namespace MoodAnalyserProblem
{
    class Program
    {
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

            // Invoking Method using reflections
            MoodAnalyserReflector.InvokeMethod("MoodAnalyserProblem.MoodAnalyserClass", "MoodAnalyserClass","I am in a happy mood", "analyseMood");

            // Calling the changing mood dynamically method to change the mood messages dynamically
            MoodAnalyserReflector.ChangingTheMoodDynamically("I am Sad today", "message");
            Console.ReadKey();
        }
    }
}
