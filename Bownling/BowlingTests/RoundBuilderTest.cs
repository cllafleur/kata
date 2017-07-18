namespace BowlingTests
{
    using BowlingApp;
    using NUnit.Framework;
    using System;

    public class RoundBuilderTest
    {
        // give a throw score and return a round object
        [Test]
        public void GiveAThrowAndReturnOneRoundOject()
        {
            RoundCollectionBuilder builder = new RoundCollectionBuilder();
            builder.AddScore(1);
            RoundCollection rounds = builder.GetRoundCollection();
            Assert.That(rounds, Has.Property("Count").EqualTo(1));
        }

        [Test]
        public void GiveAThrowWithAScoreOf11OrLessThan0ThrowInvalidArgument()
        {
            RoundCollectionBuilder builder = new RoundCollectionBuilder();
            Assert.Throws<ArgumentOutOfRangeException>(() => builder.AddScore(-1));
            Assert.Throws<ArgumentOutOfRangeException>(() => builder.AddScore(11));
        }

        [Test]
        public void GiveAThrowWithASumoFScoreGreaterThan10ThrowInvalidArgument()
        {
            RoundCollectionBuilder builder = new RoundCollectionBuilder();
            builder.AddScore(1);
            Assert.Throws<ArgumentException>(() => builder.AddScore(10));
        }

        // give 2 throw scores and return a round object
        [Test]
        public void Give2ThrowAndReturnOneRoundObject()
        {
            RoundCollectionBuilder builder = new RoundCollectionBuilder();

            builder.AddScore(1);
            builder.AddScore(1);
            RoundCollection rounds = builder.GetRoundCollection();

            Assert.That(rounds, Has.Property("Count").EqualTo(1));
        }

        // give 3 throw scores and return 2 round objects
        [Test]
        public void Give3ThrowAndReturn2RoundObject()
        {
            RoundCollectionBuilder builder = new RoundCollectionBuilder();

            builder.AddScore(1);
            builder.AddScore(1);
            builder.AddScore(1);
            RoundCollection rounds = builder.GetRoundCollection();

            Assert.That(rounds, Has.Property("Count").EqualTo(2));
        }

        // GiveAThrowWithAScoreOf10AndReturnARoundWithStrikeSet
        [Test]
        public void GiveAThrowWithAScoreOf10AndReturnARoundWithStrikeSet()
        {
            RoundCollectionBuilder builder = new RoundCollectionBuilder();

            builder.AddScore(10);
            RoundCollection rounds = builder.GetRoundCollection();

            Assert.That(rounds[0], Has.Property("ScoreType").EqualTo(ScoreKind.Strike));
        }

        [Test]
        public void GiveAThrowWithAScoreOf10AndReturnARoundWithSpareSet()
        {
            RoundCollectionBuilder builder = new RoundCollectionBuilder();

            builder.AddScore(1);
            builder.AddScore(9);
            RoundCollection rounds = builder.GetRoundCollection();

            Assert.That(rounds[0], Has.Property("ScoreType").EqualTo(ScoreKind.Spare));
        }

        [Test]
        public void GiveAStrikeThenAScoreOf5AndGet2RoundObjects()
        {
            RoundCollectionBuilder builder = new RoundCollectionBuilder();

            builder.AddScore(10);
            builder.AddScore(5);
            RoundCollection rounds = builder.GetRoundCollection();

            Assert.That(rounds, Has.Property("Count").EqualTo(2));
        }
    }
}
