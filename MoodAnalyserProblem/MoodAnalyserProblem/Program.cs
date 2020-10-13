using System;

namespace MoodAnalyserProblem
{
    class Program
    {
        /// <summary>
        /// Defines the entry point of the application.
        /// </summary>
        /// <param name="args">The arguments.</param>
        static void Main(string[] args)
        {
            MoodAnalyserClass moodAnalyser = new MoodAnalyserClass();
            Console.WriteLine("The mood of your customer is {0}", moodAnalyser.analyseMood("I am sad today"));
            Console.WriteLine("The mood of your customer is {0}", moodAnalyser.analyseMood("I am happy today"));
            Console.ReadKey();
        }
    }
}
