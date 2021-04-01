using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ProblemSolving
{
    public static class ClimbingTrees
    {
        static int[] climbingLeaderboard(int[] scores, int[] alice)
        {
            int count = 1;
            int max = scores[0];
            int min = scores[scores.Length - 1];
            Dictionary<int, int> scoreRanks = new Dictionary<int, int>();
            int[] aliceRanks = new int[alice.Length];
            var aliceScores = new LinkedList<int>(alice);
            int bandValue = 0;
            foreach (var value in scores.GroupBy(x => x).Select(group => new { score = group.Key }))
            {
                scoreRanks.Add(value.score, count++);
            }
            for (int i = 0; i < alice.Length; i++)
            {
                var filterList = scoreRanks.Where(x => x.Key <= alice[i] && x.Key >= bandValue);
                bandValue = filterList.First().Key;
                //aliceRanks[i] = filterList.ElementAt(0);
                //scoreRanks.Remove(bandValue);
                //aliceScores.Remove(alice[i]);
            }
            return aliceRanks;
        }


        public static void ExecuteProgram()

        {
            TextWriter textWriter = new StreamWriter("G:\\OUTPUT_PATH", true);

            int scoresCount = Convert.ToInt32(Console.ReadLine());

            Stream inputStream = Console.OpenStandardInput();
            byte[] bytes = new byte[2885000];    // 1.5kb
            int outputLength = inputStream.Read(bytes, 0, 2885000);

            var myStr = System.Text.Encoding.UTF8.GetString(bytes);

            int[] scores = Array.ConvertAll(myStr.Split(' '), scoresTemp => Convert.ToInt32(scoresTemp));
            int aliceCount = Convert.ToInt32(Console.ReadLine());
            Array.Clear(bytes, 0, bytes.Length);

            outputLength = inputStream.Read(bytes, 0, 2885000);
            myStr = System.Text.Encoding.UTF8.GetString(bytes);

            int[] alice = Array.ConvertAll(myStr.Split(' '), aliceTemp => Convert.ToInt32(aliceTemp));
            int[] result = climbingLeaderboard(scores, alice);

            //textWriter.WriteLine(string.Join("\n", result));
            Console.WriteLine(string.Join("\n", result));

            textWriter.Flush();
            textWriter.Close();
        }
    }

}
