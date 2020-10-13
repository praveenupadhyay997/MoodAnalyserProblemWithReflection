using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoodAnalyserProblem;

namespace TestProjectForMoodAnalyser
{
    [TestClass]
    public class TestClassForMoodEvaluation
    {
        public const string SAD_MOOD = "SAD";
        public const string HAPPY_MOOD = "HAPPY";
        [TestMethod]
        public void TestMethodForSadMood()
        {
            //Access
            MoodAnalyserClass moodAnalyserClass = new MoodAnalyserClass();
            //Act
            string actual = moodAnalyserClass.analyseMood("I am in sad mood today");
            //Assert
            Assert.AreEqual(SAD_MOOD, actual);
        }

        [TestMethod]
        public void TestMethodForHappyMood()
        {
            //Access
            MoodAnalyserClass moodAnalyserClass = new MoodAnalyserClass();
            //Act
            string actual = moodAnalyserClass.analyseMood("I am in any mood today");
            //Assert
            Assert.AreEqual(HAPPY_MOOD, actual);
        }
    }
}
