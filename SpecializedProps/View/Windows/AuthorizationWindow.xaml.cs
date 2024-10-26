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
        }

        private void DirectorBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MenegerBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SpecialistBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void RememberMeCb_Click(object sender, RoutedEventArgs e)
        {

        }


        private void EnterBtn_Click(object sender, RoutedEventArgs e)
        {
            //    User user = App.context.User.FirstOrDefault(u => u.Email == LoginTb.Text && u.Password == PaswordPb.Password);

            //    if(user != null)
            //    {
            //        App.currentUser = user;
            MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                this.Close();
        //    }
        //    else
        //    {
        //        MessageBoxHelper.Warning("Пользователь не найден!");
        //    }
        }

    }
}
