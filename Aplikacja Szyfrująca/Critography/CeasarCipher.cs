using System;
using System.Collections.Generic;
using System.Text;

namespace Aplikacja_Szyfrująca.Critography
{
    
    public class CeasarCipher
    {
        private int N = 26; //ilosc liter w alfabecie
        private int EULER_N = 12; 

        public string Encrypt(string word,int k1, int k0)
        {
            string wordToEncrypt = word.ToUpper();

            string result = "";

            foreach(var letter in wordToEncrypt)
            {
                result += (char)(65 + (((letter - 65) * k1 + k0) % N));
            }
            return result;
        }
        public string Decrypt(string word, int k1, int k0)
        {
            string result = "";
            
            foreach( var letter in word)
            {
                char value = (char)((((letter - 65) + (N - k0)) * Math.Pow(k1, EULER_N - 1)) % N);
                result += (char)(value + 65);
            }
            return result;
        }

    }
}
