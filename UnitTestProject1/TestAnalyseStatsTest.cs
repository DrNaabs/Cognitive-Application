using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjetGuiguiCSharpGod;
using Moq;

namespace UnitTestProject1
{
  
    [TestClass]
    public class TestAnalyseStatsTest
    {
   

        private TestContext testContextInstance;

    
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }



        [TestMethod]
        public void TestSelectNumberCallDay()
        {
            Mock<TextAnalyseStats> mockCognitiveEmotion = new Mock<TextAnalyseStats>();

            TextAnalyseStats mockObject = mockCognitiveEmotion.Object;
            DateTime date = Convert.ToDateTime("06/09/2016");


            Assert.IsFalse(mockObject.SelectNumberCallDay(date) == 7);
            Assert.IsTrue(mockObject.SelectNumberCallDay(date) == 0);
        }


        [TestMethod]
        public void TestLanguagePercentage()
        {
            Mock<TextAnalyseStats> mockCognitiveEmotion = new Mock<TextAnalyseStats>();

            TextAnalyseStats mockObject = mockCognitiveEmotion.Object;

            Assert.IsFalse(mockObject.SelectEnglishPercentage() == 0);
            Assert.IsFalse(mockObject.SelectFrenchPercentage() == 10);
            Assert.IsTrue(mockObject.SelectSpanishPercentage() == 0);
        }

        [TestMethod]
        public void TestNumberSentiment()
        {
            Mock<TextAnalyseStats> mockCognitiveEmotion = new Mock<TextAnalyseStats>();

            TextAnalyseStats mockObject = mockCognitiveEmotion.Object;

            Assert.IsFalse(mockObject.SelectLowSentiment() == 25);
            Assert.IsFalse(mockObject.SelectMediumSentiment() == 10);
            Assert.IsFalse(mockObject.SelectHighSentiment() == 3);
        }

        [TestMethod]
        public void TestUpdateSentiment()
        {
            Mock<TextAnalyseStats> mockCognitiveEmotion = new Mock<TextAnalyseStats>();

            TextAnalyseStats mockObject = mockCognitiveEmotion.Object;
             Assert.AreEqual(mockObject.UpdateSentiment(0.1),"low");
      
        }


       

            


        }
    }

