using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

namespace MoodAnalyserProblem
{
    public class MoodAnalyserFactory
    {
        public static Object CreateMoodAnalyserObject(string className, string constructor)
        {
            //Accessing the type of the Mood Analyser Class
            Type type = typeof(MoodAnalyserClass);

            if (type.Name.Equals(className) || type.FullName.Equals(className))
            {

                if (type.Name.Equals(constructor))
                {
                    return Activator.CreateInstance(type);
                }

                else
                    throw new MoodAnalysisCustomException(MoodAnalysisCustomException.ExceptionType.NO_SUCH_CONSTRUCTOR, "No such constructor found");
            }
            //If the class passed doesnt exist throw custom exception
            else
            {
                throw new MoodAnalysisCustomException(MoodAnalysisCustomException.ExceptionType.NO_SUCH_CLASS, "No such class found");
            }
        }

        public static Object CreateMoodAnalyserParameterizedObject(string className, string constructor, string message)
        {
            // Accessing the type of the Mood Analyser Class
             Type type = typeof(MoodAnalyserClass);
            
            if (type.Name.Equals(className) || type.FullName.Equals(className))
            {
                if (type.Name.Equals(constructor))
                {
                    ConstructorInfo constructorInfo = type.GetConstructor(new Type[] { typeof(string) });
                    return constructorInfo.Invoke(new Object[] { message });
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
    }
}
