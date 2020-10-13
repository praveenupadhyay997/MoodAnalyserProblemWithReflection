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
            if(!string.IsNullOrEmpty(message))
            this.message = message.ToUpper();
        }

        /// <summary>
        /// Analyses the mood.
        /// </summary>
        /// <param name="messageRecieved">The message recieved.</param>
        /// <returns></returns>
        public string analyseMood()
        {
            try
            {
                if (!String.IsNullOrEmpty(message))
                {
                    if (message.ToUpper().Contains("SAD"))
                        return "SAD";
                    else if (message.ToUpper().Contains("HAPPY") || message.ToUpper().Contains("ANY"))
                        return "HAPPY";
                    else
                        return "HAPPY";
                }
                else
                {
                    return "HAPPY";
                }
            }
            catch (NullReferenceException nullException)
            {
                Console.WriteLine(nullException.Message);
                return "HAPPY";
            }

        }
    }
}
