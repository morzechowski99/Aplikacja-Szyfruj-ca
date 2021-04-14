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
    }
}
