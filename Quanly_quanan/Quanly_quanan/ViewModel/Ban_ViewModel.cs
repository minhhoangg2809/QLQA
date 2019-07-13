using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace Quanly_quanan.ViewModel
{
    public class Ban_ViewModel : BaseViewModel
    {
        private ObservableCollection<Model.Ban> _List;

        public ObservableCollection<Model.Ban> List
        {
            get { return _List; }
            set { _List = value; OnPropertyChanged(); }
        }

        private ObservableCollection<Model.Ban> _DelList;

        public ObservableCollection<Model.Ban> DelList
        {
            get { return _DelList; }
            set { _DelList = value; OnPropertyChanged(); }
        }

        private Model.Ban _SelectedItem;

        public Model.Ban SelectedItem
        {
            get { return _SelectedItem; }
            set { _SelectedItem = value; OnPropertyChanged(); }
        }

        #region Prop

        private string _Ten;

        public string Ten
        {
            get
            {
                return _Ten;
            }

            set
            {
                _Ten = value;
                OnPropertyChanged();
            }
        }


        #endregion

        #region Command

        public ICommand Load_Command { get; set; }

        public ICommand Search_Command { get; set; }

        public ICommand SortbyName_Command { get; set; }
        public ICommand SortbyStatus_Command { get; set; }

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


        public Ban_ViewModel()
        {
            List = new ObservableCollection<Model.Ban>(Model.DataProvider.Ins.DB.Bans);
            DelList = new ObservableCollection<Model.Ban>();

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
                List = new ObservableCollection<Model.Ban>(Model.DataProvider.Ins.DB.Bans);
                DelList = new ObservableCollection<Model.Ban>();

                OpenInsert = false;
                OpenUpdate = false;
                OpenDelete = false;
                OpenMultiDelete = false;
                IsActive = false;

                SelectedItem = null;
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
                    List = new ObservableCollection<Model.Ban>(List.Where(x => x.ten_ban.ToLower().Contains(p.Text.ToLower())));
                }
                else
                {
                    List = new ObservableCollection<Model.Ban>(Model.DataProvider.Ins.DB.Bans);
                }
            });

            #endregion

            #region Sort

            SortbyName_Command = new RelayCommand<object>(p =>
            {
                return true;
            }, p =>
            {
                var chk_list = new ObservableCollection<Model.Ban>(List.OrderByDescending(x => x.ten_ban));

                if (chk_list[0] == List[0])
                {
                    List = new ObservableCollection<Model.Ban>(List.OrderBy(x => x.ten_ban));
                }
                else
                {
                    List = chk_list;
                }
            });

            SortbyStatus_Command = new RelayCommand<object>(p =>
            {
                return true;
            }, p =>
            {
                var chk_list = new ObservableCollection<Model.Ban>(List.OrderByDescending(x => x.tinhtrang));

                if (chk_list[0] == List[0])
                {
                    List = new ObservableCollection<Model.Ban>(List.OrderBy(x => x.tinhtrang));
                }
                else
                {
                    List = chk_list;
                }
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
                if (string.IsNullOrEmpty(Ten))
                    return false;

                return true;
            }, p =>
            {
                Model.Ban item = new Model.Ban() { ma_ban = Src.MyStaticMethods.RandomString(10, false), ten_ban = Ten, tinhtrang = false };

                Model.DataProvider.Ins.DB.Bans.Add(item);
                Model.DataProvider.Ins.DB.SaveChanges();

                List.Insert(0, item);

                OpenInsert = false;

                Message = "Thêm mới thành công !!!";
                IsActive = true;
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
                SelectedItem = Model.DataProvider.Ins.DB.Bans.Where(x => x.ma_ban == (p.Uid)).SingleOrDefault();

                OpenUpdate = true;
            });

            Update_Command = new RelayCommand<object>(p =>
            {
                if (SelectedItem == null)
                    return false;

                if (string.IsNullOrEmpty(SelectedItem.ten_ban))
                    return false;

                return true;
            }, p =>
            {
                var item = Model.DataProvider.Ins.DB.Bans.Where(x => x.ma_ban == SelectedItem.ma_ban).SingleOrDefault();

                item.ten_ban = SelectedItem.ten_ban;
                Model.DataProvider.Ins.DB.SaveChanges();

                List = new ObservableCollection<Model.Ban>(Model.DataProvider.Ins.DB.Bans);

                OpenUpdate = false;

                SelectedItem = null;

                IsActive = true;
                Message = "Chỉnh sửa thành công !!!";
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
                SelectedItem = Model.DataProvider.Ins.DB.Bans.Where(x => x.ma_ban == (p.Uid)).SingleOrDefault();

                OpenDelete = true;
            });

            Delete_Command = new RelayCommand<object>(p =>
            {
                return true;
            }, p =>
            {
                Model.Ban item = Model.DataProvider.Ins.DB.Bans.Where(x => x.ma_ban == (SelectedItem.ma_ban)).SingleOrDefault();
                Model.DataProvider.Ins.DB.Bans.Remove(item);
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
                DelList.Add(List.Where(x => x.ma_ban == (p.Uid)).SingleOrDefault());
            });

            RemoveDelList_Command = new RelayCommand<CheckBox>(p =>
            {
                return true;
            }, p =>
            {
                DelList.Remove(List.Where(x => x.ma_ban == (p.Uid)).SingleOrDefault());
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

                DelList = new ObservableCollection<Model.Ban>();
                OpenMultiDelete = false;

                IsActive = true;
                Message = "Xóa thành công !!!";
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
                foreach (var item in Model.DataProvider.Ins.DB.Bans)
                {
                    while (item == DelList[i])
                    {
                        Model.DataProvider.Ins.DB.Bans.Remove(item);
                        break;
                    }
                }
            }

            Model.DataProvider.Ins.DB.SaveChanges();
        }

        #endregion
    }
}
