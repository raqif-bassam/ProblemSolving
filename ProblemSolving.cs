using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProblemSolving
{
    public class ProblemSolving
    {
        // Complete the decentNumber function below.
        static void decentNumber(int n)
        {
            StringBuilder s = new StringBuilder();
            int count = 1;
            int number = n;
            while (number > 0)
            {
                number = number - 5;
                if (number % 3 == 0)
                {
                    break;
                }
                count++;
            }
            if (n % 3 == 0 && n % 5 == 0)
            {
                for (int i = 0; i < n; i++)
                    s.Append("5");
            }
            else if (n % 5 != 0 && n % 3 == 0)
            {
                for (int i = 0; i < n; i++)
                    s.Append("5");
            }
            else if (number <= 0 && count * 5 == n)
            {
                for (int i = 0; i < n; i++)
                    s.Append("3");
            }
            else if (number > 0)
            {
                for (int i = 0; i < number; i++)
                    s.Append("5");
                for (int i = 0; i < count * 5; i++)
                    s.Append("3");
            }
            else
            {
                Console.WriteLine(-1);
                return;
            }
            Console.WriteLine(s);
        }

        // Complete the toys function below.
        static int toys(int[] w)
        {
            int count = 0;
            w = w.OrderBy(x => x).ToArray();
            for (int i = 0; i < w.Length; i++)
            {
                int firstNum = w[i];
                for (int j = i; j < w.Length; j++)
                {
                    if (w[j] > firstNum + 4)
                    {
                        count++;
                        i = j - 1;
                        break;
                    }
                    else if (j == w.Length - 1)
                    {
                        count++;
                        i = j;
                    }
                }
            }
            return count;
        }

        static int countingValleys(int steps, string path)
        {
            char[] pathArray = path.ToCharArray();
            int pathDist = 0; int count = 0;
            for (int i = 0; i < pathArray.Length; i++)
            {
                if (pathArray.ElementAt(i) == 'U')
                {
                    pathDist += 1;
                    if (pathDist == 0)
                        count++;
                }
                else if (pathArray.ElementAt(i) == 'D')
                {
                    pathDist += -1;
                }
            }
            return count;
        }
        // Complete the beautifulPairs function below.
        static int beautifulPairs(int[] A, int[] B)
        {
            Dictionary<int, int> couple = new Dictionary<int, int>();
            int result = 0;
            for (int i = 0; i < A.Length; i++)
            {
                for (int j = 0; j < B.Length; j++)
                {
                    if (A[i] == B[j] && !couple.ContainsKey(i) && !couple.ContainsValue(j) && A.Length != 1 && B.Length != 1)
                        couple.Add(i, j);
                }
            }
            var diff = A.Except(B).ToArray();
            if (diff.Length > 0)
                result = 1;
            else if (couple.Count == A.Length)
                result = -1;
            result = result + couple.Count;
            return result;
        }

        // Complete the bonAppetit function below.
        static void bonAppetit(List<int> bill, int k, int b)
        {
            int sum = bill.Sum();
            int diff = (sum - bill[k]) / 2;
            if (diff == b)
                Console.WriteLine("Bon Appetit");
            else
                Console.WriteLine(Math.Abs(diff - b));

        }

        static int pageCount(int n, int p)
        {
            /*
             * Write your code here.
             */
            Dictionary<int, int> pageCollection = new Dictionary<int, int>();
            for (int i = 0; i <= n; i++)
            {
                if (i == n && n % 2 == 0)
                    pageCollection.Add(i, 0);
                else if (i < n)
                    pageCollection.Add(i, i + 1);
                i = i + 1;
            }
            int indexOfPageFound;
            if (pageCollection.ContainsKey(p))
                indexOfPageFound = Array.IndexOf(pageCollection.Keys.ToArray(), p);
            else indexOfPageFound = Array.IndexOf(pageCollection.Values.ToArray(), p);
            int forward = indexOfPageFound - 0;
            int backward = pageCollection.Count - indexOfPageFound - 1;
            int result = forward < backward ? forward : backward;
            return result;
        }
        static int max(int x, int y)
        {
            return (x > y) ? x : y;
        }

        static int lps(string seq)
        {
            int n = seq.Length;
            int i, j, cl;

            int[,] L = new int[n, n];
            for (i = 0; i < n; i++)
                L[i, i] = 1;


            for (cl = 2; cl <= n; cl++)
            {
                for (i = 0; i < n - cl + 1; i++)
                {
                    j = i + cl - 1;

                    if (seq[i] == seq[j] && cl == 2)
                    {
                        L[i, j] = 2;
                        Console.WriteLine(seq[i]);
                    }
                    else if (seq[i] == seq[j])
                    {
                        L[i, j] = L[i + 1, j - 1] + 2;
                        Console.WriteLine(seq[i]);
                    }
                    else
                    {
                        L[i, j] = max(L[i, j - 1], L[i + 1, j]);
                        Console.WriteLine(seq[i]);
                    }
                }
            }

            return L[0, n - 1];
        }

        string lcs(ref string X, ref string Y)
        {
            int m = X.Length;
            int n = Y.Length;

            //int L[m + 1][n+1]; 
            int[,] L = new int[m + 1, n + 1];

            /* Following steps build L[m+1][n+1] in bottom 
               up fashion. Note that L[i][j] contains 
               length of LCS of X[0..i-1] and Y[0..j-1] */
            for (int ii = 0; ii <= m; ii++)
            {
                for (int jj = 0; jj <= n; jj++)
                {
                    if (ii == 0 || jj == 0)
                        L[ii, jj] = 0;
                    else if (X[ii - 1] == Y[jj - 1])
                        L[ii, jj] = L[ii - 1, jj - 1] + 1;
                    else
                        L[ii, jj] = max(L[ii - 1, jj], L[ii, jj - 1]);
                }
            }

            // Following code is used to print LCS 
            int index = L[m, n];

            // Create a string length index+1 and 
            // fill it with \0 
            string lcs = "\0";

            // Start from the right-most-bottom-most 
            // corner and one by one store characters 
            // in lcs[] 
            int i = m, j = n;
            while (i > 0 && j > 0)
            {
                // If current character in X[] and Y 
                // are same, then current character 
                // is part of LCS 
                if (X[i - 1] == Y[j - 1])
                {
                    // Put current character in result 
                    lcs.Insert(index - 1, X[i - 1].ToString());
                    i--;
                    j--;

                    // reduce values of i, j and index 
                    index--;
                }

                // If not same, then find the larger of 
                // two and go in the direction of larger 
                // value 
                else if (L[i - 1, j] > L[i, j - 1])
                    i--;
                else
                    j--;
            }

            return lcs;
        }

        public string Reverse(string text)
        {
            if (text == null) return null;

            // this was posted by petebob as well 
            char[] array = text.ToCharArray();
            Array.Reverse(array);
            return new String(array);
        }

        // Returns longest palindromic subsequence 
        // of str 
        string longestPalSubseq(ref string str)
        {
            // Find reverse of str 
            string rev = Reverse(str);


            // Return LCS of str and its reverse 
            return lcs(ref str, ref rev);
        }

        public static bool IsPalindrome(int x)
        {
            int y = 0; int actualNum = x;
            if (actualNum < 0)
                return false;
            while (x != 0)
            {
                int rem = x % 10;
                y = y + rem;
                x = x / 10;
                if (x != 0)
                    y = y * 10;
            }
            if (y == actualNum)
                return true;
            else return false;
        }

        public static bool IsPalindrome(ListNode head)
        {
            string actualStr = string.Empty;
            while (head != null)
            {
                actualStr += head.val;
                head = head.next;
            }
            var reverseStr = actualStr.Reverse();
            if (actualStr == actualStr.Reverse().ToString())
                return true;
            else
                return false;
        }


        public static List<int> gradingStudents(List<int> grades)
        {
            for (int i = 0; i < grades.Count; i++)
            {
                if (grades[i] >= 38)
                {
                    int tGrade = grades[i] - (grades[i] % 5) + 5;
                    if (tGrade - grades[i] < 3)
                        grades[i] = tGrade;
                }
            }
            return grades;
        }

        static void countApplesAndOranges(int s, int t, int a, int b, int[] apples, int[] oranges)
        {
            int countOfOranges = 0, countOfApples = 0;
            for (int i = 0; i < apples.Length; i++)
            {
                if (apples[i] + a >= s && apples[i] + a <= t)
                    countOfApples++;
            }
            for (int i = 0; i < oranges.Length; i++)
            {
                if (oranges[i] + b >= s && oranges[i] + b <= t)
                    countOfOranges++;
            }
            Console.WriteLine(countOfApples);
            Console.WriteLine(countOfOranges);

        }

        static string kangaroo(int x1, int v1, int x2, int v2)
        {
            if (v1 - v2 == 0)
                return "NO";
            int y = (x2 - x1) % (v1 - v2);
            if (v2 > v1 && x2 > x1)
                return "NO";
            else if (y == 0)
                return "YES";
            else return "NO";
        }

        public static long lcm_of_array_elements(int[] element_array)
        {
            long lcm_of_array_elements = 1;
            int divisor = 2;

            while (true)
            {

                int counter = 0;
                bool divisible = false;
                for (int i = 0; i < element_array.Length; i++)
                {

                    // lcm_of_array_elements (n1, n2, ... 0) = 0. 
                    // For negative number we convert into 
                    // positive and calculate lcm_of_array_elements. 
                    if (element_array[i] == 0)
                    {
                        return 0;
                    }
                    else if (element_array[i] < 0)
                    {
                        element_array[i] = element_array[i] * (-1);
                    }
                    if (element_array[i] == 1)
                    {
                        counter++;
                    }

                    // Divide element_array by devisor if complete 
                    // division i.e. without remainder then replace 
                    // number with quotient; used for find next factor 
                    if (element_array[i] % divisor == 0)
                    {
                        divisible = true;
                        element_array[i] = element_array[i] / divisor;
                    }
                }

                // If divisor able to completely divide any number 
                // from array multiply with lcm_of_array_elements 
                // and store into lcm_of_array_elements and continue 
                // to same divisor for next factor finding. 
                // else increment divisor 
                if (divisible)
                {
                    lcm_of_array_elements = lcm_of_array_elements * divisor;
                }
                else
                {
                    divisor++;
                }

                // Check if all element_array is 1 indicate  
                // we found all factors and terminate while loop. 
                if (counter == element_array.Length)
                {
                    return lcm_of_array_elements;
                }
            }
        }

        static int gcd(int a, int b)
        {
            if (a == 0)
                return b;
            return gcd(b % a, a);
        }

        // Function to find gcd of  
        // array of numbers 
        static int findGCD(int[] arr, int n)
        {
            int result = arr[0];
            for (int i = 1; i < n; i++)
            {
                result = gcd(arr[i], result);

                if (result == 1)
                {
                    return 1;
                }
            }

            return result;
        }



        static IEnumerable<IEnumerable<T>>
    GetPermutations<T>(IEnumerable<T> list, int length)
        {
            if (length == 1) return list.Select(t => new T[] { t });

            return GetPermutations(list, length - 1)
                .SelectMany(t => list.Where(e => !t.Contains(e)),
                    (t1, t2) => t1.Concat(new T[] { t2 }));
        }
        static int maximizingXor(int l, int r)
        {
            int max = 0;
            for (int i = l; i <= r; i++)
            {
                for (int j = i; j <= r; j++)
                {
                    int y = i ^ j;
                    if (y > max)
                        max = y;
                }
            }
            return max;
        }


        static int x = 0;
        static void f()
        {
            for (int i = 0; i < 5; i++)
                x++;
            Console.WriteLine(x);
        }

        static int lonelyinteger(int[] a)
        {
            var result = a.GroupBy(x => x).Select(y => new { Number = y.Key, Count = y.Count() }).ToList();
            return result.FirstOrDefault(x => x.Count == result.Min(y => y.Count)).Number;
        }

        static long xorSequence(long l, long r)
        {
            long result = 0;
            for (long i = l; i <= r; i++)
            {
                if (i % 4 == 0)
                    result = result ^ i;
                if ((i + 1) % 4 == 0)
                    result = result ^ 0;
                if ((i + 1) % 2 == 0 && (i + 1) % 4 != 0)
                    result = result ^ 1;
                if (i % 2 == 0 && (i % 4) != 0)
                    result = result ^ (i + 1);
            }
            return result;
        }

        static long sumXor(long n)
        {
            int count = 0;
            while (n > 0)
            {
                if (n % 2 == 0)
                    count++;
                n = n / 2;
            }
            return (long)Math.Pow(2, count);
        }

        // Complete the flatlandSpaceStations function below.
        static int flatlandSpaceStations(int n, int[] c)
        {
            Array.Sort(c);
            int maxDistance = c[0];
            for (int i = 1; i < c.Count(); i++)
            {
                int distance = (c[i] - c[i - 1]) / 2;
                if (distance > maxDistance)
                    maxDistance = distance;
            }
            int lastDistance = (n - 1) - c[c.Count() - 1];
            if (lastDistance > maxDistance)
                maxDistance = lastDistance;
            return maxDistance;
        }

        // Complete the alternate function below.
        static int alternate(string s)
        {
            int[,] arr = new int[27, 27];
            char[,] charMat = new char[27, 27];
            char[] distinctChar = s.Distinct().OrderBy(x => x).ToArray();
            string copy = s;
            for (int i = 0; i < distinctChar.Length; i++)
            {
                charMat[i + 1, 0] = distinctChar[i];
                charMat[0, i + 1] = distinctChar[i];
            }
            for (int i = 0; i < s.Length; i++)
            {
                int index = Array.IndexOf(distinctChar, s.ElementAt(i));
                for (int j = 1; j <= distinctChar.Length; j++)
                {
                    if (j != index + 1 && (charMat[index + 1, j] != s.ElementAt(i) && charMat[j, index + 1] != s.ElementAt(i) && (arr[j, index + 1] != -1 && arr[index + 1, j] != -1)))
                    {
                        charMat[index + 1, j] = s.ElementAt(i);
                        charMat[j, index + 1] = s.ElementAt(i);
                        arr[j, index + 1] += 1;
                        arr[index + 1, j] += 1;
                    }
                    else
                    {
                        arr[j, index + 1] = -1;
                        arr[index + 1, j] = -1;
                    }
                }
            }
            int maxSize = 0;
            for (int i = 1; i <= distinctChar.Length; i++)
            {
                for (int j = 1; j <= distinctChar.Length; j++)
                {
                    if (maxSize < arr[i, j])
                        maxSize = arr[i, j];
                }
            }
            //for (int i = 1; i <= distinctChar.Length; i++)
            //{
            //    for (int j = 1; j <= distinctChar.Length; j++)
            //    {
            //        Console.Write(arr[i, j] + " ");
            //    }
            //    Console.WriteLine(" ");
            //}
            return maxSize;
        }

        // Complete the caesarCipher function below.
        static string caesarCipher(string s, int k)
        {
            string cipherText = "";
            Dictionary<char, int> alphabets = new Dictionary<char, int>();
            int count = 0;
            for (char c = 'A'; c <= 'Z'; c++)
            {
                alphabets.Add(c, ++count);
            }
            for (int i = 0; i < s.Length; i++)
            {
                char c = s.ElementAt(i);
                int lowerLimit = char.IsUpper(c) ? 65 : 97;
                int divider = char.IsUpper(c) ? 90 : 122;
                char ar = s.ToUpper().ElementAt(i);
                if (char.IsLetter(c))
                {
                    int asciiValue = (int)c;
                    if ((alphabets[ar] + k) % 26 == 0)
                        asciiValue = divider;
                    else
                        asciiValue = (alphabets[ar] + k) % 26 + lowerLimit - 1;
                    cipherText += (char)asciiValue;
                }
                else
                    cipherText += s.ElementAt(i);
            }
            return cipherText;
        }

    }

    class Result
    {

        /*
         * Complete the 'counterGame' function below.
         *
         * The function is expected to return a STRING.
         * The function accepts LONG_INTEGER n as parameter.
         */

        static long RichardFunc(long n)
        {
            long number = n;
            if (IsPowerOftwo(n))
            {
                return n / 2;
            }
            else
            {
                int lessPower = (int)Math.Floor(Math.Log(n) / Math.Log(2));
                long diff = number - (long)Math.Pow(2, lessPower);
                return diff;
            }
        }

        static long LouiseFunc(long n)
        {
            long number = n;
            if (IsPowerOftwo(n))
            {
                return n / 2;
            }
            else
            {
                int lessPower = (int)Math.Floor(Math.Log(n) / Math.Log(2));
                long diff = number - (long)Math.Pow(2, lessPower);
                return diff;
            }
        }

        static bool IsPowerOftwo(long n)
        {
            return (decimal)(Math.Log(n) / Math.Log(2)) % 1 == 0;
        }

        public static string counterGame(long n)
        {
            long result = n;
            if (n == 1)
                return "Louise";
            while (true)
            {
                result = LouiseFunc(result);
                if (result == 1)
                    return "Louise";
                else
                {
                    result = RichardFunc(result);
                    if (result == 1)
                        return "Richard";
                }
            }
        }
        // Complete the weightedUniformStrings function below.
        static string[] weightedUniformStrings(string s, int[] queries)
        {
            Dictionary<char, int> alphabets = new Dictionary<char, int>();
            int count = 0; string[] answers = new string[queries.Length];
            for (char c = 'a'; c <= 'z'; c++)
            {
                alphabets.Add(c, ++count);
            }
            int[] array = new int[s.Length];
            char[] str = s.ToCharArray();
            array[0] = alphabets[s.ElementAt(0)];
            for (int j = 1; j < str.Length; j++)
            {
                if (str[j - 1] == str[j])
                {
                    array[j] = array[j - 1] + alphabets[str[j]];
                }
                else
                {
                    array[j] = alphabets[str[j]];
                }
            }
            HashSet<int> weightedValues = array.ToHashSet<int>();
            for (int i = 0; i < queries.Length; i++)
            {
                if (weightedValues.Contains(queries[i]))
                    answers[i] = "Yes";
                else
                    answers[i] = "No";
            }

            return answers;
        }

        // Complete the icecreamParlor function below.
        static int[] icecreamParlor(int m, int[] arr)
        {
            HashSet<int> arr2 = arr.OrderBy(x => x).Where(x => x <= m).ToHashSet();
            int[] result = new int[2];
            for (int i = 0; i < arr2.Count; i++)
            {
                int complement = m - arr2.ElementAt(i);
                result[0] = Array.IndexOf(arr, arr2.ElementAt(i)) + 1;
                arr[Array.IndexOf(arr, arr2.ElementAt(i))] = 0;
                if (arr2.Contains(complement))
                {
                    result[1] = Array.IndexOf(arr, complement) + 1;
                    break;
                }
            }
            return result.OrderBy(x => x).ToArray();
        }

    }


    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }

        public ListNode Clone()
        {
            return new ListNode
            {
                val = this.val,
                next = this.next
            };
        }
    }
}
