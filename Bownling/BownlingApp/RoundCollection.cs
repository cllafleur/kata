namespace BowlingApp
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;

    public class RoundCollection : ReadOnlyCollection<Round>
    {
        public RoundCollection(IList<Round> list) : base(list)
        {
        }
    }
}