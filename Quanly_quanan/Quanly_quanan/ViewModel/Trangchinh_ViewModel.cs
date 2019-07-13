using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace Quanly_quanan.ViewModel
{
    public class Trangchinh_ViewModel : BaseViewModel
    {
        private ObservableCollection<Model.Ban> _List_Ban;

        public ObservableCollection<Model.Ban> List_Ban
        {
            get { return _List_Ban; }
            set { _List_Ban = value; OnPropertyChanged(); }
        }

        private Model.Ban _SelectedTable;

        public Model.Ban SelectedTable
        {
            get { return _SelectedTable; }
            set
            {
                _SelectedTable = value;
                if (_SelectedTable != null)
                {
                    Selected_Hoadon = getHoadon(_SelectedTable.ma_ban);
                }
                OnPropertyChanged();
            }
        }

        private Model.Hoadon _Selected_Hoadon;

        public Model.Hoadon Selected_Hoadon
        {
            get { return _Selected_Hoadon; }
            set
            {
                _Selected_Hoadon = value;
                if (_Selected_Hoadon != null)
                {
                    List_FoodinBill = new ObservableCollection<Model.Chitiethoadon>(Model.DataProvider.Ins.DB.Chitiethoadons.Where(x => x.ma_hoadon == _Selected_Hoadon.ma_hoadon));

                    NgaydatVn = Src.MyStaticMethods.FormatDateString(Selected_Hoadon.ngay_dat);
                    NgaytraVn = Src.MyStaticMethods.FormatDateString(Selected_Hoadon.ngay_thanhtoan);
                }
                OnPropertyChanged();
            }
        }

        private ObservableCollection<Model.Chitiethoadon> _List_FoodinBill;

        public ObservableCollection<Model.Chitiethoadon> List_FoodinBill
        {
            get { return _List_FoodinBill; }
            set { _List_FoodinBill = value; OnPropertyChanged(); }
        }


        #region Goi mon
        private ObservableCollection<Model.Danhmuc> _List_Danhmuc;

        public ObservableCollection<Model.Danhmuc> List_Danhmuc
        {
            get { return _List_Danhmuc; }
            set { _List_Danhmuc = value; OnPropertyChanged(); }
        }

        private Model.Danhmuc _SDanhmuc;

        public Model.Danhmuc SDanhmuc
        {
            get { return _SDanhmuc; }
            set { _SDanhmuc = value; OnPropertyChanged(); }
        }

        private ObservableCollection<Model.Sanpham> _List_Monan;

        public ObservableCollection<Model.Sanpham> List_Monan
        {
            get { return _List_Monan; }
            set { _List_Monan = value; OnPropertyChanged(); }
        }

        private Model.Sanpham _SMonan;

        public Model.Sanpham SMonan
        {
            get { return _SMonan; }
            set { _SMonan = value; OnPropertyChanged(); }
        }

        private string _Soluong;

        public string Soluong
        {
            get { return _Soluong; }
            set { _Soluong = value; OnPropertyChanged(); }
        }


        #endregion

        #region Thong tin Ban

        private string _Tenkhachhang;

        public string Tenkhachhang
        {
            get { return _Tenkhachhang; }
            set { _Tenkhachhang = value; OnPropertyChanged(); }
        }

        private string _Sodienthoai;

        public string Sodienthoai
        {
            get { return _Sodienthoai; }
            set { _Sodienthoai = value; OnPropertyChanged(); }
        }

        private string _Ngaytra;

        public string Ngaytra
        {
            get { return _Ngaytra; }
            set { _Ngaytra = value; OnPropertyChanged(); }
        }

        private string _NgaytraVn;

        public string NgaytraVn
        {
            get { return _NgaytraVn; }
            set { _NgaytraVn = value; OnPropertyChanged(); }
        }

        private string _Ngaydat;

        public string Ngaydat
        {
            get { return _Ngaydat; }
            set { _Ngaydat = value; OnPropertyChanged(); }
        }

        private string _NgaydatVn;

        public string NgaydatVn
        {
            get { return _NgaydatVn; }
            set { _NgaydatVn = value; OnPropertyChanged(); }
        }

        private string _Tongtien;

        public string Tongtien
        {
            get { return _Tongtien; }
            set { _Tongtien = value; OnPropertyChanged(); }
        }

        #endregion

        #region Dialogs

        private bool _Open_datban;

        public bool Open_datban
        {
            get { return _Open_datban; }
            set { _Open_datban = value; OnPropertyChanged(); }
        }

        private bool _Open_goimon;

        public bool Open_goimon
        {
            get { return _Open_goimon; }
            set { _Open_goimon = value; OnPropertyChanged(); }
        }

        private bool _Open_thanhtoan;

        public bool Open_thanhtoan
        {
            get { return _Open_thanhtoan; }
            set { _Open_thanhtoan = value; OnPropertyChanged(); }
        }

        public ICommand CloseDialog_Command { get; set; }


        #endregion

        #region Commands

        public ICommand Print_Command { get; set; }
        public ICommand ClosePrinter_Command { get; set; }

        public ICommand Openform_datban_Command { get; set; }
        public ICommand Datban_Command { get; set; }

        public ICommand Openform_goimon_Command { get; set; }
        public ICommand Goimon_Command { get; set; }
        public ICommand SelectionCategoryChange_Command { get; set; }

        public ICommand Openform_thanhtoan_Command { get; set; }
        public ICommand Thanhtoan_Command { get; set; }

        public ICommand Load_Command { get; set; }

        public ICommand ListTableinBillchange_Command { get; set; }

        #endregion

        public Trangchinh_ViewModel()
        {
            List_Ban = new ObservableCollection<Model.Ban>(Model.DataProvider.Ins.DB.Bans.ToList().OrderBy(x => x.ten_ban));

            List_Danhmuc = new ObservableCollection<Model.Danhmuc>(Model.DataProvider.Ins.DB.Danhmucs);
            List_Monan = new ObservableCollection<Model.Sanpham>();
            Soluong = "0";

            SelectedTable = List_Ban.First();

            Open_datban = false;
            Open_goimon = false;
            Open_thanhtoan = false;

            Ngaydat = DateTime.Today.ToShortDateString();
            Ngaytra = DateTime.Today.ToShortDateString();

            CloseDialog_Command = new RelayCommand<MaterialDesignThemes.Wpf.DialogHost>(p =>
            {
                return true;
            }, p =>
            {
                p.IsOpen = false;
            });

            #region Load

            Load_Command = new RelayCommand<object>(p =>
            {
                return true;
            }, p =>
            {
                List_Ban = new ObservableCollection<Model.Ban>(Model.DataProvider.Ins.DB.Bans.ToList().OrderBy(x => x.ten_ban));
                List_Danhmuc = new ObservableCollection<Model.Danhmuc>(Model.DataProvider.Ins.DB.Danhmucs);
            });

            ListTableinBillchange_Command = new RelayCommand<object>(p =>
            {
                return true;
            }, p =>
             {
                 Open_datban = false;
                 Open_goimon = false;
                 Open_thanhtoan = false;

                 SDanhmuc = null;
                 SMonan = null;
                 Soluong = "0";
             });

            #endregion

            #region Dat ban

            Openform_datban_Command = new RelayCommand<object>(p =>
            {
                if (Open_datban == true || Open_goimon == true || Open_thanhtoan == true)
                    return false;

                if (SelectedTable.tinhtrang == true)
                    return false;

                return true;
            }, p =>
             {
                 Open_datban = true;
             });

            Datban_Command = new RelayCommand<object>(p =>
            {
                return true;
            }, p =>
            {
                Model.Hoadon item = new Model.Hoadon()
                {
                    ma_hoadon = (Src.MyStaticMethods.RandomString(2, false) + Src.MyStaticMethods.RandomInt(4)),

                    ma_ban = SelectedTable.ma_ban,
                    ma_taikhoan = Taikhoan_ViewModel.CurrentUser.ma_taikhoan,

                    ngay_dat = Ngaydat,
                    ngay_thanhtoan = !string.IsNullOrEmpty(Ngaytra) ? Ngaytra : null,
                    khachhang = !string.IsNullOrEmpty(Tenkhachhang) ? Tenkhachhang : "Chưa điền",
                    sodienthoai_khachhang = !string.IsNullOrEmpty(Sodienthoai) ? Sodienthoai : "Chưa điền",

                    tinhtrang = false
                };

                Model.DataProvider.Ins.DB.Hoadons.Add(item);
                Model.DataProvider.Ins.DB.SaveChanges();

                Model.DataProvider.Ins.DB.Bans.Where(x => x.ma_ban == SelectedTable.ma_ban).Single().tinhtrang = true;
                Model.DataProvider.Ins.DB.SaveChanges();

                List_Ban = new ObservableCollection<Model.Ban>(Model.DataProvider.Ins.DB.Bans.OrderBy(x => x.ten_ban));
                Open_datban = false;

                Selected_Hoadon = item;

            });

            #endregion

            #region Goi mon

            Openform_goimon_Command = new RelayCommand<object>(p =>
            {
                if (Open_datban == true || Open_goimon == true || Open_thanhtoan == true)
                    return false;

                if (SelectedTable.tinhtrang == false)
                    return false;

                return true;
            }, p =>
            {
                Open_goimon = true;
            });

            SelectionCategoryChange_Command = new RelayCommand<object>(p =>
            {
                return true;
            }, p =>
            {
                if (SDanhmuc == null)
                {
                    List_Monan = new ObservableCollection<Model.Sanpham>();
                }
                else
                {
                    List_Monan = new ObservableCollection<Model.Sanpham>(Model.DataProvider.Ins.DB.Sanphams.Where(x => x.ma_danhmuc == SDanhmuc.ma_danhmuc));
                }
            });

            Goimon_Command = new RelayCommand<object>(p =>
            {
                if (string.IsNullOrEmpty(Soluong) || SMonan == null)
                    return false;

                int n;
                if (int.TryParse(Soluong, out n) == false)
                    return false;

                if (Convert.ToInt32(Soluong) <= 0)
                    return false;

                return true;

            }, p =>
            {
                var chk = CheckItem_inList(Selected_Hoadon.ma_hoadon, SMonan.ma_sanpham);

                if (chk == false)
                {
                    Model.Chitiethoadon cthd = new Model.Chitiethoadon()
                    {
                        ma_cthd = Guid.NewGuid().ToString(),
                        ma_hoadon = Selected_Hoadon.ma_hoadon,
                        ma_sanpham = SMonan.ma_sanpham,
                        soluong = Convert.ToInt32(Soluong)
                    };

                    Model.DataProvider.Ins.DB.Chitiethoadons.Add(cthd);
                    Model.DataProvider.Ins.DB.SaveChanges();

                    List_FoodinBill.Add(cthd);
                }
                else
                {
                    var item = Model.DataProvider.Ins.DB.Chitiethoadons.Where(x => x.ma_hoadon == Selected_Hoadon.ma_hoadon && x.ma_sanpham == SMonan.ma_sanpham).SingleOrDefault();

                    item.soluong += Convert.ToInt32(Soluong);

                    Model.DataProvider.Ins.DB.SaveChanges();

                    List_FoodinBill = new ObservableCollection<Model.Chitiethoadon>(Model.DataProvider.Ins.DB.Chitiethoadons.Where(x => x.ma_hoadon == Selected_Hoadon.ma_hoadon));
                }
            });

            #endregion

            #region Thanh toan

            Openform_thanhtoan_Command = new RelayCommand<object>(p =>
            {
                if (Open_datban == true || Open_goimon == true || Open_thanhtoan == true)
                    return false;

                if (SelectedTable.tinhtrang == false)
                    return false;

                return true;
            }, p =>
            {
                Open_thanhtoan = true;
            });

            Thanhtoan_Command = new RelayCommand<object>(p =>
            {
                if (Selected_Hoadon == null)
                    return false;

                if (Selected_Hoadon.khachhang == string.Empty || Selected_Hoadon.khachhang == "Chưa điền")
                    return false;

                return true;
            }, p =>
            {

                if (_List_FoodinBill.ToList().Count() != 0)
                {
                    double tongtien = 0;

                    foreach (var item in List_FoodinBill)
                    {
                        tongtien += (item.soluong) * (item.Sanpham.dongia);
                    }

                    Tongtien = tongtien.ToString();
                }
                else
                {
                    Tongtien = "0";
                }

                View.InPhieu phieu = new View.InPhieu();
                phieu.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                phieu.ShowDialog();

            });

            Print_Command = new RelayCommand<Grid>(p =>
            {
                return true;
            }, p =>
            {

                Model.DataProvider.Ins.DB.Hoadons.Where(x => x.ma_hoadon == Selected_Hoadon.ma_hoadon).SingleOrDefault().ngay_thanhtoan = DateTime.Today.ToShortDateString();
                Model.DataProvider.Ins.DB.SaveChanges();

                Model.DataProvider.Ins.DB.Hoadons.Where(x => x.ma_hoadon == Selected_Hoadon.ma_hoadon).SingleOrDefault().tinhtrang = true;
                Model.DataProvider.Ins.DB.SaveChanges();

                Model.DataProvider.Ins.DB.Bans.Where(x => x.ma_ban == SelectedTable.ma_ban).SingleOrDefault().tinhtrang = false;
                Model.DataProvider.Ins.DB.SaveChanges();

                try
                {
                    PrintDialog printDialog = new PrintDialog();
                    if (printDialog.ShowDialog() == true)
                    {
                        printDialog.PrintVisual(p, "invoice");
                    }

                    MessageBox.Show("Thành công !!!", "THÔNG BÁO");

                    List_Ban = new ObservableCollection<Model.Ban>(Model.DataProvider.Ins.DB.Bans.OrderBy(x => x.ten_ban));
                    List_FoodinBill = new ObservableCollection<Model.Chitiethoadon>();

                }
                catch (Exception) { MessageBox.Show("Có lỗi xảy ra !!!", "THÔNG BÁO"); };
            });

            ClosePrinter_Command = new RelayCommand<Window>(p =>
            {
                return true;
            }, p =>
            {
                if (p != null)
                {
                    p.Close();
                    Open_thanhtoan = false;
                }

            });


            #endregion

        }

        #region Methods

        private Model.Hoadon getHoadon(string maban)
        {
            return Model.DataProvider.Ins.DB.Hoadons.Where(x => x.ma_ban == maban && x.tinhtrang == false).SingleOrDefault();
        }

        private bool CheckItem_inList(string mahoadon, string masp)
        {
            var list = Model.DataProvider.Ins.DB.Chitiethoadons.Where(x => x.ma_hoadon == mahoadon).ToList();

            if (list.Where(x => x.ma_sanpham == masp).Count() != 0)
            {
                return true;
            }

            return false;
        }

        #endregion

    }
}
