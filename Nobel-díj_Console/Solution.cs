using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nobel_díj_Console
{
    class Solution
    {

        private List<NobelCandidate> Candidates;

        public Solution(List<NobelCandidate> candidates)
        {
            Candidates = candidates;
        }

        public void Task3()
        {
            PrintTask(3, $"A díjazottak száma: {Candidates.Count}");
        }

        public void Task4()
        {
            PrintTask(4, $"Utolsó év: {Candidates.Select(it => it.Year).Max()}");
        }

        public void Task5()
        {
            PrintTask(5, "Kérem, adja meg egy ország kódját: ", newLine: false);
            string readCountryCode = Console.ReadLine();
            List<NobelCandidate> candidatesWithCountryCode = Candidates.Where(it => it.CountryCode == readCountryCode).ToList();
            if (candidatesWithCountryCode.Count == 0)
            {
                Console.WriteLine("A megadott országból nem volt díjazott!");
            }
            else if (candidatesWithCountryCode.Count == 1)
            {
                var candidate = candidatesWithCountryCode[0];
                Console.WriteLine(
                    string.Join(
                        "\n\t",
                        "\tA megadott ország díjazottja:",
                        $"Név: {candidate.Name}",
                        $"Év: {candidate.Year}",
                        $"Sz/H: {candidate.LifePeriod}"
                    )
               );
            }
            else
            {
                Console.WriteLine("A megadott országból {0} fő díjazott volt!", candidatesWithCountryCode.Count);
            }
        }

        public void Task6()
        {
            PrintTask(6, "Statisztika");
            Dictionary<string, int> stat = new Dictionary<string, int>();

            foreach (var candidate in Candidates)
            {
                if (stat.ContainsKey(candidate.CountryCode))
                    stat[candidate.CountryCode] += 1;
                else
                    stat[candidate.CountryCode] = 1;
            }

            foreach (var element in stat)
            {
                if (element.Value > 5)
                {
                    Console.WriteLine($"\t{element.Key} - {element.Value} fő");
                }
            }
        }

        public void Task7()
        {
            double averageLife = Candidates.Select(it => it.LifePeriod)
                .Where(it => it.IsmertAzElethossz)
                .Average(it => it.ElethosszEvekben);

            PrintTask(7, $"A keresett átlag: {Math.Round(averageLife, 1)} év");
        }

        private void PrintTask(int n, string title, bool newLine = true)
        {
            Console.Write($"{n}. Feladat: {title}" + (newLine ? "\n" : string.Empty));
        }
    }
}
