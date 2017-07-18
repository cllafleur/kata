using System;

namespace BowlingApp
{
    public class Round
    {
        public const int STRIKE_SCORE = 10;

        protected int internalThrowCount = 0;

        public ScoreKind ScoreType { get; private set; }

        public bool Done { get; protected set; }

        public int Throw1
        { get; private set; }

        public int Throw2
        { get; private set; }

        public void AddThrow(int score)
        {
            if (score > 10 || score < 0)
                throw new ArgumentOutOfRangeException(nameof(score));

            AddThrowImpl(score);

            EnsurePostCondition();
        }

        protected virtual void EnsurePostCondition()
        {
            if (Throw1 + Throw2 > 10)
                throw new ArgumentException("Invalid value for the round", "score");
        }

        protected virtual void AddThrowImpl(int score)
        {
            switch (internalThrowCount)
            {
                case 0:
                    Throw1 = score;
                    break;

                case 1:
                    Throw2 = score;
                    break;

            }
            EvaluateScoreType();
            EvaluateDone();
            internalThrowCount++;
        }

        protected virtual void EvaluateScoreType()
        {
            if (Throw1 == STRIKE_SCORE)
                ScoreType = ScoreKind.Strike;
            else if ((Throw1 + Throw2) == STRIKE_SCORE)
                ScoreType = ScoreKind.Spare;
        }

        protected virtual void EvaluateDone()
        {
            if (internalThrowCount == 1 || Throw1 == STRIKE_SCORE)
                Done = true;
        }
    }
}