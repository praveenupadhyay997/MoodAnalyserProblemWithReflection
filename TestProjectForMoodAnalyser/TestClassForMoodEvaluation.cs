using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoodAnalyserProblem;

namespace TestProjectForMoodAnalyser
{
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
            string actual = moodAnalyserClass.analyseMood();
            //Assert
            Assert.AreEqual(HAPPY_MOOD, actual);
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
            MoodAnalyserClass moodAnalyserClass = new MoodAnalyserClass();
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
            var objectFromFactory = MoodAnalyserFactory.CreateMoodAnalyserObject("MoodAnalyserProblem.MoodAnalyserClass", "MoodAnalyserClass" );
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
                var obj = MoodAnalyserFactory.CreateMoodAnalyserObject("MoodAnalyserProblem.MoodAnalyser", "MoodAnalyserClass");
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
                var objectFromFactory = MoodAnalyserFactory.CreateMoodAnalyserObject("MoodAnalyserProblem.MoodAnalyserClass", "MoodAnalyser");
            }
            //Assert
            catch (MoodAnalysisCustomException customException)
            {
                Assert.AreEqual("No such constructor found", customException.Message);
            }
        
    }
}
