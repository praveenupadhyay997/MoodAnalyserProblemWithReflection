namespace TestProjectForMoodAnalyser
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using MoodAnalyserProblem;

    [TestClass]
    public class TestClassForMoodEvaluation
    {
        public const string SAD_MOOD = "SAD";
        public const string HAPPY_MOOD = "HAPPY";
        /// <summary>
        /// Checking for sad for sad mood
        /// </summary>
        [TestMethod]
        public void TestMethodForSadMood()
        {
            //Access
            MoodAnalyserClass moodAnalyserClass = new MoodAnalyserClass("I am in sad mood today");
            //Act
            string actual = moodAnalyserClass.analyseMood();
            //Assert
            Assert.AreEqual(SAD_MOOD, actual);
        }
        ///
        [TestMethod]
        public void TestMethodForHappyMood()
        {
            //Access
            MoodAnalyserClass moodAnalyserClass = new MoodAnalyserClass("I am in any mood today");
            //Act
            string actual = moodAnalyserClass.analyseMood();
            //Assert
            Assert.AreEqual(HAPPY_MOOD, actual);
        }
        /// <summary>
        /// Checking For Happy Mood for null Message
        /// </summary>
        [TestMethod]
        public void TestMethodForHappyMoodForNull()
        {
            //Access
            MoodAnalyserClass moodAnalyserClass = new MoodAnalyserClass(null);
            //Act
            try
            {
                string actual = moodAnalyserClass.analyseMood();
            }
            catch(MoodAnalysisCustomException exception)
            {
                //Assert
                Assert.AreEqual("Mood should not be NULL", exception.Message);
            }            
        }
        /// <summary>
        /// Passes Null message and returns Mood is not NULL using Custom Exception Class
        /// </summary>
        [TestMethod]
        public void Given_NullMood_UsingMoodAnalysisCustomException_ExpectingNull()
        {
            MoodAnalyserClass moodAnalyserClass = new MoodAnalyserClass(null);
            try
            {
                //Act
                string actual = moodAnalyserClass.analyseMood();
            }
            catch (MoodAnalysisCustomException exception)
            {
                //Assert
                Assert.AreEqual("Mood should not be NULL", exception.Message);
            }
        }
        /// <summary>
        /// Passes Empty message and returns Mood is not EMPTY using Custom Exception Class
        /// </summary>
        [TestMethod]
        public void Given_EmptyMood_UsingMoodAnalysisCustomException_ExpectingEmpty()
        {
            MoodAnalyserClass moodAnalyserClass = new MoodAnalyserClass("");
            try
            {
                //Act
                string actual = moodAnalyserClass.analyseMood();
            }
            catch (MoodAnalysisCustomException exception)
            {
                //Assert
                Assert.AreEqual("Mood should not be EMPTY", exception.Message);
            }
        }
        /// <summary>
        /// Test Case 4.1 to match both class name and constructor name
        /// </summary>
        [TestMethod]
        public void CreateObjectOfMoodAnalyserClass()
        {
            //Arrange
            MoodAnalyserClass moodAnalyserClass = new MoodAnalyserClass();
            //Act
            var objectFromFactory = MoodAnalyserReflector.CreateMoodAnalyserObject("MoodAnalyserProblem.MoodAnalyserClass", "MoodAnalyserClass", null);
            //Assert
            objectFromFactory.Equals(moodAnalyserClass);

        }
        /// <summary>
        /// Test Case 4.2 To return exception when wrong class name is passed
        /// </summary>
        [TestMethod]
        public void CreateObjectOfMoodAnalyserClassWithWrongClassName()
        {
            //Arrange
            MoodAnalyserClass moodAnalyserClass = new MoodAnalyserClass();
            //Act
            try
            {
                var obj = MoodAnalyserReflector.CreateMoodAnalyserObject("MoodAnalyserProblem.MoodAnalyser", "MoodAnalyserClass", null);
            }
            //Assert
            catch (MoodAnalysisCustomException customException)
            {
                Assert.AreEqual("No such class found", customException.Message);
            }
        }

        /// <summary>
        /// Test Case 4.3 To return exception for wrong constructor name
        /// </summary>
        [TestMethod]
        public void CreateObjectOfMoodAnalyserClassWithWrongConstructor()
        {
            //Arrange
            MoodAnalyserClass moodAnalyserClass = new MoodAnalyserClass();
            //Act
            try
            {
                var objectFromFactory = MoodAnalyserReflector.CreateMoodAnalyserObject("MoodAnalyserProblem.MoodAnalyserClass", "MoodAnalyser", null);
            }
            //Assert
            catch (MoodAnalysisCustomException customException)
            {
                Assert.AreEqual("No such constructor found", customException.Message);
            }

        }
        /// <summary>
        /// TC 5.1 When the right class name is passed, it should return object of mood analyser class
        /// </summary>
        [TestMethod]
        public void CreateParameterizedObjectOfMoodAnalyserClass()
        {
            //Arrange
            MoodAnalyserClass moodAnalyser= new MoodAnalyserClass();
            //Act
            var obj = MoodAnalyserReflector.CreateMoodAnalyserObject("MoodAnalyserProblem.MoodAnalyserClass", "MoodAnalyserClass", "I am in happy mood today");
            //Assert
            obj.Equals(moodAnalyser);
        }

        /// <summary>
        /// TC 5.2 When a wrong class name is passed then throw exception
        /// </summary>
        [TestMethod]
        public void CreateParameterizedObjectOfMoodAnalyseInvalidClassName()
        {
            //Arrange
            MoodAnalyserClass moodAnalyser = new MoodAnalyserClass();
            //Act
            try
            {
                var obj = MoodAnalyserReflector.CreateMoodAnalyserObject("MoodAnalyserProblem.MoodAnalyser", "MoodAnalyserClass", "I am in happy mood today");
            }
            //Assert
            catch (MoodAnalysisCustomException exception)
            {
                Assert.AreEqual("No such class found", exception.Message);
            }
        }

        /// <summary>
        /// TC 5.3 When a erong constructor name is passed then throw an exception
        /// </summary>
        [TestMethod]
        public void CreateParameterizedObjectOfMoodAnalyseInvalidConstructor()
        {
            //Arrange
            MoodAnalyserClass moodAnalyser = new MoodAnalyserClass();
            //Act
            try
            {
                var obj = MoodAnalyserReflector.CreateMoodAnalyserObject("MoodAnalyserProblem.MoodAnalyserClass", "MoodAnalyser", "I am in a happy mood today");
            }
            //Assert
            catch (MoodAnalysisCustomException exception)
            {
                Assert.AreEqual("No such constructor found", exception.Message);
            }
        }

        /// <summary>
        /// TC 6.1 When we give right class name, constructor name and message passed as happy mood and valid method name then should return HAPPY
        /// </summary>
        [TestMethod]
        public void InvokeMethodOfMoodAnalyser()
        {
            //Arrange
            MoodAnalyserClass moodAnalyser = new MoodAnalyserClass("I am in happy mood today");
            //Act
            object actual = MoodAnalyserReflector.InvokeMethod("MoodAnalyserProblem.MoodAnalyserClass", "MoodAnalyserClass", "I am in happy mood today", "analyseMood");
            //Assert
            Assert.AreEqual("HAPPY", actual);
        }

        /// <summary>
        /// TC 6.2 When we give right class name, constructor name and message passed as happy mood and valid method name then should throw exception 
        /// </summary>
        [TestMethod]
        public void InvokeMethodOfMoodAnalyserInvalid()
        {
            //Act
            try
            {
                MoodAnalyserClass moodAnalyser = new MoodAnalyserClass("I am in happy mood today");
                object expected = moodAnalyser.analyseMood();
                object actual = MoodAnalyserReflector.InvokeMethod("MoodAnalyserProblem.MoodAnalyserClass", "MoodAnalyserClass", "I am in happy mood today", "InvalidMethod");
            }
            //Assert
            catch (MoodAnalysisCustomException exception)
            {
                Assert.AreEqual("No such method found", exception.Message);
            }
        }

        /// <summary>
        /// TC 6.3 When we give right class name, constructor name and message passed as null and valid method name then should throw exception 
        /// </summary>
        [TestMethod]
        public void InvokeMethodOfMoodAnalyserNullMessage()
        {
            //Act
            try
            {
                MoodAnalyserClass moodAnalyser = new MoodAnalyserClass();
                object expected = moodAnalyser.analyseMood();
                object actual = MoodAnalyserReflector.InvokeMethod("MoodAnalyserProblem.MoodAnalyserClass", "MoodAnalyserClass", null, "InvalidMethod");
            }
            //Assert
            catch (MoodAnalysisCustomException exception)
            {
                Assert.AreEqual("Mood should not be NULL", exception.Message);
            }
        }

        /// <summary>
        /// TC 7.1 When given proper fieldName and a mood message for happy mood then should return HAPPY
        /// </summary>
        [TestMethod]
        public void ChangingTheMoodDynamicallyForValidFieldName()
        {
            // ACT
            object actual = MoodAnalyserReflector.ChangingTheMoodDynamically("I am happy today", "message");

            // Assert
            Assert.AreEqual("HAPPY", actual);
        }

        /// <summary>
        ///  TC 7.2 When given wrong fieldName and a happy mood message then should throw exception
        /// </summary>
        [TestMethod]
        public void ChangingTheMoodDynamicallyInCaseOfInvalidFieldName()
        {
            try
            {
                // ACT
                object actual = MoodAnalyserReflector.ChangingTheMoodDynamically("I am in happy mood today", "InvalidField");
            }
            catch (MoodAnalysisCustomException exception)
            {
                // Assert
                Assert.AreEqual("No such field found", exception.Message);
            }
        }

        /// <summary>
        /// TC 7.3 When given correct fieldName and passing a null mood message then throw error that Mood should not be NULL
        /// </summary>
        [TestMethod]
        public void ChangingTheMoodDynamicallyWhenNullMoodPassed()
        {
            try
            {
                // ACT
                object actual = MoodAnalyserReflector.ChangingTheMoodDynamically(null, "message");
            }
            catch (MoodAnalysisCustomException exception)
            {
                // Assert
                Assert.AreEqual("Mood should not be NULL", exception.Message);
            }
        }
    }
}
