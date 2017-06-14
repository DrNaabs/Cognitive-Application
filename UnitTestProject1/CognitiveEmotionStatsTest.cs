using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjetGuiguiCSharpGod;
using Moq;
using System.Linq;

namespace UnitTestProject1
{
   
    [TestClass]
    public class CognitiveEmotionStatsTest
    {
        CognitiveEmotionStats cognitiveEmotionStats { get; set; }


        [TestInitialize]
        public void TestInit()
        {
            cognitiveEmotionStats = new CognitiveEmotionStats();

        }

        /// <summary>
        /// Test the number of call for a chosen date
        /// </summary>
        [TestMethod]
        public void TestCallPerDay()
        {
            Mock<CognitiveEmotionStats> mockCognitiveEmotion = new Mock<CognitiveEmotionStats>();

            CognitiveEmotionStats mockObject = mockCognitiveEmotion.Object;
            DateTime date = Convert.ToDateTime("06/08/2016");


            Assert.IsFalse(mockObject.CallPerDay(date) == 7);
            Assert.IsTrue(mockObject.CallPerDay(date) == 0);
        }

        /// <summary>
        /// Test the number of Emotion face
        /// </summary>
        [TestMethod]
        public void TestNumberEmotionFace()
        {
            Mock<CognitiveEmotionStats> mockCognitiveEmotion = new Mock<CognitiveEmotionStats>();

            CognitiveEmotionStats mockObject = mockCognitiveEmotion.Object;



            Assert.AreEqual(mockObject.NumberEmotionFace("neutral"), 1);
            Assert.AreEqual(mockObject.NumberEmotionFace("anger"), 0);

        }

        /// <summary>
        /// Test the average of face per call
        /// </summary>
        [TestMethod]
        public void TestFacePerCall()
        {
            Mock<CognitiveEmotionStats> mockCognitiveEmotion = new Mock<CognitiveEmotionStats>();

            CognitiveEmotionStats mockObject = mockCognitiveEmotion.Object;



            Assert.AreEqual(mockObject.FacePerCall(),2);
            Assert.AreNotEqual(mockObject.FacePerCall(), 0);


        }


        /// <summary>
        /// Test the Highest value and check if it's the good one in the end
        /// </summary>
        [TestMethod]
        public void TestEmotion()
        {
            EmotionResult emotionResult = new EmotionResult();
            emotionResult.scores = new Dictionary<string, double>();
            emotionResult.scores.Add("anger", 0);
            emotionResult.scores.Add("contempt", 0);
            emotionResult.scores.Add("disgust", 0);
            emotionResult.scores.Add("fear", 0);
            emotionResult.scores.Add("happiness", 1);
            emotionResult.scores.Add("neutral", 0);
            emotionResult.scores.Add("sadness", 0);
            emotionResult.scores.Add("surprise", 0);

            var highestValue = emotionResult.scores.OrderByDescending(x => x.Value).First();
            Assert.AreEqual(highestValue.Key, "happiness");
            Assert.AreNotEqual(highestValue.Key, "anger");
        }
    }
}
