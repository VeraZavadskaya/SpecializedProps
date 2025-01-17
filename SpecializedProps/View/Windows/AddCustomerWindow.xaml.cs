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
    /// Логика взаимодействия для AddCustomerWindow.xaml
    /// </summary>
    public partial class AddCustomerWindow : Window
    {
        public AddCustomerWindow()
        {
            InitializeComponent();
        }

        private void AddCustomerBtn_Click(object sender, RoutedEventArgs e)
        {
            if(string.IsNullOrEmpty(LastNameTb.Text)&& string.IsNullOrEmpty(FirstNameTb.Text) && string.IsNullOrEmpty(MiddleNameTb.Text) && string.IsNullOrEmpty(NumberPhoneTb.Text) && string.IsNullOrEmpty(EmailTb.Text) && string.IsNullOrEmpty(AdressTb.Text) && string.IsNullOrEmpty(PasportTb.Text))
            {
                MessageBoxHelper.Warning("Заполните все поля!");
            }
            else
            {
                Customer newCustomer = new Customer()
                {
                    LastName = LastNameTb.Text,
                    FirstName = FirstNameTb.Text,
                    MiddleName = MiddleNameTb.Text,
                    NumberPhone = NumberPhoneTb.Text,
                    Email = EmailTb.Text,
                    Adress = AdressTb.Text,
                    Pasport = PasportTb.Text
                };

                App.context.Customer.Add(newCustomer);
                App.context.SaveChanges();
                MessageBoxHelper.Information("Заказчик добавлен!");


            }
        }
    }
}
