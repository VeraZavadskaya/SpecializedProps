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
using System.Windows.Navigation;
using System.Windows.Shapes;
using SpecializedProps.AppData;
using SpecializedProps.Model;
using SpecializedProps.View.Windows;

namespace SpecializedProps
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            InitializeComponent();

            if (App.currentUser.IdRole == 3)
            {
                CreateBtn.IsEnabled = false;
                CreateBtn.Visibility = Visibility.Collapsed;
            }

            BranchCmb.DisplayMemberPath = "Adress";
            BranchCmb.SelectedValuePath = "Id";
            BranchCmb.ItemsSource = App.context.Branch.ToList();

            AllMenuLv.ItemsSource = App.context.Order.ToList();

        }

        private void CreateBtn_Click(object sender, RoutedEventArgs e)
        {
            OrderWindow orderWindow = new OrderWindow();
            orderWindow.Show();
            Hide();
           
        }


        private void AllMenuHl_Click(object sender, RoutedEventArgs e)
        {
            AllMenuLv.ItemsSource = App.context.Order.ToList();
        }

        private void NewMenuHl_Click(object sender, RoutedEventArgs e)
        {
            AllMenuLv.ItemsSource = App.context.Order.Where(o => o.IdStatusOrder == 1).ToList();

        }

        private void SentMenuHl_Click(object sender, RoutedEventArgs e)
        {
            AllMenuLv.ItemsSource = App.context.Order.Where(o => o.IdStatusOrder == 2).ToList();
        }

        private void DecoratedMenuHl_Click(object sender, RoutedEventArgs e)
        {
            AllMenuLv.ItemsSource = App.context.Order.Where(o => o.IdStatusOrder == 3).ToList();
        }

        private void ReturnedMenuHl_Click(object sender, RoutedEventArgs e)
        {
            AllMenuLv.ItemsSource = App.context.Order.Where(o => o.IdStatusOrder == 4).ToList();
        }

        private void RunningMenuHl_Click(object sender, RoutedEventArgs e)
        {
            AllMenuLv.ItemsSource = App.context.Order.Where(o => o.IdStatusOrder == 5).ToList();
        }

        private void ExecutedMenuHl_Click(object sender, RoutedEventArgs e)
        {
            AllMenuLv.ItemsSource = App.context.Order.Where(o => o.IdStatusOrder == 6).ToList();
        }

        private void ShippedMenuHl_Click(object sender, RoutedEventArgs e)
        {
            AllMenuLv.ItemsSource = App.context.Order.Where(o => o.IdStatusOrder == 7).ToList();
        }

        private void CancelledMenuHl_Click(object sender, RoutedEventArgs e)
        {
            AllMenuLv.ItemsSource = App.context.Order.Where(o => o.IdStatusOrder == 8).ToList();
        }

        private void SearchTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (SearchTb.Text != string.Empty)
            {
                AllMenuLv.ItemsSource = App.context.Order.Where(o => o.Id == SearchTb.Text).ToList();
            }
            else
            {
                AllMenuLv.ItemsSource = App.context.Order.ToList();
            }
        }

        private void BranchCmb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Branch branch = BranchCmb.SelectedItem as Branch;
            if(BranchCmb.SelectedIndex == 0)
            {
                AllMenuLv.ItemsSource = App.context.Order.ToList();
            }
            else
            {
                AllMenuLv.ItemsSource=App.context.Order.Where(m => m.IdBranch == branch.Id).ToList();
            }
        }
    }
}
