using System;
using System.Collections.Generic;
using System.Text;

namespace MoodAnalyserProblem
{
    public class MoodAnalyserClass
    {
        public string message;

        /// <summary>
        /// Initializes a new default instance of the <see cref="MoodAnalyserClass"/> class.
        /// </summary>
        public MoodAnalyserClass()
        {
            this.message = null;
        }

        public MoodAnalyserClass(string message)
        {
            this.message = message.ToUpper();
        }

        /// <summary>
        /// Analyses the mood.
        /// </summary>
        /// <param name="messageRecieved">The message recieved.</param>
        /// <returns></returns>
        public string analyseMood()
        {
            if (this.message.Contains("SAD"))
                return "SAD";
            else if (this.message.Contains("HAPPY") || message.Contains("ANY"))
                return "HAPPY";
            else
                return "NO COMMENTS";
        }
    }
}
