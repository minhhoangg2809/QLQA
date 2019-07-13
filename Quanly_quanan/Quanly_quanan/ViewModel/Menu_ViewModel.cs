using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Quanly_quanan.ViewModel
{
    public class Menu_ViewModel : BaseViewModel
    {
        public ICommand Select_Command { get; set; }

        public Menu_ViewModel()
        {
            Select_Command = new RelayCommand<ListView>(p =>
              {
                  return true;
              }, p =>
             {

                 foreach (ListViewItem item in Src.MyStaticMethods.FindVisualChildren<ListViewItem>(p))
                 {
                     BrushConverter bc = new BrushConverter();
                     item.Foreground = (Brush)bc.ConvertFrom("#FF5C99D6");
                 }

                 Window wd = Src.MyStaticMethods.getWindowParent(p) as Window;

                 ListViewItem selectedItem = p.SelectedItem as ListViewItem;
                 int i = Convert.ToInt32(selectedItem.Uid);

                 if (wd != null)
                 {
                     foreach (Frame item in Src.MyStaticMethods.FindVisualChildren<Frame>(wd))
                     {
                         if (item.Name == "main_content")
                         {
                             Dieuhuong(i, item);
                         }
                         break;
                     }
                 }

                 selectedItem.Foreground = Brushes.White;
             });
        }

        private void Dieuhuong(int i, Frame fr)
        {
            switch (i)
            {
                case 1:
                    fr.Content = new View.Pages.Page_trangchinh();
                    break;
                case 2:
                    fr.Content = new View.Pages.Page_danhmuc();
                    break;
                case 3:
                    fr.Content = new View.Pages.Page_doan();
                    break;
                case 4:
                    fr.Content = new View.Pages.Page_banan();
                    break;
                case 5:
                    if (Taikhoan_ViewModel.CurrentUser.ma_quyen == 1)
                    {
                        fr.Content = new View.Pages.Page_taikhoan();
                        break;
                    }
                    else
                    {
                        break;
                    }
                default:
                    break;
            }
        }
    }
}
