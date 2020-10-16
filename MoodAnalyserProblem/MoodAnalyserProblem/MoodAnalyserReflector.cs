// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MoodAnalyserReflector.cs" company="Bridgelabz">
//   Copyright © 2018 Company
// </copyright>
// <creator Name="Praveen Kumar Upadhyay"/>
// --------------------------------------------------------------------------------------------------------------------
namespace MoodAnalyserProblem
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Reflection;

    public class MoodAnalyserReflector
    {
        /// <summary>
        /// Refactored Code for the default and parameterised constructor both
        /// </summary>
        /// <param name="className"></param>
        /// <param name="constructorName"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public static Object CreateMoodAnalyserObject(string className, string constructorName, string message)
        {
            //Accessing the type of MoodAnalyserClass using the reflection Type function. type will now contain all the metadata of the MoodAnalyserClass
            Type type = typeof(MoodAnalyserClass);
            //If the class name exists in given assembly
            if (type.Name.Equals(className) || type.FullName.Equals(className))
            {
                //If the constructor name passed is correct and matches with the name of the mood analyser class
                if (type.Name.Equals(constructorName))
                {
                    //Creates instance of class by calling the parameterised constructor for some non-empty message passed and defaul constructor in case of null message
                    return Activator.CreateInstance(type, message);
                }
                //If the constructor passed doesnt exist then throw custom exception of constructor not found
                else
                    throw new MoodAnalysisCustomException(MoodAnalysisCustomException.ExceptionType.NO_SUCH_CONSTRUCTOR, "No such constructor found");
            }
            else
            {
                //If the class passed doesnt exist throw custom exception of class not found is thrown
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
                //Fetching the method info using reflection and accessing it's metadata
                MethodInfo methodInfo = type.GetMethod(methodName);
                //Invoking the method of Mood Analyser Class
                Object obj = methodInfo.Invoke(moodAnalysis, null);
                //Return the obj instance created in case correct class name and constructor name is passed
                return obj;
            }
            catch (NullReferenceException)
            {
                //Catching the custom exception in case the methodinfo returns a null value
                throw new MoodAnalysisCustomException(MoodAnalysisCustomException.ExceptionType.NO_SUCH_METHOD, "No such method found");
            }
        }

        /// <summary>
        /// Changes the value of mood message dynamically.
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
            // Getting the metadata of the class
            Type type = typeof(MoodAnalyserClass);

            // Creating an instance of the mood analyser class
            object mood = Activator.CreateInstance(type);

            //Get the field and If the field is not found it throws null exception and if message is empty throw exception
            try
            {
                // Get the field by using reflections
                FieldInfo fieldInfo = type.GetField(fieldName);

                // Initialise the value of a message field in mood object
                fieldInfo.SetValue(mood, message);

                // Accessing the method details using reflection call
                MethodInfo method = type.GetMethod("analyseMood");

                // Calling the method using reflection for passing the null message to analyse mood
                object methodReturn = method.Invoke(mood, null);
                return methodReturn;
            }
            catch (NullReferenceException)
            {
                //Catching the custom exception in case the field is not found and the object fieldInfo return gets null
                throw new MoodAnalysisCustomException(MoodAnalysisCustomException.ExceptionType.NO_SUCH_FIELD, "No such field found");
            }
            catch
            {
                //Catching the null exception in case the message accessed in the setvalue field is null and compiler throws a null exception
                throw new MoodAnalysisCustomException(MoodAnalysisCustomException.ExceptionType.NULL_MESSAGE, "Mood should not be NULL");
            }
        }
    }
}
