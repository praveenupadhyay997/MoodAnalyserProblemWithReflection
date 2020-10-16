// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MoodAnalyserProblem.cs" company="Bridgelabz">
//   Copyright © 2018 Company
// </copyright>
// <creator Name="Praveen Kumar Upadhyay"/>
// --------------------------------------------------------------------------------------------------------------------
namespace MoodAnalyserProblem
{
    using System;
    using System.Collections.Generic;
    using System.Text;

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

        /// <summary>
        /// Parameterised constructor defined to create instance of the Mood Analyser Class initialising member field message
        /// </summary>
        /// <param name="message"></param>
        public MoodAnalyserClass(string message)
        {
            this.message = message;
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
                //Initially rulling out the case of null or empty message by string function
                if (!String.IsNullOrEmpty(message))
                {
                    //Matching for cases like sad, happy or any mood inside the not null or empty domain
                    if (message.ToUpper().Contains("SAD"))
                        return "SAD";
                    else if (message.ToUpper().Contains("HAPPY") || message.ToUpper().Contains("ANY"))
                        return "HAPPY";
                    else
                        return "HAPPY";
                }
                //In case the message is empty throw a custom exception stating empty mood
                else if (this.message.Equals(string.Empty))
                {
                    throw new MoodAnalysisCustomException(MoodAnalysisCustomException.ExceptionType.EMPTY_MESSAGE, "Mood should not be EMPTY");
                }
                //Identify the null message error for the message passed as null
                else
                    throw new NullReferenceException();

            }
            //Catching the null reference exception
            catch (NullReferenceException)
            {
                throw new MoodAnalysisCustomException(MoodAnalysisCustomException.ExceptionType.NULL_MESSAGE, "Mood should not be NULL");
            }
            //Returning the custom exceptions caught in above if else if ladder
            catch(MoodAnalysisCustomException exception)
            {
                return exception.Message;
            }

        }
    }
}

