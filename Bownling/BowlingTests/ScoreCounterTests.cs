namespace BowlingTests
{
    using BowlingApp;
    using NUnit.Framework;

    public class ScoreCounterTests
    {
        [Test]
        public void AddThrowOf5AndGetScoreOf5()
        {
            ScoreCounter counter = new ScoreCounter();

            counter.AddThrow(5);
            int score = counter.GetScore();

            Assert.That(score == 5);
        }

        [Test]
        public void AddThrowsOf5And5AndGetScoreOf10()
        {
            ScoreCounter counter = new ScoreCounter();

            counter.AddThrow(5);
            counter.AddThrow(5);
            int score = counter.GetScore();

            Assert.That(score == 10);
        }

        [Test]
        public void AddThrowOf5ThenResetScoreAndGetScoreOf0()
        {
            ScoreCounter counter = new ScoreCounter();

            counter.AddThrow(5);
            int score = counter.GetScore();

            Assert.That(score == 5);

            counter.ResetScore();

            score = counter.GetScore();

            Assert.That(score == 0);
        }

        [Test]
        public void AddThrowsOf4Then6then5AndGetScore20()
        {
            ScoreCounter counter = new ScoreCounter();

            counter.AddThrow(4);
            counter.AddThrow(6);
            counter.AddThrow(5);

            int score = counter.GetScore();

            Assert.That(score == 20);
        }

        [Test]
        public void AddThrowsOf5Then5Then5Then5Then5AndGetScore35()
        {
            ScoreCounter counter = new ScoreCounter();

            counter.AddThrow(5);
            counter.AddThrow(5);
            counter.AddThrow(5);
            counter.AddThrow(5);
            counter.AddThrow(5);

            int score = counter.GetScore();

            Assert.That(score == 35);
        }

        [Test]
        public void AddThrowsOf3Then6then4Then2AndGetScore15()
        {
            ScoreCounter counter = new ScoreCounter();

            counter.AddThrow(3);
            counter.AddThrow(6);
            counter.AddThrow(4);
            counter.AddThrow(2);

            int score = counter.GetScore();

            Assert.That(score == 15);
        }

        [Test]
        public void AddThrowsOf10Then3then5AndGetScore26()
        {
            ScoreCounter counter = new ScoreCounter();

            counter.AddThrow(10);
            counter.AddThrow(3);
            counter.AddThrow(5);

            int score = counter.GetScore();

            Assert.That(score == 26);
        }

        [Test]
        public void AddThrowsOf10Then10then3Then5AndGetScore49()
        {
            ScoreCounter counter = new ScoreCounter();

            counter.AddThrow(10);
            counter.AddThrow(10);
            counter.AddThrow(3);
            counter.AddThrow(5);

            int score = counter.GetScore();

            Assert.That(score == 49);
        }

        [Test]
        public void AddThrowsOf0Then10then5AndGetScore20()
        {
            ScoreCounter counter = new ScoreCounter();

            counter.AddThrow(0);
            counter.AddThrow(10);
            counter.AddThrow(5);

            int score = counter.GetScore();

            Assert.That(score == 20);
        }

        [Test]
        public void AddThrowsOf3Then5then10AndGetScore18()
        {
            ScoreCounter counter = new ScoreCounter();

            counter.AddThrow(3);
            counter.AddThrow(5);
            counter.AddThrow(10);

            int score = counter.GetScore();

            Assert.That(score == 18);
        }

        [Test]
        public void Add10RoundsWith3StrikeIntoTheLastRoundAndGetAScoreOf60()
        {
            ScoreCounter counter = new ScoreCounter();

            for (int i = 0; i < 18; ++i)
            {
                counter.AddThrow(0);
            }
            for (int i = 0; i < 3; ++i)
            {
                counter.AddThrow(10);
            }

            int score = counter.GetScore();
            Assert.That(score == 30);
        }

        [Test]
        public void Add10RoundsWithASpareIntoTheLastRoundAndGetAScoreOf20()
        {
            ScoreCounter counter = new ScoreCounter();
            for (int i = 0; i < 18; ++i)
            {
                counter.AddThrow(0);
            }
            counter.AddThrow(3);
            counter.AddThrow(7);
            counter.AddThrow(10);

            int score = counter.GetScore();
            Assert.That(score == 20);
        }

        [Test]
        public void Add10RoundsWith2ThrowOf5Then3IntoTheLastRoundAndGetAScoreOf8()
        {
            ScoreCounter counter = new ScoreCounter();
            for (int i = 0; i < 18; ++i)
            {
                counter.AddThrow(0);
            }
            counter.AddThrow(5);
            counter.AddThrow(3);

            int score = counter.GetScore();
            Assert.That(score == 8);
        }

        [Test]
        public void Add12StrikeAndGetAScoreOf300()
        {
            ScoreCounter counter = new ScoreCounter();

            for (int i = 0; i < 12; ++i)
            {
                counter.AddThrow(10);
            }

            int score = counter.GetScore();
            Assert.That(score == 300);
        }

    }
}
