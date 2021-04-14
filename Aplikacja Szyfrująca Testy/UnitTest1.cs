using Aplikacja_Szyfrująca.Critography;
using NUnit.Framework;

namespace Aplikacja_Szyfrująca_Testy
{
    public class Tests
    {
        private RailFence railFence;
        private MatrixShift matrixShift;
        private MatrixShiftB matrixShiftB;
        private MatrixShiftC matrixShiftC;
        private CeasarCipher ceasarCipher;
        private Vigenere vigenere;
        private SynchronousStreamCipher synchronousStreamCipher;
        private CiphertextAutokey ciphertextAutokey;
        [SetUp]
        public void Setup()
        {
            railFence = new RailFence();
            matrixShift = new MatrixShift();
            matrixShiftB = new MatrixShiftB();
            matrixShiftC = new MatrixShiftC();
            ceasarCipher = new CeasarCipher();
            vigenere = new Vigenere();
            ciphertextAutokey = new CiphertextAutokey();
        }

        [TestCase("CRYPTOGRAPHY", 3, "CTARPORPYYGH")]
        [TestCase("TestowanieSzyfrow", 5, "TiweneosaSrtwzfoy")]
        [TestCase("Kryptografia", 8, "Krypatiofgar")]
        [TestCase("SiecKomputerowa", 4, "SmoioprweKueact")]
        [TestCase("DoZakodowaniaTojestTekst", 7, "DaoiTtZnosaajkkweeoosTdt")]
        [TestCase("Marcin Orzechowski", 3, "MirhkacnOzcosir ew")]
        public void RailFenceEncode(string input, int key, string output)
        {
            var result = railFence.Encrypt(input, key);

            Assert.AreEqual(output, result);
        }

        [TestCase("CTARPORPYYGH", 3, "CRYPTOGRAPHY")]
        [TestCase("TiweneosaSrtwzfoy", 5, "TestowanieSzyfrow")]
        [TestCase("Krypatiofgar", 8, "Kryptografia")]
        [TestCase("SmoioprweKueact", 4, "SiecKomputerowa")]
        [TestCase("DaoiTtZnosaajkkweeoosTdt", 7, "DoZakodowaniaTojestTekst")]
        [TestCase("MirhkacnOzcosir ew", 3, "Marcin Orzechowski")]
        public void RailfenceDecode(string input, int key, string output)
        {
            var result = railFence.Decrypt(input, key);

            Assert.AreEqual(output, result);
        }

        [TestCase("CRYPTOGRAPHY", "YPCTRRAOPGHY")]
        [TestCase("TestowanieSzyfrow", "stToeniweayfSrzow")]
        [TestCase("Kryptografia", "ypKtrraofgia")]
        [TestCase("SiecKomputerowa", "ecSKipuotmowear")]
        [TestCase("DoZakodowaniaTojestTekst", "ZaDkoowoadaTnoistjTestek")]
        [TestCase("Marcin Orzechowski", "rcMiaOrnz hoewcisk")]
        public void MatrixShiftEncode(string input, string output)
        {
            var result = matrixShift.Encrypt(input);

            Assert.AreEqual(output, result);
        }

        [TestCase("YPCTRRAOPGHY", "CRYPTOGRAPHY")]
        [TestCase("stToeniweayfSrzow", "TestowanieSzyfrow")]
        [TestCase("ypKtrraofgia", "Kryptografia")]
        [TestCase("ecSKipuotmowear", "SiecKomputerowa")]
        [TestCase("ZaDkoowoadaTnoistjTestek", "DoZakodowaniaTojestTekst")]
        [TestCase("rcMiaOrnz hoewcisk", "Marcin Orzechowski")]
        public void MatrixShiftDecode(string input, string output)
        {
            var result = matrixShift.Decrypt(input);

            Assert.AreEqual(output, result);
        }
        [TestCase("CRYPTOGRAPHY", "CONVENIENCE", "CYPTRHGYOARP")]
        [TestCase("TestowanieSzyfrow", "CONVENIENCE", "TzeoonSasfwwieytr")]
        [TestCase("Kryptografia", "CONVENIENCE", "Kaftrigyoarp")]
        [TestCase("SiecKomputerowa", "CONVENIENCE", "SrtKpemewouioca")]
        [TestCase("DoZakodowaniaTojestTekst", "CONVENIENCE", "DisaekjotnkdsZToewToatao")]
        [TestCase("MarcinOrzechowski", "CONVENIENCE", "MheikrcOrwnizaocs")]
        public void Encode2b(string input, string key, string output)
        {
            var result = matrixShiftB.Encrypt(input, key);

            Assert.AreEqual(output, result);

        }
        [TestCase("CYPTRHGYOARP", "CONVENIENCE", "CRYPTOGRAPHY")]
        [TestCase("TzeoonSasfwwieytr", "CONVENIENCE", "TestowanieSzyfrow")]
        [TestCase("Kaftrigyoarp", "CONVENIENCE", "Kryptografia")]
        [TestCase("SrtKpemewouioca", "CONVENIENCE", "SiecKomputerowa")]
        [TestCase("DisaekjotnkdsZToewToatao", "CONVENIENCE", "DoZakodowaniaTojestTekst")]
        [TestCase("MheikrcOrwnizaocs", "CONVENIENCE", "MarcinOrzechowski")]
        public void Decode2b(string input, string key, string output)
        {
            var result = matrixShiftB.Decrypt(input, key);

            Assert.AreEqual(output, result);

        }

        [TestCase("CRYPTOGRAPHY", "CONVENIENCE", "CRYHOARPGPYT")]
        [TestCase("TestowanieSzyfrow", "CONVENIENCE", "TezwSwointfaesyor")]
        [TestCase("Kryptografia", "CONVENIENCE", "Kraioarpgfyt")]
        [TestCase("SiecKomputerowa", "CONVENIENCE", "SireoupcwmteoKa")]
        [TestCase("DoZakodowaniaTojestTekst", "CONVENIENCE", "DoienojewtosaTtdkaZaskoT")]
        [TestCase("MarcinOrzechowski", "CONVENIENCE", "MahicnkzrcwOerois")]
        public void Encode2c(string input, string key, string output)
        {
            var result = matrixShiftC.Encrypt(input, key);

            Assert.AreEqual(output, result);

        }

        [TestCase("CRYHOARPGPYT", "CONVENIENCE", "CRYPTOGRAPHY")]
        [TestCase("TezwSwointfaesyor", "CONVENIENCE", "TestowanieSzyfrow")]
        [TestCase("Kraioarpgfyt", "CONVENIENCE", "Kryptografia")]
        [TestCase("SireoupcwmteoKa", "CONVENIENCE", "SiecKomputerowa")]
        [TestCase("DoienojewtosaTtdkaZaskoT", "CONVENIENCE", "DoZakodowaniaTojestTekst")]
        [TestCase("MahicnkzrcwOerois", "CONVENIENCE", "MarcinOrzechowski")]
        public void Decode2c(string input, string key, string output)
        {
            var result = matrixShiftC.Decrypt(input, key);

            Assert.AreEqual(output, result);

        }

        [TestCase("CRYPTOGRAPHY", 7, 5, "TURGIZVUFGCR")]
        [TestCase("TestowanieSzyfrow", 7, 5, "IHBIZDFSJHBYROUZD")]
        [TestCase("Kryptografia", 7, 5, "XURGIZVUFOJF")]
        [TestCase("SiecKomputerowa", 7, 5, "BJHTXZLGPIHUZDF")]
        [TestCase("DoZakodowaniaTojestTekst", 7, 5, "AZYFXZAZDFSJFIZQHBIIHXBI")]
        [TestCase("MarcinOrzechowski", 7, 5, "LFUTJSZUYHTCZDBXJ")]
        public void EncodeCeaser(string input, int a, int b, string output)
        {
            var result = ceasarCipher.Encrypt(input, a, b);

            Assert.AreEqual(output, result);

        }

        [TestCase("TURGIZVUFGCR", 7, 5, "CRYPTOGRAPHY")]
        [TestCase("IHBIZDFSJHBYROUZD", 7, 5, "TESTOWANIESZYFROW")]
        [TestCase("XURGIZVUFOJF", 7, 5, "KRYPTOGRAFIA")]
        [TestCase("BJHTXZLGPIHUZDF", 7, 5, "SIECKOMPUTEROWA")]
        [TestCase("AZYFXZAZDFSJFIZQHBIIHXBI", 7, 5, "DOZAKODOWANIATOJESTTEKST")]
        [TestCase("LFUTJSZUYHTCZDBXJ", 7, 5, "MARCINORZECHOWSKI")]
        public void DecodeCeaser(string input, int a, int b, string output)
        {
            var result = ceasarCipher.Decrypt(input, a, b);

            Assert.AreEqual(output, result);


        }
        [TestCase("CRYPTOGRAPHY", "BREAK", "DICPDPXVAZIP")]
        [TestCase("TestowanieSzyfrow", "BREAK", "UVWTYXRRIOTQCFBPN")]
        [TestCase("Kryptografia", "BREAK", "LICPDPXVAPJR")]
        [TestCase("SiecKomputerowa", "BREAK", "TZICUPDTUDFISWK")]
        [TestCase("DoZakodowaniaTojestTekst", "BREAK", "EFDAUPUSWKOZETYKVWTDFBWT")]
        [TestCase("MARCINORZECHOWSKI", "SZYFROWANIE", "EZPHZBKRMMGZNUXBW")]
        public void EncodeVigenere(string input, string key, string output)
        {
            var result = vigenere.Encrypt(input, key);

            Assert.AreEqual(output, result);

        }
        [TestCase("DICPDPXVAZIP", "BREAK", "CRYPTOGRAPHY")]
        [TestCase("UVWTYXRRIOTQCFBPN", "BREAK", "TESTOWANIESZYFROW")]
        [TestCase("LICPDPXVAPJR", "BREAK", "KRYPTOGRAFIA")]
        [TestCase("TZICUPDTUDFISWK", "BREAK", "SIECKOMPUTEROWA")]
        [TestCase("EFDAUPUSWKOZETYKVWTDFBWT", "BREAK", "DOZAKODOWANIATOJESTTEKST")]
        [TestCase("EZPHZBKRMMGZNUXBW", "SZYFROWANIE", "MARCINORZECHOWSKI")]
        public void DecodeVigenere(string input, string key, string output)
        {
            var result = vigenere.Decrypt(input, key);

            Assert.AreEqual(output, result);

        }
        [TestCase("11101001", "0010", "1001", "10010011")]
        [TestCase("11101001", "0011", "0110", "01010000")]
        [TestCase("1101011011001100", "110011", "101101", "1100001111110011")]
        [TestCase("1001111111110101", "0110110", "1111000", "1010111001111001")]
        [TestCase("1100111100110110", "10101110", "11100001", "1101000101000000")]
       
        public void EncodeSSC(string input, string startState,string taps, string output)
        {
            synchronousStreamCipher = new SynchronousStreamCipher(startState, taps);
            var result = synchronousStreamCipher.Encrypt(input);

            Assert.AreEqual(output, result);

        }
        [TestCase("11101001", "0010", "1001", "10010011")]
        [TestCase("11101001", "0011", "0110", "01010000")]
        [TestCase("1101011011001100", "110011", "101101", "1100001111110011")]
        [TestCase("1001111111110101", "0110110", "1111000", "1010111001111001")]
        [TestCase("1100111100110110", "10101110", "11100001", "1101000101000000")]
        public void DecodeSSC(string input, string startState,string taps, string output)
        {
            synchronousStreamCipher = new SynchronousStreamCipher(startState, taps);
            var result = synchronousStreamCipher.Decrypt(input);

            Assert.AreEqual(output, result);

        }
        [TestCase("11101001", "0011", "1001", "00110011")]
        [TestCase("11101001", "0011", "0110", "01111000")]
        [TestCase("1101011011001100", "110011", "101101", "1001110010111100")]
        [TestCase("1001111111110101", "0110110", "1111000", "1110011100110110")]
        [TestCase("1100111100110110", "10101110", "11100001", "1011110000001111")]
        public void EncodeCiphertextAutokey(string input, string startState,string taps, string output)
        {
    
            var result = ciphertextAutokey.Encrypt(input,startState,taps);
            Assert.AreEqual(output, result);

        }
        [TestCase("00110011", "0011", "1001", "11101001")]
        [TestCase("01111000", "0011", "0110", "11101001")]
        [TestCase("1001110010111100", "110011", "101101", "1101011011001100")]
        [TestCase("1110011100110110", "0110110", "1111000", "1001111111110101")]
        [TestCase("1011110000001111", "10101110", "11100001", "1100111100110110")]
        public void DecodeCiphertextAutokey(string input, string startState,string taps, string output)
        {
    
            var result = ciphertextAutokey.Decrypt(input,startState,taps);
            Assert.AreEqual(output, result);

        }

    }
}