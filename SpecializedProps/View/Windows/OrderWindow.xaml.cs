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

            MaterialCmb.DisplayMemberPath = "Name";
            MaterialCmb.SelectedValuePath = "Id";
            MaterialCmb.ItemsSource = App.context.Material.ToList();

            PaymentCmb.DisplayMemberPath = "Name";
            PaymentCmb.SelectedValuePath = "Id";
            PaymentCmb.ItemsSource = App.context.Payment.ToList();

            PickUpCmb.DisplayMemberPath = "Name";
            PickUpCmb.SelectedValuePath = "Id";
            PickUpCmb.ItemsSource = App.context.Branch.ToList();
        }

        private void AddOrderBtn_Click(object sender, RoutedEventArgs e)
        {
            if(string.IsNullOrEmpty(NameCustomerCmb.Text) && string.IsNullOrEmpty(MaterialCmb.Text) && string.IsNullOrEmpty(ImagePathTbl.Text) && string.IsNullOrEmpty(ProductionDateTb.Text) && string.IsNullOrEmpty(EndDateTb.Text) && string.IsNullOrEmpty(DirectionTb.Text) && string.IsNullOrEmpty(CommentTb.Text) || string.IsNullOrEmpty(AdressDeliveryTb.Text) || string.IsNullOrEmpty(PickUpCmb.Text) && string.IsNullOrEmpty(PaymentCmb.Text) && string.IsNullOrEmpty(SummTb.Text))
            {
                MessageBoxHelper.Warning("Заполните все поля!");
            }
            else
            {
                Order newOrder = new Order()
                {
                    Customer = NameCustomerCmb.SelectedItem as Customer,
                    FurnitureMaterial = MaterialCmb.SelectedItem as FurnitureMaterial,
                    PhotoSketch = ImagePathTbl.Text,
                    DateStart = (DateTime)ProductionDateTb.Text,
                    DateFinish = (DateTime)EndDateTb.Text,
                    Description = DirectionTb.Text,
                    Comment = CommentTb.Text,

                };
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
            addCustomerWindow.Hide();

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
    }
}
