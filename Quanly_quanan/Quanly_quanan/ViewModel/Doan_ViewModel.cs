using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Collections.ObjectModel;

namespace Quanly_quanan.ViewModel
{
    public class Doan_ViewModel : BaseViewModel
    {
        private ObservableCollection<Model.Sanpham> _List;

        public ObservableCollection<Model.Sanpham> List
        {
            get { return _List; }
            set { _List = value; OnPropertyChanged(); }
        }

        private ObservableCollection<Model.Sanpham> _DelList;

        public ObservableCollection<Model.Sanpham> DelList
        {
            get { return _DelList; }
            set { _DelList = value; OnPropertyChanged(); }
        }

        private Model.Sanpham _SelectedItem;

        public Model.Sanpham SelectedItem
        {
            get { return _SelectedItem; }
            set { _SelectedItem = value; OnPropertyChanged(); }
        }

        #region Prop

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


        private string _Ten;

        public string Ten
        {
            get { return _Ten; }
            set { _Ten = value; OnPropertyChanged(); }
        }

        private string _Gia;

        public string Gia
        {
            get { return _Gia; }
            set { _Gia = value; OnPropertyChanged(); }
        }

        private string _Tendonvi;

        public string Tendonvi
        {
            get { return _Tendonvi; }
            set { _Tendonvi = value; OnPropertyChanged(); }
        }

        private string _Mota;

        public string Mota
        {
            get { return _Mota; }
            set { _Mota = value; OnPropertyChanged(); }
        }


        #endregion

        #region Command

        public ICommand Load_Command { get; set; }

        public ICommand Search_Command { get; set; }

        public ICommand SortbyName_Command { get; set; }
        public ICommand SortbyPrice_Command { get; set; }
        public ICommand SortbyCategory_Command { get; set; }
        public ICommand SortbyUnit_Command { get; set; }

        public ICommand OpenformInsert_Command { get; set; }
        public ICommand Insert_Command { get; set; }

        public ICommand OpenformUpdate_Command { get; set; }
        public ICommand Update_Command { get; set; }

        public ICommand OpenformDelete_Command { get; set; }
        public ICommand Delete_Command { get; set; }

        public ICommand OpenformMultiDelete_Command { get; set; }
        public ICommand AddDelList_Command { get; set; }
        public ICommand RemoveDelList_Command { get; set; }
        public ICommand MultiDelete_Command { get; set; }

        #endregion

        #region Filter Commands

        private Model.Danhmuc _SDanhmuc_Filter;

        public Model.Danhmuc SDanhmuc_Filter
        {
            get { return _SDanhmuc_Filter; }
            set { _SDanhmuc_Filter = value; }
        }

        public ICommand Filter_Command { get; set; }


        #endregion

        #region Dialogs

        private bool _OpenInsert;

        public bool OpenInsert
        {
            get { return _OpenInsert; }
            set { _OpenInsert = value; OnPropertyChanged(); }
        }

        private bool _OpenUpdate;

        public bool OpenUpdate
        {
            get { return _OpenUpdate; }
            set { _OpenUpdate = value; OnPropertyChanged(); }
        }

        private bool _OpenDelete;

        public bool OpenDelete
        {
            get { return _OpenDelete; }
            set { _OpenDelete = value; OnPropertyChanged(); }
        }

        private bool _OpenMultiDelete;

        public bool OpenMultiDelete
        {
            get { return _OpenMultiDelete; }
            set { _OpenMultiDelete = value; OnPropertyChanged(); }
        }

        public ICommand CloseDialog_Command { get; set; }

        #endregion

        #region Message

        private bool _IsActive;

        public bool IsActive
        {
            get { return _IsActive; }
            set { _IsActive = value; OnPropertyChanged(); }
        }

        private string _Message;

        public string Message
        {
            get { return _Message; }
            set { _Message = value; OnPropertyChanged(); }
        }


        public ICommand CloseAlert_Command { get; set; }

        #endregion

        public Doan_ViewModel()
        {
            List = new ObservableCollection<Model.Sanpham>(Model.DataProvider.Ins.DB.Sanphams);
            DelList = new ObservableCollection<Model.Sanpham>();
            List_Danhmuc = new ObservableCollection<Model.Danhmuc>(Model.DataProvider.Ins.DB.Danhmucs);

            OpenInsert = false;
            OpenUpdate = false;
            OpenDelete = false;
            OpenMultiDelete = false;
            IsActive = false;

            CloseDialog_Command = new RelayCommand<object>(p =>
            {
                return true;
            }, p =>
            {
                OpenInsert = false;
                OpenUpdate = false;
                OpenDelete = false;
                OpenMultiDelete = false;

                SelectedItem = null;
            });

            CloseAlert_Command = new RelayCommand<object>(p =>
            {
                return true;
            },
            p =>
            {
                IsActive = false;
            });

            #region Load

            Load_Command = new RelayCommand<object>(p =>
            {
                return true;
            }, p =>
            {
                List = new ObservableCollection<Model.Sanpham>(Model.DataProvider.Ins.DB.Sanphams);
                DelList = new ObservableCollection<Model.Sanpham>();

                List_Danhmuc = new ObservableCollection<Model.Danhmuc>(Model.DataProvider.Ins.DB.Danhmucs);

                OpenInsert = false;
                OpenUpdate = false;
                OpenDelete = false;
                OpenMultiDelete = false;
                IsActive = false;

                SelectedItem = null;
            });

            #endregion

            #region Insert

            OpenformInsert_Command = new RelayCommand<object>(p =>
            {
                if (Taikhoan_ViewModel.CurrentUser.ma_quyen != 1)
                    return false;

                if (OpenInsert == true || OpenUpdate == true || OpenDelete == true || OpenMultiDelete == true)
                    return false;

                return true;
            }, p =>
            {
                OpenInsert = true;
            });

            Insert_Command = new RelayCommand<object>(p =>
            {
                if (string.IsNullOrEmpty(Ten) || string.IsNullOrEmpty(Gia) || string.IsNullOrEmpty(Mota))
                    return false;

                int dongianhap = 0;
                if (!int.TryParse(Gia.Replace(" ", String.Empty), out dongianhap))
                    return false;

                if (SDanhmuc == null)
                    return false;

                return true;
            }, p =>
            {
                Model.Sanpham item = new Model.Sanpham()
                {
                    ma_sanpham = ((Src.MyStaticMethods.RandomString(2, false)) + (Src.MyStaticMethods.RandomInt(4))),
                    Danhmuc = SDanhmuc,
                    ten_sanpham = Ten,
                    dongia = Convert.ToDouble(Gia.Replace(" ", String.Empty)),
                    mota_sanpham = Mota,
                    tendonvi = Tendonvi
                };

                Model.DataProvider.Ins.DB.Sanphams.Add(item);
                Model.DataProvider.Ins.DB.SaveChanges();

                List.Insert(0, item);

                OpenInsert = false;

                IsActive = true;
                Message = "Thêm mới thành công !!!";
            });

            #endregion

            #region Update

            OpenformUpdate_Command = new RelayCommand<Button>(p =>
            {
                if (Taikhoan_ViewModel.CurrentUser.ma_quyen != 1)
                    return false;

                if (OpenInsert == true || OpenUpdate == true || OpenDelete == true || OpenMultiDelete == true)
                    return false;

                return true;
            }, p =>
            {
                SelectedItem = Model.DataProvider.Ins.DB.Sanphams.Where(x => x.ma_sanpham == (p.Uid)).SingleOrDefault();

                OpenUpdate = true;
            });

            Update_Command = new RelayCommand<object>(p =>
            {
                if (SelectedItem == null)
                    return false;

                int dongianhap = 0;
                if (!int.TryParse(SelectedItem.dongia.ToString().Replace(" ", String.Empty), out dongianhap))
                    return false;

                if (string.IsNullOrEmpty(SelectedItem.ten_sanpham) || string.IsNullOrEmpty(SelectedItem.mota_sanpham)||string.IsNullOrEmpty(SelectedItem.dongia.ToString()))
                    return false;

                if (SelectedItem.Danhmuc == null)
                    return false;

                return true;
            }, p =>
            {
                Model.Sanpham item = Model.DataProvider.Ins.DB.Sanphams.Where(x => x.ma_sanpham == SelectedItem.ma_sanpham).SingleOrDefault();

                item.Danhmuc = SelectedItem.Danhmuc;
                item.ten_sanpham = SelectedItem.ten_sanpham;
                item.dongia = SelectedItem.dongia;
                item.mota_sanpham = SelectedItem.mota_sanpham;
                item.tendonvi = SelectedItem.tendonvi;

                Model.DataProvider.Ins.DB.SaveChanges();

                List = new ObservableCollection<Model.Sanpham>(Model.DataProvider.Ins.DB.Sanphams);

                OpenUpdate = false;

                SelectedItem = null;

                IsActive = true;
                Message = "Chỉnh sửa thành công !!!";

            });

            #endregion

            #region Search

            Search_Command = new RelayCommand<TextBox>(p =>
            {
                return true;
            }, p =>
            {
                if (p.Text != string.Empty)
                {
                    List = new ObservableCollection<Model.Sanpham>(List.Where(x => (x.ten_sanpham.ToLower().Contains(p.Text.ToLower())) || (x.Danhmuc.ten_danhmuc.ToLower().Contains(p.Text.ToLower()))));
                }
                else
                {
                    List = new ObservableCollection<Model.Sanpham>(Model.DataProvider.Ins.DB.Sanphams);
                }
            });

            #endregion

            #region Sort

            SortbyName_Command = new RelayCommand<object>(p =>
            {
                return true;
            }, p =>
            {
                var chk_list = new ObservableCollection<Model.Sanpham>(List.OrderByDescending(x => x.ten_sanpham));

                if (chk_list[0] == List[0])
                {
                    List = new ObservableCollection<Model.Sanpham>(List.OrderBy(x => x.ten_sanpham));
                }
                else
                {
                    List = chk_list;
                }
            });

            SortbyPrice_Command = new RelayCommand<object>(p =>
            {
                return true;
            }, p =>
            {
                var chk_list = new ObservableCollection<Model.Sanpham>(List.OrderByDescending(x => x.dongia));

                if (chk_list[0] == List[0])
                {
                    List = new ObservableCollection<Model.Sanpham>(List.OrderBy(x => x.dongia));
                }
                else
                {
                    List = chk_list;
                }
            });

            SortbyUnit_Command = new RelayCommand<object>(p =>
              {
                  return true;
              }, p =>
             {
                 var chk_list = new ObservableCollection<Model.Sanpham>(List.OrderByDescending(x => x.tendonvi));

                 if (chk_list[0] == List[0])
                 {
                     List = new ObservableCollection<Model.Sanpham>(List.OrderBy(x => x.tendonvi));
                 }
                 else
                 {
                     List = chk_list;
                 }
             });


            SortbyCategory_Command = new RelayCommand<object>(p =>
            {
                return true;
            }, p =>
            {
                var chk_list = new ObservableCollection<Model.Sanpham>(List.OrderByDescending(x => x.Danhmuc.ten_danhmuc));

                if (chk_list[0] == List[0])
                {
                    List = new ObservableCollection<Model.Sanpham>(List.OrderBy(x => x.Danhmuc.ten_danhmuc));
                }
                else
                {
                    List = chk_list;
                }
            });

            #endregion

            #region Delete

            OpenformDelete_Command = new RelayCommand<Button>(p =>
            {
                if (Taikhoan_ViewModel.CurrentUser.ma_quyen != 1)
                    return false;

                if (OpenInsert == true || OpenUpdate == true || OpenDelete == true || OpenMultiDelete == true)
                    return false;

                return true;
            }, p =>
            {
                SelectedItem = Model.DataProvider.Ins.DB.Sanphams.Where(x => x.ma_sanpham == (p.Uid)).SingleOrDefault();

                OpenDelete = true;
            });

            Delete_Command = new RelayCommand<object>(p =>
            {
                return true;
            }, p =>
            {
                Model.Sanpham item = Model.DataProvider.Ins.DB.Sanphams.Where(x => x.ma_sanpham == (SelectedItem.ma_sanpham)).SingleOrDefault();
                Model.DataProvider.Ins.DB.Sanphams.Remove(item);
                Model.DataProvider.Ins.DB.SaveChanges();

                OpenDelete = false;

                List.Remove(item);

                IsActive = true;
                Message = "Xóa thành công !!!";
            });

            #endregion

            #region MultiDelete

            OpenformMultiDelete_Command = new RelayCommand<object>(p =>
            {
                if (Taikhoan_ViewModel.CurrentUser.ma_quyen != 1)
                    return false;

                if (OpenInsert == true || OpenUpdate == true || OpenMultiDelete == true || OpenDelete == true)
                    return false;

                if (DelList.Count() == 0)
                    return false;

                return true;
            }, p =>
            {
                OpenMultiDelete = true;
            });

            AddDelList_Command = new RelayCommand<CheckBox>(p =>
            {
                return true;
            }, p =>
            {
                DelList.Add(List.Where(x => x.ma_sanpham == (p.Uid)).SingleOrDefault());
            });

            RemoveDelList_Command = new RelayCommand<CheckBox>(p =>
            {
                return true;
            }, p =>
            {
                DelList.Remove(List.Where(x => x.ma_sanpham == (p.Uid)).SingleOrDefault());
            });

            MultiDelete_Command = new RelayCommand<object>(p =>
            {
                if (DelList.Count() == 0)
                    return false;

                return true;
            }, p =>
            {
                Removeforever_IteminDb();
                RemoveIteminList();

                DelList = new ObservableCollection<Model.Sanpham>();
                OpenMultiDelete = false;

                IsActive = true;
                Message = "Xóa thành công !!!";
            });

            #endregion

            #region Filter

            Filter_Command = new RelayCommand<object>(p =>
            {
                return true;
            }, p =>
             {
                 if (SDanhmuc_Filter != null)
                 {
                     List = new ObservableCollection<Model.Sanpham>(List.Where(x => x.Danhmuc == SDanhmuc_Filter));
                 }
                 else
                 {
                     List = new ObservableCollection<Model.Sanpham>(Model.DataProvider.Ins.DB.Sanphams);
                 }

             });

            #endregion
        }

        #region Methods

        private void RemoveIteminList()
        {
            for (int i = 0; i < List.Count(); i++)
            {
                while (DelList.Where(x => x == List[i]).Count() != 0)
                {
                    if (List[i] == List[List.Count() - 1])
                    {
                        List.Remove(List[i]);
                        break;
                    }
                    else
                    {
                        List.Remove(List[i]);
                    }
                };
            }
        }

        private void Removeforever_IteminDb()
        {
            for (int i = 0; i < DelList.Count(); i++)
            {
                foreach (var item in Model.DataProvider.Ins.DB.Sanphams)
                {
                    while (item == DelList[i])
                    {
                        Model.DataProvider.Ins.DB.Sanphams.Remove(item);
                        break;
                    }
                }
            }

            Model.DataProvider.Ins.DB.SaveChanges();
        }

        #endregion
    }
}
