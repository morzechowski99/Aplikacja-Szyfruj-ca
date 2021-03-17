using Aplikacja_Szyfrująca.Critography;
using NUnit.Framework;

namespace Aplikacja_Szyfrująca_Testy
{
    public class Tests
    {
        private RailFence railFence;
        [SetUp]
        public void Setup()
        {
            railFence = new RailFence();
        }

        [TestCase("CRYPTOGRAPHY", 3, "CTARPORPYYGH")]
        [TestCase("TestowanieSzyfrow", 5, "TiweneosaSrtwzfoy")]
        [TestCase("Kryptografia", 8, "Krypatiofgar")]
        [TestCase("SiecKomputerowa", 4, "SmoioprweKueact")]
        [TestCase("DoZakodowaniaTojestTekst", 7, "DaoiTtZnosaajkkweeoosTdt")]
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
        public void RailfenceDecode(string input, int key, string output)
        {
            var result = railFence.Decrypt(input, key);

            Assert.AreEqual(output, result);
        }
    }
}