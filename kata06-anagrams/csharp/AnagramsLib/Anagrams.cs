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
            IList<IList<string>> wordGroupsByAnagram = new List<IList<string>>();
            Dictionary<string, IList<string>> hashList = new Dictionary<string, IList<string>>();

            foreach (string word in sources)
            {
                string hash = GetAnagramHash(word);
                IList<string> anagrams;
                if (!hashList.ContainsKey(hash))
                {
                    anagrams = new List<string>();
                    hashList.Add(hash, anagrams);
                    wordGroupsByAnagram.Add(anagrams);
                }
                else
                    anagrams = hashList[hash];

                anagrams.Add(word);
            }
            return wordGroupsByAnagram;
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
