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

        /// <summary>
        /// Changes the field of mood dynamically.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="fieldName">Name of the field.</param>
        /// <returns>The object returned by method</returns>
        /// <exception cref="MoodAnalyserExceptions">
        /// No such field found
        /// or
        /// Mood cannot be empty
        /// </exception>
        public static Object ChangingTheMoodDynamically(string message, string fieldName)
        {
            // Get the type of the class
            Type type = typeof(MoodAnalyserClass);

            // Create an object of class
            object mood = Activator.CreateInstance(type);

            //Get the field and If the field is not found it throws null exception and if message is empty throw exception
            // catch the exception if thrown
            try
            {
                // Get the field by using reflections
                FieldInfo fieldInfo = type.GetField(fieldName);

                // set the field value of a particular field in particular object
                fieldInfo.SetValue(mood, message);

                // Get the method using reflection
                MethodInfo method = type.GetMethod("AnalyseMood");

                // Invoke the method using reflection
                object methodReturn = method.Invoke(mood, null);
                return methodReturn;
            }
            catch (NullReferenceException)
            {
                throw new MoodAnalysisCustomException(MoodAnalysisCustomException.ExceptionType.NO_SUCH_FIELD, "No such field found");
            }
            catch
            {
                throw new MoodAnalysisCustomException(MoodAnalysisCustomException.ExceptionType.NULL_TYPE, "Null mood not accepted");
            }
        }
    }
}
