using System;
using System.Collections.ObjectModel;

namespace BowlingApp
{
    public class RoundCollectionBuilder
    {
        private Collection<Round> rounds = new Collection<Round>();

        private RoundCollection returnedRoundsCollection;

        public RoundCollectionBuilder()
        {
            returnedRoundsCollection = new RoundCollection(rounds);
        }

        public void AddScore(int score)
        {
            Round currentRound;

            if (rounds.Count == 0)
                rounds.Add(new Round());
            else if (rounds[rounds.Count - 1].Done)
            {
                if (rounds.Count == 9)
                    rounds.Add(new Round10());
                else
                    rounds.Add(new Round());
            }
            currentRound = rounds[rounds.Count - 1];

            currentRound.AddThrow(score);
        }

        public RoundCollection GetRoundCollection()
        {
            return returnedRoundsCollection;
        }
    }
}