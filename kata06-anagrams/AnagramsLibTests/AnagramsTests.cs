namespace AnagramsLibTests
{
    using AnagramsLib;
    using NUnit.Framework;

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

    }
}
