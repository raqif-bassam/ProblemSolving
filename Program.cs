using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ProblemSolving
{
    class Program
    {
        static int pickingNumbers(List<int> a)
        {
            int count = 0; int j = 1;
            int firstNum = a[0];
            for (int i = 0; i < a.Count; i++)
            {
                if (j == a.Count)
                    break;
                if (Math.Abs(firstNum - a[j]) <= 1)
                {
                    firstNum = a[j];
                    j++;
                    count++;
                }
                else
                {
                    j++;
                }
            }
            return count + 1;
        }

        static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine().Trim());

            List<int> a = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(aTemp => Convert.ToInt32(aTemp)).ToList();

            int result = pickingNumbers(a);
            Console.WriteLine(result);
            //const string textFile = @"F:\Personal\ProblemSolving\ProblemSolving\input05.txt";
            //if (File.Exists(textFile))
            //{
            //    string[] s = File.ReadAllLines(textFile);
            //}
        }
    }
}

