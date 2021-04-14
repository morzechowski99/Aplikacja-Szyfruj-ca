using System;
using System.Collections.Generic;
using System.Text;

namespace Aplikacja_Szyfrująca.Critography
{
    public class Vigenere
    {
        public string Encrypt(string word, string key)
        {
            word = word.ToUpper();
            key = key.ToUpper();
            char[,] matrix = GetMatrix();
            string result = "";
            int idx = 0;
            foreach (var letter in word)
            {
                result += matrix[letter - 65, key[idx % key.Length] - 65];
                idx++;
            }
            return result;
        } 
        public string Decrypt(string word, string key)
        {
            word = word.ToUpper();
            key = key.ToUpper();
            char[,] matrix = GetMatrix();
            string result = "";
            int idx = 0;
            foreach (var letter in word)
            {
                int row = key[idx % key.Length] - 65;
                
                for(int i = 0; i< 26; i++)
                {
                    if(matrix[row,i] == letter)
                    {
                        result += (char)(i + 65);
                        break;
                    }
                }
                idx++;
            }
            return result;
        }

        private char[,] GetMatrix()
        {
            int alphabet = 26;
            char[,] matrix = new char[alphabet, alphabet];
            char start = (char)0;
            for (int i = 0; i < alphabet; i++)
            {
                for (int j = 0; j < alphabet; j++)
                {
                    matrix[i, j] = (char)(65 + ((start + j) % alphabet));
                }
                start++;
            }

            return matrix;
        }
    }
}
