using System;
using System.Collections.Generic;
using System.Text;

namespace MoodAnalyserProblem
{
    public class MoodAnalysisCustomException : Exception
    {
        /// <summary>
        /// Enumerating two message as constant variables 0-Empty Message and 1-Null Message 2-No such Class 3-No Such Constructor
        /// 4-No Such Method
        /// </summary>
        public enum ExceptionType
        {
            EMPTY_MESSAGE,
            NULL_MESSAGE, 
            NO_SUCH_CLASS,
            NO_SUCH_CONSTRUCTOR,
            NO_SUCH_METHOD,
            NO_SUCH_FIELD
        }
        /// <summary>
        /// To store the custom messages
        /// </summary>
        public readonly ExceptionType type;

        /// <summary>
        /// Parameterised Constructor overwriting the base constructor message and reinforcing custom messages
        /// </summary>
        /// <param name="type"></param>
        /// <param name="message"></param>
        public MoodAnalysisCustomException(ExceptionType type, string message) : base(message)
        {
            this.type = type;
        }
    }
}
