using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnagramsLib
{
    public class Anagrams
    {
        public static IList<IList<string>> BuildAnagramsCollection(IList<string> sources)
        {
            return null;
        }

        public static string GetAnagramHash(string word)
        {
            string normalizedWord = word.ToLowerInvariant();
            SortedSet<char> ordered = new SortedSet<char>(normalizedWord.ToCharArray(), new CharComparer());
            return new string(ordered.ToArray());
        }


        class CharComparer : IComparer<char> {
            public int Compare(char x, char y)
            {
                int result = x.CompareTo(y);
                if (result == 0)
                    return 1;
                return result;
            }
        }
    }
}
