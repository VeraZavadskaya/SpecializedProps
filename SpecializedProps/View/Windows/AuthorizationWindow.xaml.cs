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
using System.Windows.Shapes;
using SpecializedProps.AppData;
using SpecializedProps.Model;

namespace SpecializedProps.View.Windows
{
    /// <summary>
    /// Логика взаимодействия для AuthorizationWindow.xaml
    /// </summary>
    public partial class AuthorizationWindow : Window
    {
        public AuthorizationWindow()
        {
            InitializeComponent();

            LoadUserData();
        }


        /// <summary>
        /// Функция производит загрузку данных пользователя из памяти приложения в поля для ввода.
        /// </summary>
        private void LoadUserData()
        {
            if(Properties.Settings.Default.LoginValue != string.Empty)
            {
                LoginTb.Text = Properties.Settings.Default.LoginValue;
                PasswordPb.Password = Properties.Settings.Default.PasswordValue;
            }
        }


        private void EnterBtn_Click(object sender, RoutedEventArgs e)
        {
            if(string.IsNullOrEmpty(LoginTb.Text) && string.IsNullOrEmpty(PasswordPb.Password))
            {
                MessageBoxHelper.Error("Введите логин и пароль!");
            }
            if(string.IsNullOrEmpty(LoginTb.Text) || string.IsNullOrEmpty(PasswordPb.Password))
            {
                MessageBoxHelper.Error("Введите логин или пароль!");
            }
             User newUser = App.context.User.FirstOrDefault(u => u.Email == LoginTb.Text && u.Password == PasswordPb.Password);

            if(newUser != null)
            {
                if (RememberMeCb.IsChecked == true)
                {
                    Properties.Settings.Default.LoginValue = LoginTb.Text;
                    Properties.Settings.Default.PasswordValue = PasswordPb.Password;
                }
                else
                {
                    Properties.Settings.Default.LoginValue = string.Empty;
                    Properties.Settings.Default.PasswordValue = string.Empty;
                }

                Properties.Settings.Default.Save();

                App.currentUser = newUser;
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                this.Close();
            }
            else
            {
                MessageBoxHelper.Warning("Пользователь не найден!");
            }
        }

    }
}
