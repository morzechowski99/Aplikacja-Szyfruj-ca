using System;
using System.Collections.Generic;
using System.Text;

namespace Aplikacja_Szyfrująca.Critography
{
    public class MatrixShiftB
    {
        public string Encrypt(string word, string key)
        {
            int x = 0, y = 0;
            char[,] matrix = GetMatrix(word, key, out y, out x);
            List<LetterWithRank> letterWithRanks = GetRanking(key);
            string result = GetEncrypted(x, matrix, letterWithRanks);
            return result;


        }

        public string Decrypt(string word, string key)
        {
            List<LetterWithRank> letterWithRanks = GetRanking(key);
            int y = key.Length;
            int x = word.Length % y == 0 ? word.Length / y : word.Length / y + 1;
            int lastColumnInLastRow = word.Length % y == 0 ? y - 1 : y - (y * x - word.Length) - 1;

            char[,] matrix = new char[x, y];

            int index = 0;
            foreach(var item in letterWithRanks)
            {
                for(int i = 0; i< x;i++)
                {
                    if(i < x -1)
                    {
                        matrix[i, item.Rank] = word[index++];
                    }
                    else
                    {
                        if(item.Rank <= lastColumnInLastRow)
                        {
                            matrix[i, item.Rank] = word[index++];
                        }
                    }
                }
            }

            string result = "";
            for (int i = 0; i < x; i++)
            {
                for(int j =0; j< y;j++)
                {
                    if (matrix[i, j] != '\0') result += matrix[i, j];
                }
            }
            return result;
        }

        private string GetEncrypted(int x, char[,] matrix, List<LetterWithRank> letterWithRanks)
        {
            string result = "";

            foreach (var elem in letterWithRanks)
            {
                for (int i = 0; i < x; i++)
                {
                    if (matrix[i, elem.Rank] != '\0') result += matrix[i, elem.Rank];
                }
            }

            return result;
        }

        private List<LetterWithRank> GetRanking(string key)
        {
            int index = 0;
            List<LetterWithRank> letterWithRanks = new List<LetterWithRank>();
            foreach (var letter in key)
            {
                letterWithRanks.Add(new LetterWithRank(letter, index++));
            }

            letterWithRanks.Sort((el1, el2) =>
            {
                if (el1.Letter == el2.Letter) return 0;
                else if (el1.Letter < el2.Letter) return -1;
                else return 1;
            });
            return letterWithRanks;
        }
        private char[,] GetMatrix(string word, string key,out int y, out int x)
        {
             y = key.Length;
             x = word.Length % y == 0 ? word.Length / y : word.Length / y + 1;

            char[,] matrix = new char[x, y];
            int index = 0;
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    matrix[i, j] = word[index++];
                    if (index == word.Length) break;
                }
            }
            return matrix;
        }

        private struct LetterWithRank
        {
            internal char Letter { get; set; }
            internal int Rank { get; set; }

            internal LetterWithRank(char letter, int rank)
            {
                Letter = letter;
                Rank = rank;
            }
        }
    }
}
