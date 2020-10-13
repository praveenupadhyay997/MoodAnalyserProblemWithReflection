using System;
using System.Collections.Generic;
using System.Text;

namespace MoodAnalyserProblem
{
    class MoodAnalyserClass
    {
        public static string message;

        /// <summary>
        /// Analyses the mood.
        /// </summary>
        /// <param name="messageRecieved">The message recieved.</param>
        /// <returns></returns>
        public string analyseMood(string messageRecieved)
        {
            message = messageRecieved.ToUpper();
            if (message.Contains("SAD"))
                return "SAD";
            else if (message.Contains("HAPPY"))
                return "HAPPY";
            else
                return "NO COMMENTS";
        }
    }
}
