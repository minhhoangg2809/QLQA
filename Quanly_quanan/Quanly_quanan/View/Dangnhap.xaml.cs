using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Shapes;

namespace Quanly_quanan.View
{
    /// <summary>
    /// Interaction logic for Dangnhap.xaml
    /// </summary>
    public partial class Dangnhap : Window
    {
        public Dangnhap()
        {
            InitializeComponent();

            this.MouseLeftButtonDown += Dangnhap_MouseLeftButtonDown;
        }

        private void Dangnhap_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                DragMove();
            }
            catch (Exception) {/**/};
        }

        private void ToggleButton_Checked(object sender, RoutedEventArgs e)
        {
            tb_pass.Text = pb_pass.Password;

            pb_pass.Visibility = Visibility.Hidden;
            tb_pass.Visibility = Visibility.Visible;
        }

        private void ToggleButton_Unchecked(object sender, RoutedEventArgs e)
        {
            pb_pass.Password = tb_pass.Text;

            tb_pass.Visibility = Visibility.Hidden;
            pb_pass.Visibility = Visibility.Visible;
        }

    }
}
