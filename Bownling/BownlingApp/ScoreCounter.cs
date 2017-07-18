using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingApp
{
    public class ScoreCounter
    {
        private RoundCollectionBuilder roundBuilder = new RoundCollectionBuilder();

        public void AddThrow(int throwValue)
        {
            roundBuilder.AddScore(throwValue);
        }

        public int GetScore()
        {
            int currentScore = ScoreComputer.ComputeScore(roundBuilder.GetRoundCollection());
    
            return currentScore;
        }

        public void ResetScore()
        {
            roundBuilder = new RoundCollectionBuilder();
        }
    }
}
