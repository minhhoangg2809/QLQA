using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Quanly_quanan.ViewModel
{
    public class Taikhoan_ViewModel : BaseViewModel
    {
        private ObservableCollection<Model.Taikhoan> _List;

        public ObservableCollection<Model.Taikhoan> List
        {
            get { return _List; }
            set { _List = value; OnPropertyChanged(); }
        }

        private ObservableCollection<Model.Taikhoan> _DelList;

        public ObservableCollection<Model.Taikhoan> DelList
        {
            get { return _DelList; }
            set { _DelList = value; OnPropertyChanged(); }
        }

        private Model.Taikhoan _SelectedItem;

        public Model.Taikhoan SelectedItem
        {
            get { return _SelectedItem; }
            set { _SelectedItem = value; OnPropertyChanged(); }
        }


        #region Prop

        private string _Tennhanvien;

        public string Tennhanvien
        {
            get { return _Tennhanvien; }
            set { _Tennhanvien = value; OnPropertyChanged(); }
        }

        private string _Sodienthoai;

        public string Sodienthoai
        {
            get { return _Sodienthoai; }
            set { _Sodienthoai = value; OnPropertyChanged(); }
        }

        private string _Tendangnhap;

        public string Tendangnhap
        {
            get { return _Tendangnhap; }
            set { _Tendangnhap = value; OnPropertyChanged(); }
        }

        private string _Matkhau;

        public string Matkhau
        {
            get { return _Matkhau; }
            set { _Matkhau = value; OnPropertyChanged(); }
        }

        private string _Nhaplaimatkhau;

        public string Nhaplaimatkhau
        {
            get { return _Nhaplaimatkhau; }
            set { _Nhaplaimatkhau = value; OnPropertyChanged(); }
        }

        private ObservableCollection<Model.Quyentruycap> _List_Quyen;

        public ObservableCollection<Model.Quyentruycap> List_Quyen
        {
            get { return _List_Quyen; }
            set { _List_Quyen = value; OnPropertyChanged(); }
        }

        private Model.Quyentruycap _SQuyen;

        public Model.Quyentruycap SQuyen
        {
            get { return _SQuyen; }
            set { _SQuyen = value; OnPropertyChanged(); }
        }


        #endregion

        #region Command

        public ICommand Load_Command { get; set; }

        public ICommand Search_Command { get; set; }

        public ICommand SortbyUserName_Command { get; set; }
        public ICommand SortbyRealName_Command { get; set; }
        public ICommand SortbyRole_Command { get; set; }

        public ICommand OpenformInsert_Command { get; set; }
        public ICommand PasswordChange_Command { get; set; }
        public ICommand RePasswordChange_Command { get; set; }
        public ICommand Insert_Command { get; set; }

        public ICommand OpenformMultiDelete_Command { get; set; }
        public ICommand AddDelList_Command { get; set; }
        public ICommand RemoveDelList_Command { get; set; }
        public ICommand MultiDelete_Command { get; set; }

        public ICommand OpenformUpdate_Command { get; set; }
        public ICommand Update_Command { get; set; }

        #endregion

        #region Login & Change Data

        private string _LoginUsername;

        public string LoginUsername
        {
            get { return _LoginUsername; }
            set { _LoginUsername = value; OnPropertyChanged(); }
        }

        private string _LoginPass;

        public string LoginPass
        {
            get { return _LoginPass; }
            set { _LoginPass = value; OnPropertyChanged(); }
        }

        private bool _RememberChecked;

        public bool RememberChecked
        {
            get { return _RememberChecked; }
            set { _RememberChecked = value; OnPropertyChanged(); }
        }


        private static Model.Taikhoan _CurrentUser;

        public static Model.Taikhoan CurrentUser
        {
            get { return _CurrentUser; }
            set { _CurrentUser = value; }
        }

        private string _CurPass;

        public string CurPass
        {
            get { return _CurPass; }
            set { _CurPass = value; OnPropertyChanged(); }
        }

        private string _CurrePass;

        public string CurrePass
        {
            get { return _CurrePass; }
            set { _CurrePass = value; OnPropertyChanged(); }
        }

        private string _Tendnmoi;

        public string Tendnmoi
        {
            get { return _Tendnmoi; }
            set { _Tendnmoi = value; OnPropertyChanged(); }
        }


        #endregion

        #region Login & change Command

        public ICommand LoadLoginform_Command { get; set; }
        public ICommand CloseLoginform_Command { get; set; }

        public ICommand Login_Command { get; set; }
        public ICommand Logout_Command { get; set; }

        public ICommand GetPassLogin_Command { get; set; }

        public ICommand LoadInfor_Command { get; set; }
        public ICommand ChangeInfor_Command { get; set; }
        public ICommand CurPasswordChange_Command { get; set; }
        public ICommand CurRePasswordChange_Command { get; set; }

        #endregion]

        #region Dialogs

        private bool _OpenInsert;

        public bool OpenInsert
        {
            get { return _OpenInsert; }
            set { _OpenInsert = value; OnPropertyChanged(); }
        }

        private bool _OpenMultiDelete;

        public bool OpenMultiDelete
        {
            get { return _OpenMultiDelete; }
            set { _OpenMultiDelete = value; OnPropertyChanged(); }
        }

        private bool _OpenUpdate;

        public bool OpenUpdate
        {
            get { return _OpenUpdate; }
            set { _OpenUpdate = value; OnPropertyChanged(); }
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

        public Taikhoan_ViewModel()
        {
            List = new ObservableCollection<Model.Taikhoan>(Model.DataProvider.Ins.DB.Taikhoans);
            DelList = new ObservableCollection<Model.Taikhoan>();

            List_Quyen = new ObservableCollection<Model.Quyentruycap>(Model.DataProvider.Ins.DB.Quyentruycaps);
            SQuyen = List_Quyen.First();

            OpenInsert = false;
            OpenMultiDelete = false;
            IsActive = false;

            CloseDialog_Command = new RelayCommand<object>(p =>
            {
                return true;
            }, p =>
            {
                OpenInsert = false;
                OpenMultiDelete = false;
                OpenUpdate = false;
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
                List = new ObservableCollection<Model.Taikhoan>(Model.DataProvider.Ins.DB.Taikhoans);
                DelList = new ObservableCollection<Model.Taikhoan>();

                List_Quyen = new ObservableCollection<Model.Quyentruycap>(Model.DataProvider.Ins.DB.Quyentruycaps);


            });

            #endregion

            #region Insert

            OpenformInsert_Command = new RelayCommand<object>(p =>
            {
                if (OpenInsert == true || OpenMultiDelete == true)
                    return false;

                return true;
            }, p =>
            {
                OpenInsert = true;
            });

            PasswordChange_Command = new RelayCommand<PasswordBox>(p =>
            {
                if (p.Password == string.Empty)
                    return false;

                return true;
            }, p =>
            {
                Matkhau = p.Password;
            });

            RePasswordChange_Command = new RelayCommand<PasswordBox>(p =>
            {
                if (p.Password == string.Empty)
                    return false;

                return true;
            }, p =>
            {
                Nhaplaimatkhau = p.Password;
            });

            Insert_Command = new RelayCommand<object>(p =>
            {
                if (string.IsNullOrEmpty(Tendangnhap) || string.IsNullOrEmpty(Tennhanvien)
                                || string.IsNullOrEmpty(Matkhau) || string.IsNullOrEmpty(Nhaplaimatkhau) || string.IsNullOrEmpty(Sodienthoai))
                    return false;

                if (SQuyen == null)
                    return false;

                return true;
            }, p =>
            {
                if (Matkhau == Nhaplaimatkhau)
                {
                    if (Model.DataProvider.Ins.DB.Taikhoans.Where(x => x.ten_dangnhap == Tendangnhap).Count() == 0)
                    {
                        Model.Taikhoan item = new Model.Taikhoan()
                        {
                            ma_taikhoan = Guid.NewGuid().ToString(),
                            ten_dangnhap = Tendangnhap,
                            matkhau = Src.MyStaticMethods.MD5Hash(Matkhau),
                            tennhanvien = Tennhanvien,
                            sodienthoai = Sodienthoai,
                            ma_quyen = SQuyen.ma_quyen
                        };

                        Model.DataProvider.Ins.DB.Taikhoans.Add(item);
                        Model.DataProvider.Ins.DB.SaveChanges();

                        List.Insert(0, item);

                        OpenInsert = false;

                        IsActive = true;
                        Message = "Thêm mới thành công !!!";
                    }
                    else
                    {
                        OpenInsert = false;

                        IsActive = true;
                        Message = "Tên đăng nhập đã tồn tại !!!";
                    }
                }
                else
                {
                    OpenInsert = false;

                    IsActive = true;
                    Message = "Mật khẩu và xác nhận mật khẩu không trùng khớp !!!";
                }

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
                    List = new ObservableCollection<Model.Taikhoan>(List.Where(x => (x.ten_dangnhap.ToLower().Contains(p.Text.ToLower())) || (x.tennhanvien.ToLower().Contains(p.Text.ToLower())) || (x.sodienthoai.Contains(p.Text))));
                }
                else
                {
                    List = new ObservableCollection<Model.Taikhoan>(Model.DataProvider.Ins.DB.Taikhoans);
                }
            });

            #endregion

            #region Sort

            SortbyUserName_Command = new RelayCommand<object>(p =>
            {
                return true;
            }, p =>
            {
                var chk_list = new ObservableCollection<Model.Taikhoan>(List.OrderByDescending(x => x.ten_dangnhap));

                if (chk_list[0] == List[0])
                {
                    List = new ObservableCollection<Model.Taikhoan>(List.OrderBy(x => x.ten_dangnhap));
                }
                else
                {
                    List = chk_list;
                }
            });

            SortbyRealName_Command = new RelayCommand<object>(p =>
            {
                return true;
            }, p =>
            {
                var chk_list = new ObservableCollection<Model.Taikhoan>(List.OrderByDescending(x => x.tennhanvien));

                if (chk_list[0] == List[0])
                {
                    List = new ObservableCollection<Model.Taikhoan>(List.OrderBy(x => x.tennhanvien));
                }
                else
                {
                    List = chk_list;
                }
            });

            SortbyRole_Command = new RelayCommand<object>(p =>
            {
                return true;
            }, p =>
            {
                var chk_list = new ObservableCollection<Model.Taikhoan>(List.OrderByDescending(x => x.Quyentruycap.ten_quyen));

                if (chk_list[0] == List[0])
                {
                    List = new ObservableCollection<Model.Taikhoan>(List.OrderBy(x => x.Quyentruycap.ten_quyen));
                }
                else
                {
                    List = chk_list;
                }
            });

            #endregion

            #region MultiDelete

            OpenformMultiDelete_Command = new RelayCommand<object>(p =>
            {
                if (OpenInsert == true || OpenMultiDelete == true)
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
                DelList.Add(List.Where(x => x.ma_taikhoan == (p.Uid)).SingleOrDefault());
            });

            RemoveDelList_Command = new RelayCommand<CheckBox>(p =>
            {
                return true;
            }, p =>
            {
                DelList.Remove(List.Where(x => x.ma_taikhoan == (p.Uid)).SingleOrDefault());
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

                DelList = new ObservableCollection<Model.Taikhoan>();
                OpenMultiDelete = false;

                IsActive = true;
                Message = "Xóa thành công !!!";
            });

            #endregion

            #region Login

            LoadLoginform_Command = new RelayCommand<Window>(p =>
            {
                return true;
            }, p =>
             {
                 LoginUsername = string.Empty;
                 LoginPass = string.Empty;

                 if (!File.Exists("Pass.txt"))
                 {
                     FileStream fs;
                     fs = new FileStream("Pass.txt", FileMode.Create);
                     StreamWriter sWriter = new StreamWriter(fs, Encoding.UTF8);

                     sWriter.WriteLine("Hello World!");
                     sWriter.Flush();
                     fs.Close();
                 }

                 string[] lines = File.ReadAllLines("Pass.txt");
                 if (lines[lines.Length - 1] == "1")
                 {
                     LoginUsername = Src.MyStaticMethods.Base64Decode(lines[lines.Length - 3]);
                     LoginPass = Src.MyStaticMethods.Base64Decode(lines[lines.Length - 2]);
                     RememberChecked = true;
                 }

                 foreach (PasswordBox pb in Src.MyStaticMethods.FindVisualChildren<PasswordBox>(p))
                 {
                     if (pb.Name == "pb_login")
                     {
                         pb.Password = LoginPass;
                     }
                 }
             });

            GetPassLogin_Command = new RelayCommand<PasswordBox>(p =>
            {
                if (p.Password == string.Empty)
                    return false;

                return true;
            }, p =>
             {
                 LoginPass = p.Password;
             });

            Login_Command = new RelayCommand<Button>(p =>
            {
                if (string.IsNullOrEmpty(LoginUsername) || string.IsNullOrEmpty(LoginPass))
                    return false;

                return true;
            }, p =>
            {
                var pass = Src.MyStaticMethods.MD5Hash(LoginPass);
                int itemcount = Model.DataProvider.Ins.DB.Taikhoans.Where(x => x.ten_dangnhap == LoginUsername && x.matkhau == pass).Count();

                if (itemcount != 0)
                {
                    CheckRemember();

                    View.Manhinhchinh mahinhchinh = new View.Manhinhchinh();
                    mahinhchinh.Show();

                    Window wd = Src.MyStaticMethods.getWindowParent(p) as Window;
                    if (wd != null)
                    {
                        wd.Close();
                    }

                    CurrentUser = Model.DataProvider.Ins.DB.Taikhoans.Where(x => x.ten_dangnhap == LoginUsername && x.matkhau == pass).SingleOrDefault();
                }
                else
                {
                    IsActive = true;
                    Message = "Kiểm tra lại tên đăng nhập và mật khẩu";
                }
            });

            CloseLoginform_Command = new RelayCommand<object>(p =>
            {
                return true;
            }, p =>
            {
                Application.Current.Shutdown();
            });

            #endregion

            #region Change

            LoadInfor_Command = new RelayCommand<object>(p =>
            {
                return true;
            }, p =>
            {
                Tendnmoi = CurrentUser.ten_dangnhap;
            });

            CurPasswordChange_Command = new RelayCommand<PasswordBox>(p =>
            {
                if (p.Password == string.Empty)
                    return false;

                return true;
            }, p =>
            {
                CurPass = p.Password;
            });

            CurRePasswordChange_Command = new RelayCommand<PasswordBox>(p =>
            {
                if (p.Password == string.Empty)
                    return false;

                return true;
            }, p =>
            {
                CurrePass = p.Password;
            });

            ChangeInfor_Command = new RelayCommand<object>(p =>
            {
                if (string.IsNullOrEmpty(CurrentUser.ten_dangnhap) || string.IsNullOrEmpty(CurrentUser.sodienthoai))
                    return false;

                if (string.IsNullOrEmpty(Tendnmoi))
                    return false;

                return true;
            }, p =>
             {
                 Model.Taikhoan tk = Model.DataProvider.Ins.DB.Taikhoans.Where(x => x.ma_taikhoan == CurrentUser.ma_taikhoan).SingleOrDefault();
                 tk.tennhanvien = CurrentUser.tennhanvien;
                 tk.sodienthoai = CurrentUser.sodienthoai;

                 Model.DataProvider.Ins.DB.SaveChanges();


                 if (Model.DataProvider.Ins.DB.Taikhoans.Where(x => x.ten_dangnhap == Tendnmoi).Count() == 0)
                 {
                     tk.ten_dangnhap = CurrentUser.ten_dangnhap;
                     Model.DataProvider.Ins.DB.SaveChanges();
                 }

                 if (!string.IsNullOrEmpty(CurPass))
                 {
                     if (!string.IsNullOrEmpty(CurrePass) && CurrePass == CurrePass)
                     {
                         tk.matkhau = Src.MyStaticMethods.MD5Hash(CurPass);
                         Model.DataProvider.Ins.DB.SaveChanges();
                     }
                     else
                     {
                         IsActive = true;
                         Message = "Mật khẩu và xác nhận mật khẩu không trùng khớp !!!";
                     }
                 }

                 IsActive = true;
                 Message = "Đã cập nhật thông tin !!!";
             });

            #endregion

            #region Update Role

            OpenformUpdate_Command = new RelayCommand<Button>(p =>
            {
                if (OpenInsert == true || OpenMultiDelete == true || OpenUpdate == true)
                    return false;

                return true;
            }, p =>
            {
                SelectedItem = Model.DataProvider.Ins.DB.Taikhoans.Where(x => x.ma_taikhoan == (p.Uid)).SingleOrDefault();

                OpenUpdate = true;
            });

            Update_Command = new RelayCommand<object>(p =>
              {
                  if (SelectedItem == null)
                      return false;

                  if (SelectedItem.Quyentruycap == null)
                      return false;

                  return true;
              }, p =>
              {
                  var item = Model.DataProvider.Ins.DB.Taikhoans.Where(x => x.ma_taikhoan == SelectedItem.ma_taikhoan).SingleOrDefault();

                  item.Quyentruycap = SelectedItem.Quyentruycap;
                  Model.DataProvider.Ins.DB.SaveChanges();

                  OpenUpdate = false;

                  IsActive = true;
                  Message = "Đã cập nhật quyền truy cập !!!";

                  List = new ObservableCollection<Model.Taikhoan>(Model.DataProvider.Ins.DB.Taikhoans);
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
                foreach (var item in Model.DataProvider.Ins.DB.Taikhoans)
                {
                    while (item == DelList[i])
                    {
                        Model.DataProvider.Ins.DB.Taikhoans.Remove(item);
                        break;
                    }
                }
            }

            Model.DataProvider.Ins.DB.SaveChanges();
        }

        private void CheckRemember()
        {
            FileStream fs = new FileStream("Pass.txt", FileMode.Append);

            StreamWriter writeFile = new StreamWriter(fs, Encoding.UTF8);
            if (RememberChecked == true)
            {
                writeFile.WriteLine(Src.MyStaticMethods.Base64Encode(LoginUsername));
                writeFile.WriteLine(Src.MyStaticMethods.Base64Encode(LoginPass));
                writeFile.WriteLine("1");
                writeFile.Flush();
            }
            else writeFile.WriteLine("0");
            writeFile.Close();
        }

        #endregion

    }
}
