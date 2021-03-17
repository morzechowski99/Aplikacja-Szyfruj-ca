using System;
using System.Collections.Generic;
using System.Text;

namespace Aplikacja_Szyfrująca.Critography
{
    public interface ICriptographyAlgorithm
    {
        public string Encrypt(string word, int key);
        public string Decrypt(string encryptedWord, int key);
    }
}
