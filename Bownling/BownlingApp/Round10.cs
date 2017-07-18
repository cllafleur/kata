namespace BowlingApp
{
    using System;

    public class Round10 : Round
    {

        public int Throw3
        {
            get; private set;
        }

        protected override void AddThrowImpl(int score)
        {
            if (Done)
                throw new ArgumentException("Partie Done", nameof(score));

            if (internalThrowCount < 2)
            {
                base.AddThrowImpl(score);
            }
            else
            {
                Throw3 = score;
                EvaluateDone();
                internalThrowCount++;
            }
        }

        protected override void EnsurePostCondition()
        {
            
        }

        protected override void EvaluateScoreType()
        {

        }

        protected override void EvaluateDone()
        {
            if (internalThrowCount == 1 && Throw1 + Throw2 < 10)
                Done = true;
            else if (internalThrowCount > 1)
                Done = true;
        }
    }
}
