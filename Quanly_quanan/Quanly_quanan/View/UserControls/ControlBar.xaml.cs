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

namespace Quanly_quanan.View.UserControls
{
    /// <summary>
    /// Interaction logic for ControlBar.xaml
    /// </summary>
    public partial class ControlBar : UserControl
    {
        public ControlBar()
        {
            InitializeComponent();
        }

        private void btn_user_Click(object sender, RoutedEventArgs e)
        {
            View.ThongtinTaikhoan tt = new View.ThongtinTaikhoan();
            tt.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            tt.ShowDialog();
        }
    }
}
