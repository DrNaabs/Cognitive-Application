using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjetGuiguiCSharpGod;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject1
{
    [TestClass]
    public class CognitiveEmotionTest
    {
    
        /// <summary>
        /// Test if we get the same ByteArray with the method and in the test
        /// </summary>
        [TestMethod]
        public void TestGetImageAsByteArray()
        {

            var imageFilePath = @"..\..\..\Ressources\index.jpg";

            FileStream fileStream = new FileStream(imageFilePath, FileMode.Open, FileAccess.Read);
            BinaryReader binaryReader = new BinaryReader(fileStream);
            var result = binaryReader.ReadBytes((int)fileStream.Length);
            var resultString = Encoding.UTF8.GetString(result);

            var test2 = CognitiveEmotion.GetImageAsByteArray(imageFilePath);
            var resultString2 = Encoding.UTF8.GetString(test2);

            Assert.AreEqual(resultString, resultString2);

        }

        /// <summary>
        /// Test if the image contain a face or not
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task TestMakeRequest()
        {
            
            string result = await CognitiveEmotion.MakeRequest(@"..\..\..\Ressources\index.jpg");
            Assert.AreEqual(result, "False");

            string result2 =await CognitiveEmotion.MakeRequest(@"..\..\..\Ressources\cognitive.png");
            Assert.AreEqual(result2, "NoFace");
        }


      
    }
}
