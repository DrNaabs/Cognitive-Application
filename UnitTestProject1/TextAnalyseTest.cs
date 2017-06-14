using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjetGuiguiCSharpGod;

namespace UnitTestProject1
{
    [TestClass]
    public class TextAnalyseTest
    {

     
        /// <summary>
        /// Test the language of the json
        /// </summary>
        [TestMethod]
        public void TestMethodLangage()
        {
            string json = "{\"documents\":[{\"id\":\"1\",\"detectedLanguages\":[{\"name\":\"French\",\"iso6391Name\":\"fr\",\"score\":1}]}],\"errors\":[]}";

            TextAnalyse.LanguageParse(json);
            Assert.IsFalse(TextAnalyse.Language == "English");
            Assert.AreEqual(TextAnalyse.Language,"French");
        }

        /// <summary>
        /// Test the key phrase of the json
        /// </summary>
        [TestMethod]
        public void TestMethodKeyPhrase()
        {
            string json = "{\"documents\":[{\"keyPhrases\":[\"le monde\"],\"id\":\"1\"}],\"errors\":[]}";

            TextAnalyse.KeyPhraseParse(json);
            Assert.AreEqual(TextAnalyse.KeyPhrase[0], "le monde");
            Assert.IsFalse(TextAnalyse.KeyPhrase[0] == "bloublou");
        }

        /// <summary>
        /// Test the sentiment of the json
        /// </summary>
        [TestMethod]
        public void TestMethodSentimentParse()
        {
            string json = "{\"documents\":[{\"score\":0.5,\"id\":\"1\"}],\"errors\":[]}";

            TextAnalyse.SentimentParse(json);
            Assert.AreEqual(TextAnalyse.Sentiment,0.5);
            Assert.IsFalse(TextAnalyse.Sentiment == 0.75);
        }

 
    }

}
