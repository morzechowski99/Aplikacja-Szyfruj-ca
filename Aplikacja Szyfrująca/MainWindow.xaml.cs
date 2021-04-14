using Aplikacja_Szyfrująca.Critography;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Aplikacja_Szyfrująca
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
       
        public MainWindow()
        {
            InitializeComponent();
        }

        private void RailFenceEncode(object sender, RoutedEventArgs e)
        {
            RailFence algorithm = new RailFence();
            string value = RailFenceEncodeInput.Text;
            int key;
            try
            {
                key = Int32.Parse(RailFenceEncodeKeyInput.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Podano złą wagę", "Zła waga", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            RailFenceEncodeOutput.Text = algorithm.Encrypt(value, key);
        }

        private void RailFenceDecode(object sender, RoutedEventArgs e)
        {
            RailFence algorithm = new RailFence();
            string value = RailFenceDecodeInput.Text;
            int key;
            try
            {
                key = Int32.Parse(RailFenceDecodeKeyInput.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Podano złą wagę", "Zła waga", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            RailFenceDecodeOutput.Text = algorithm.Decrypt(value, key);
        }

        private void MatrixShiftEncode(object sender, RoutedEventArgs e)
        {
            MatrixShift algorithm = new MatrixShift();
            string value = MatrixShiftEncodeInput.Text;
    
            MatrixShiftEncodeOutput.Text = algorithm.Encrypt(value);
        }

        private void MatrixShiftDecode(object sender, RoutedEventArgs e)
        {
            MatrixShift algorithm = new MatrixShift();
            string value = MatrixShiftDecodeInput.Text;

            MatrixShiftDecodeOutput.Text = algorithm.Decrypt(value);
        }

        private void MatrixShiftBEncode(object sender, RoutedEventArgs e)
        {
            MatrixShiftB algorithm = new MatrixShiftB();
            string value = MatrixShiftBEncodeInput.Text;
            string key = MatrixShiftBEncodeKeyInput.Text;

            MatrixShiftBEncodeOutput.Text = algorithm.Encrypt(value, key);
        }

        private void MatrixShiftBDecode(object sender, RoutedEventArgs e)
        {
            MatrixShiftB algorithm = new MatrixShiftB();
            string value = MatrixShiftBDecodeInput.Text;
            string key = MatrixShiftBDecodeKeyInput.Text;

            MatrixShiftBDecodeOutput.Text = algorithm.Decrypt(value, key);
        }

        private void MatrixShiftCEncode(object sender, RoutedEventArgs e)
        {
            MatrixShiftC algorithm = new MatrixShiftC();
            string value = MatrixShiftCEncodeInput.Text;
            string key = MatrixShiftCEncodeKeyInput.Text;

            MatrixShiftCEncodeOutput.Text = algorithm.Encrypt(value, key);
        }

        private void MatrixShiftCDecode(object sender, RoutedEventArgs e)
        {
            MatrixShiftC algorithm = new MatrixShiftC();
            string value = MatrixShiftCDecodeInput.Text;
            string key = MatrixShiftCDecodeKeyInput.Text;

            MatrixShiftCDecodeOutput.Text = algorithm.Decrypt(value, key);
        }

        private void CeasarCipherEncode(object sender, RoutedEventArgs e)
        {
            CeasarCipher ceasarCipher = new CeasarCipher();
            string value = CeasarCipherEncodeInput.Text;
            int key1, key2;
            try
            {
                key1 = Int32.Parse(CeasarCipherEncodeKey1Input.Text);
                key2 = Int32.Parse(CeasarCipherEncodeKey2Input.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Podaj liczby", "Zła waga", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            CeasarCipherEncodeOutput.Text = ceasarCipher.Encrypt(value, key1, key2);
        }

        private void CeasarCipherDecode(object sender, RoutedEventArgs e)
        {
            CeasarCipher ceasarCipher = new CeasarCipher();
            string value = CeasarCipherDecodeInput.Text;
            int key1, key2;
            try
            {
                key1 = Int32.Parse(CeasarCipherDecodeKey1Input.Text);
                key2 = Int32.Parse(CeasarCipherDecodeKey2Input.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Podaj liczby", "Zła waga", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            CeasarCipherDecodeOutput.Text = ceasarCipher.Decrypt(value, key1, key2);
        }

        private void VigenereEncode(object sender, RoutedEventArgs e)
        {
            Vigenere vigenere = new Vigenere();
            string value = VigenereEncodeInput.Text;
            string key = VigenereEncodeKeyInput.Text;

            VigenereEncodeOutput.Text = vigenere.Encrypt(value, key);
        }

        private void VigenereDecode(object sender, RoutedEventArgs e)
        {
            Vigenere vigenere = new Vigenere();
            string value = VigenereDecodeInput.Text;
            string key = VigenereDecodeKeyInput.Text;

            VigenereDecodeOutput.Text = vigenere.Decrypt(value, key);
        }

        private void SSCEncode(object sender, RoutedEventArgs e)
        {
            string seed = SSCSeedEncodeInput.Text;
            string polynomial = SSCPolynomialEncodeInput.Text;
            string word = SSCEncodeInput.Text;
            SynchronousStreamCipher cipher = new SynchronousStreamCipher(seed, polynomial);

            SSCEncodeOutput.Text = cipher.Encrypt(word);

        }

        private void SSCDecode(object sender, RoutedEventArgs e)
        {
            string seed = SSCSeedDecodeInput.Text;
            string polynomial = SSCPolynomialDecodeInput.Text;
            string word = SSCDecodeInput.Text;
            SynchronousStreamCipher cipher = new SynchronousStreamCipher(seed, polynomial);

            SSCDecodeOutput.Text = cipher.Decrypt(word);
        }

        private void CiphertextAutokeyEncode(object sender, RoutedEventArgs e)
        {
            CiphertextAutokey ciphertextAutokey = new CiphertextAutokey();
            string seed = CiphertextAutokeySeedEncodeInput.Text;
            string polynomial = CiphertextAutokeyPolynomialEncodeInput.Text;
            string word = CiphertextAutokeyEncodeInput.Text;

            CiphertextAutokeyEncodeOutput.Text = ciphertextAutokey.Encrypt(word, seed, polynomial);
        }

        private void CiphertextAutokeyDecode(object sender, RoutedEventArgs e)
        {
            CiphertextAutokey ciphertextAutokey = new CiphertextAutokey();
            string seed = CiphertextAutokeySeedDecodeInput.Text;
            string polynomial = CiphertextAutokeyPolynomialDecodeInput.Text;
            string word = CiphertextAutokeyDecodeInput.Text;

            CiphertextAutokeyDecodeOutput.Text = ciphertextAutokey.Decrypt(word, seed, polynomial);
        }
    }
}
