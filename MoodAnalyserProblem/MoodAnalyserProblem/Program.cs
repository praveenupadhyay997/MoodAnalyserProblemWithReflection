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
            moodAnalyser = new MoodAnalyserClass(null);
            Console.WriteLine("The mood of your customer is {0}", moodAnalyser.analyseMood());
            Console.ReadKey();
        }
    }
}
