using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnagramsLib
{
    class Program
    {
        static void Main()
        {
            List<string> words = new List<string>();
            using (var st = new StreamReader(@"wordlist.txt"))
            {
                string line;
                while((line = st.ReadLine()) != null)
                {
                    words.Add(line);
                }
            }
            var watch = Stopwatch.StartNew();
            var result = Anagrams.BuildAnagramsCollection(words);
            watch.Stop();
            PrintAnagramGroups(result);
            Console.WriteLine($"Total words             : {words.Count,10}");
            Console.WriteLine($"Anagrams count          : {result.Count,10}");
            Console.WriteLine($"Anagrams count expected : {result.Count,10}");
            Console.WriteLine($"Elapsed time            : {watch.ElapsedMilliseconds,10}ms");
            Console.ReadLine();
        }

        private static void PrintAnagramGroups(IList<IList<string>> groups)
        {
            foreach(var group in groups)
            {
                if (group.Count > 1)
                {
                    foreach (var word in group)
                    {
                        Console.Write($"{word} ");
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}
