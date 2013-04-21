using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerUpdater.Classes
{
    // http://www.antedes.com/blog/csharp/percentage-match-between-two-strings-levenshtein-distance
    static class Levenshtein
    {
        public static bool Check(String string1, String string2, int percentCorrect)
        {
            int maxDistance = string1.Length - (int)(string1.Length * percentCorrect / 100);

            string2 = string2.ToLower();

            int nDiagonal = string1.Length - System.Math.Min(string1.Length, string2.Length);
            int mDiagonal = string2.Length - System.Math.Min(string1.Length, string2.Length);

            if (string1.Length == 0)
            {
                return string2.Length <= maxDistance;
            }
            if (string2.Length == 0)
            {
                return string1.Length <= maxDistance;
            }

            int[,] matrix = new int[string1.Length + 1, string2.Length + 1];

            for (int i = 0; i <= string1.Length; matrix[i, 0] = i++) ;
            for (int j = 0; j <= string2.Length; matrix[0, j] = j++) ;

            int cost;

            for (int i = 1; i <= string1.Length; i++)
            {
                for (int j = 1; j <= string2.Length; j++)
                {
                    if (string2.Substring(j - 1, 1) == string1.Substring(i - 1, 1))
                    {
                        cost = 0;
                    }
                    else
                    {
                        cost = 1;
                    }

                    int valueAbove = matrix[i - 1, j];
                    int valueLeft = matrix[i, j - 1] + 1;
                    int valueAboveLeft = matrix[i - 1, j - 1];
                    matrix[i, j] = Min(valueAbove + 1, valueLeft + 1, valueAboveLeft + cost);
                }

                if (i >= nDiagonal)
                {
                    if (matrix[nDiagonal, mDiagonal] > maxDistance)
                    {
                        return false;
                    }
                    else
                    {
                        nDiagonal++;
                        mDiagonal++;
                    }
                }
            }
            return true;
        }

        private static int Min(int n1, int n2, int n3)
        {
            return System.Math.Min(n1, System.Math.Min(n2, n3));
        }
    }
}
