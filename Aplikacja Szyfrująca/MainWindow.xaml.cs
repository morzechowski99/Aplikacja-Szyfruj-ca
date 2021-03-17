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
        private ICriptographyAlgorithm algorithm;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void RailFenceEncode(object sender, RoutedEventArgs e)
        {
            algorithm = new RailFence();
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
            algorithm = new RailFence();
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
    }
}
