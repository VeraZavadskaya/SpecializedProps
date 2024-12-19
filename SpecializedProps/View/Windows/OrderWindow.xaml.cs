using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using Microsoft.Win32;
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

        private void DeliveryCb_Checked(object sender, RoutedEventArgs e)
        {
            AdressDeliveryTb.IsEnabled = true;
        }

        private void DeliveryCb_Unchecked(object sender, RoutedEventArgs e)
        {
            AdressDeliveryTb.IsEnabled = false;
            AdressDeliveryTb.Clear();
        }

        private void AddCustomerBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
