namespace AnagramsLibTests
{
    using AnagramsLib;
    using NUnit.Framework;
    using System.Collections.Generic;

    [TestFixture]
    public class AnagramsTests
    {

        [Test]
        public void TestGetAnagramHash_ForAWord_ReturnStringWithLowerCharactersOrdered()
        {
            string word =           "mywordtest";
            string expectedResult = "demorsttwy";

            var result = Anagrams.GetAnagramHash(word);

            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [Test]
        public void TestGetAnagramHash_ForAWord_ReturnStringWithUpperAndLowerCharactersOrdered()
        {
            string word = "mywordTest";
            string expectedResult = "demorsttwy";

            var result = Anagrams.GetAnagramHash(word);

            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [Test]
        public void TestBuildAnagramsCollection_ForAListOfAnagramWords_ReturnsOneAnagramCollection()
        {
            var words = new List<string>(new[] { "word", "dwor", "rodw" });
            IList<IList<string>> expectedResult = new List<IList<string>>(new[] { new List<string>(new[] { "word", "dwor", "rodw" }) });

            var result = Anagrams.BuildAnagramsCollection(words);
            Assert.That(result, Is.EqualTo(expectedResult));
        }

    }
}
