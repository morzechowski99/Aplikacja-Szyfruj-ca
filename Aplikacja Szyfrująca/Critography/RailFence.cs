using System;
using System.Collections.Generic;
using System.Text;

namespace Aplikacja_Szyfrująca.Critography
{
    public class RailFence 
    {
        public string Encrypt(string word, int key)
        {
            List<char>[] encryptArray = new List<char>[key];

            for (int i = 0; i < key; i++)
            {
                encryptArray[i] = new List<char>();
            }
            CreateMatrix(word, key, encryptArray);
            return GetResult(encryptArray);
        }

        private static string GetResult(List<char>[] encryptArray)
        {
            string encrypted = "";
            foreach (var list in encryptArray)
            {
                foreach (char c in list)
                {
                    encrypted += c;
                }
            }
            return encrypted;
        }

        private static void CreateMatrix(string word, int key, List<char>[] encryptArray)
        {
            bool isIncrement = true;
            int index = 0;
            foreach (var c in word)
            {
                encryptArray[index].Add(c);
                if (isIncrement)
                {
                    if (index < key - 1)
                        index++;
                    else
                    {
                        isIncrement = false;
                        index--;
                    }
                }
                else
                {
                    if (index > 0)
                    {
                        index--;
                    }
                    else
                    {
                        isIncrement = true;
                        index++;
                    }
                }
            }
        }

        public string Decrypt(string encryptedWord, int key)
        {
            char[,] rail = new char[key, encryptedWord.Length];

            MapMatrix(encryptedWord, key, rail);
            GetRealMatrix(encryptedWord, key, rail);
            return GeDecrypted(encryptedWord, key, rail);
        }

        private static string GeDecrypted(string encryptedWord, int key, char[,] rail)
        {
            string result = "";
            bool isIncrement = true;
            int row = 0;
            int col = 0;

            for (int i = 0; i < encryptedWord.Length; i++)
            {

                if (row == 0)
                    isIncrement = true;
                if (row == key - 1)
                    isIncrement = false;

                
                if (rail[row, col] != '*')
                    result += rail[row, col++];

               
                row = isIncrement ? ++row : --row;
            }
            return result;
        }

        private static void GetRealMatrix(string encryptedWord, int key, char[,] rail)
        {
            int index = 0;
            for (int i = 0; i < key; i++)
                for (int j = 0; j < encryptedWord.Length; j++)
                    if (rail[i, j] == '*' && index < encryptedWord.Length)
                        rail[i, j] = encryptedWord[index++];
        }

        private static void MapMatrix(string encryptedWord, int key, char[,] rail)
        {
            bool isIncrement = true;
            int row = 0;
            int col = 0;
            for (int i = 0; i < encryptedWord.Length; i++)
            {
                if (row == 0)
                    isIncrement = true;
                if (row == key - 1)
                    isIncrement = false;

                rail[row, col++] = '*';
                row = isIncrement ? ++row : --row;
            }
        }
    }
}
