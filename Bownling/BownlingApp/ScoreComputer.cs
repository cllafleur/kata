using System;

namespace BowlingApp
{
    public class ScoreComputer
    {
        public static int ComputeScore(RoundCollection rounds)
        {
            int currentScore = 0;
            for (int i = 0; i < rounds.Count && i < 9; ++i)
            {
                Round round = rounds[i];
                int roundScore = 0;
                switch (round.ScoreType)
                {
                    case ScoreKind.Spare:
                        roundScore = ComputeSpare(rounds, i);
                        break;

                    case ScoreKind.None:
                        roundScore = ComputeSimple(round);
                        break;

                    case ScoreKind.Strike:
                        roundScore = ComputeStrike(rounds, i);
                        break;

                    default:
                        throw new InvalidOperationException();
                }
                currentScore += roundScore;
            }
            if (rounds.Count > 9)
                currentScore += ComputeRound10((Round10)rounds[9]);
            return currentScore;
        }

        private static int ComputeSpare(RoundCollection rounds, int currentIndex)
        {
            Round round = rounds[currentIndex];
            int score = round.Throw1;
            score += round.Throw2;
            if (rounds.Count > currentIndex + 1)
            {
                score += rounds[currentIndex + 1].Throw1;
            }
            return score;
        }

        private static int ComputeSimple(Round round)
        {
            int score = round.Throw1;
            score += round.Throw2;
            return score;
        }

        private static int ComputeStrike(RoundCollection rounds, int currentIndex)
        {
            Round round = rounds[currentIndex];
            int score = round.Throw1 + round.Throw2;
            if (rounds.Count > currentIndex + 1)
            {
                Round roundP1 = rounds[currentIndex + 1];
                if (roundP1.ScoreType == ScoreKind.Strike)
                {
                    score += 10;
                    if (rounds.Count > currentIndex + 2)
                    {
                        Round roundP2 = rounds[currentIndex + 2];
                        score += roundP2.Throw1;
                    }
                }
                else
                    score += roundP1.Throw1 + roundP1.Throw2;
            }
            return score;
        }

        private static int ComputeRound10(Round10 round)
        {
            int score = round.Throw1 + round.Throw2;

            if (round.Throw1 == 10)
                score += round.Throw3;
            else if (round.Throw2 == 10 || round.Throw1 + round.Throw2 == 10)
                score += round.Throw3;
            return score;
        }
    }
}
