using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

namespace MoodAnalyserProblem
{
    public class MoodAnalyserReflector
    {
        /// <summary>
        /// Refactored Code for the default and parameterised constructor both
        /// </summary>
        /// <param name="className"></param>
        /// <param name="constructor"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public static Object CreateMoodAnalyserObject(string className, string constructor, string message)
        {
            //getting the type of MoodAnalyserClass
            Type type = typeof(MoodAnalyserClass);
            //If the class name exists in given assembly
            if (type.Name.Equals(className) || type.FullName.Equals(className))
            {
                //If the constructor passed is correct
                if (type.Name.Equals(constructor))
                {
                    return Activator.CreateInstance(type, message);
                }
                //If the constructor passed doesnt exist then throw error
                else
                    throw new MoodAnalysisCustomException(MoodAnalysisCustomException.ExceptionType.NO_SUCH_CONSTRUCTOR, "No such constructor found");
            }
            //If the class passed doesnt exist throw custom exception
            else
            {
                throw new MoodAnalysisCustomException(MoodAnalysisCustomException.ExceptionType.NO_SUCH_CLASS, "No such class found");
            }
        }
        /// <summary>
        /// To Invoke the analyse mood function or any function of MoodAnalyserClass
        /// </summary>
        /// <param name="className"></param>
        /// <param name="constuctor"></param>
        /// <param name="message"></param>
        /// <param name="methodName"></param>
        /// <returns></returns>
        public static Object InvokeMethod(string className, string constuctor, string message, string methodName)
        {
            //Get the instance of the MoodAnalyserClass and create a constructor
            object moodAnalysis = CreateMoodAnalyserObject(className, constuctor, message);
            Type type = typeof(MoodAnalyserClass);
            try
            {
                //Fetching the method info using reflection
                MethodInfo methodInfo = type.GetMethod(methodName);
                //Invoking the method of Mood Analyser Class
                Object obj = methodInfo.Invoke(moodAnalysis, null);
                return obj;
            }
            catch (NullReferenceException)
            {
                throw new MoodAnalysisCustomException(MoodAnalysisCustomException.ExceptionType.NO_SUCH_METHOD, "No such method found");
            }
        }
    }
}
