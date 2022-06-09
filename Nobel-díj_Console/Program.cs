using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Nobel_díj_Console
{
    class Program
    {
        private const string FilePath = "orvosi_nobeldijak.txt";

        static void Main(string[] args)
        {
            List<NobelCandidate> candidates = File.ReadLines(FilePath)
                .Skip(1)
                .Select(it => new NobelCandidate(it))
                .ToList();

            var s = new Solution(candidates);
            s.Task3();
            s.Task4();
            s.Task5();
            s.Task6();
            s.Task7();

            Console.ReadKey();
        }

        
    }
}
