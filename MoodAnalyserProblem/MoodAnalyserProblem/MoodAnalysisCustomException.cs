using System;
using System.Collections.Generic;
using System.Text;

namespace MoodAnalyserProblem
{
    public class MoodAnalysisCustomException : Exception
    {
        /// <summary>
        /// Enumerating two message as constant variables 0-Empty Message and 1-Null Message
        /// </summary>
        public enum ExceptionType
        {
            EMPTY_MESSAGE,
            NULL_MESSAGE, 
            NO_SUCH_CLASS,
            NO_SUCH_CONSTRUCTOR,
            NO_SUCH_METHOD
        }
        public readonly ExceptionType type;

        public MoodAnalysisCustomException(ExceptionType type, string message) : base(message)
        {
            this.type = type;
        }
    }
}
