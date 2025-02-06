using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http.Headers;
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
using Microsoft.Win32;
using SpecializedProps.AppData;
using SpecializedProps.Model;

namespace SpecializedProps.View.Windows
{
    /// <summary>
    /// Логика взаимодействия для OrderWindow.xaml
    /// </summary>
    public partial class OrderWindow : Window
    {
        public OrderWindow()
        {
            InitializeComponent();

            NameCustomerCmb.DisplayMemberPath = "LastName";
            NameCustomerCmb.SelectedValuePath = "Id";
            NameCustomerCmb.ItemsSource = App.context.Customer.ToList();

            UserCmb.DisplayMemberPath = "LastName";
            UserCmb.SelectedValuePath = "Id";
            UserCmb.ItemsSource = App.context.User.ToList();

            MaterialCmb.DisplayMemberPath = "Name";
            MaterialCmb.SelectedValuePath = "Id";
            MaterialCmb.ItemsSource = App.context.Material.ToList();

            FurnitureCmb.DisplayMemberPath = "Name";
            FurnitureCmb.SelectedValuePath = "Id";
            FurnitureCmb.ItemsSource = App.context.Furniture.ToList();

            PaymentCmb.DisplayMemberPath = "Name";
            PaymentCmb.SelectedValuePath = "Id";
            PaymentCmb.ItemsSource = App.context.Payment.ToList();

            PickUpCmb.DisplayMemberPath = "Adress";
            PickUpCmb.SelectedValuePath = "Id";
            PickUpCmb.ItemsSource = App.context.Branch.ToList();

            StatusOrderCmb.DisplayMemberPath = "Name";
            StatusOrderCmb.SelectedValuePath = "Id";
            StatusOrderCmb.ItemsSource = App.context.StatusOrder.ToList();

        }

        private void AddOrderBtn_Click(object sender, RoutedEventArgs e)
        {
            if(string.IsNullOrEmpty(NameCustomerCmb.Text) && string.IsNullOrEmpty(UserCmb.Text) && string.IsNullOrEmpty(MaterialCmb.Text) && string.IsNullOrEmpty(FurnitureCmb.Text) && string.IsNullOrEmpty(ImagePathTbl.Text) && ProductionDateDp.SelectedDate == null && EndDateDp.SelectedDate == null && string.IsNullOrEmpty(AdressDeliveryTb.Text) || string.IsNullOrEmpty(PickUpCmb.Text) && string.IsNullOrEmpty(PaymentCmb.Text) && string.IsNullOrEmpty(SummTb.Text) && string.IsNullOrEmpty(StatusOrderCmb.Text))
            {
                MessageBoxHelper.Warning("Заполните все поля!");
            }
            else
            {
                string orderId = App.context.Order.Max(o => o.Id);
                int newOrderId = Convert.ToInt32((orderId.Remove(0, 1)));



                Order newOrder = new Order()
                {
                    Id = $"A{newOrderId + 1}",
                    IdCustomer = (NameCustomerCmb.SelectedItem as Customer).Id,
                    IdUser = (UserCmb.SelectedItem as User).Id,
                    IdMaterial = (MaterialCmb.SelectedItem as Material).Id,
                    IdFurniture = (FurnitureCmb.SelectedItem as Furniture).Id,
                    PhotoSketch = ImagePathTbl.Text,
                    DateStart = ProductionDateDp.SelectedDate.Value,
                    DateFinish = EndDateDp.SelectedDate.Value,
                    Description = DirectionTb.Text,
                    Comment = CommentTb.Text,
                    IdStatusOrder = (StatusOrderCmb.SelectedItem as StatusOrder).Id,
                    Delivery = DeliveryRb.IsChecked == true ? true : false,
                    AdressDelivery = AdressDeliveryTb.Text,
                    IdPayment = (PaymentCmb.SelectedItem as Payment).Id,
                    Summ = Convert.ToDecimal(SummTb.Text)

                };
                App.context.Order.Add(newOrder);

                if (DeliveryRb.IsChecked == false) newOrder.IdBranch = (PickUpCmb.SelectedItem as Branch).Id;
                else newOrder.IdBranch = null;

                App.context.SaveChanges();
                MessageBoxHelper.Information("Заказ добавлен!");

                

            }
        }

        private void MaterialCmb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Material selectedMaterial = MaterialCmb.SelectedItem as Material;

            if (selectedMaterial != null)
            {
                SelectedMaterialsLb.Items.Add(selectedMaterial);
            }
        }

        private void SelectedMaterialsLb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SelectedMaterialsLb.Items.Remove(SelectedMaterialsLb.SelectedItem);
        }

        private void HyperlinkSketchTb_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            if (openFileDialog.ShowDialog() == true)
            {
                ImagePathTbl.Text = openFileDialog.FileName;
            }
        }

        private void AddCustomerBtn_Click(object sender, RoutedEventArgs e)
        {
            AddCustomerWindow addCustomerWindow = new AddCustomerWindow();
            addCustomerWindow.Show();
            this.Hide();

        }

        private void RadioButton_Unchecked(object sender, RoutedEventArgs e)
        {
            AdressDeliveryTb.IsEnabled = false;
            AdressDeliveryTb.Clear();
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            AdressDeliveryTb.IsEnabled = true;
        }

        private void RadioButton_Checked_1(object sender, RoutedEventArgs e)
        {
            PickUpCmb.IsEnabled = true;
        }

        private void RadioButton_Unchecked_1(object sender, RoutedEventArgs e)
        {
            PickUpCmb.IsEnabled = false;
        }

        private void BackHl_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow= new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
