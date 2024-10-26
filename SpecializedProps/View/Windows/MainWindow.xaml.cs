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

            ListFrame.Navigate(new View.Pages.AllMenuPage());
            
        }

        private void CreateBtn_Click(object sender, RoutedEventArgs e)
        {
            OrderWindow orderWindow = new OrderWindow();
            orderWindow.Show();
            Hide();
           
        }

        private void SearchBtn_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void AllMenuHl_Click(object sender, RoutedEventArgs e)
        {
            ListFrame.Navigate(new View.Pages.AllMenuPage());
        }

        private void NewMenuHl_Click(object sender, RoutedEventArgs e)
        {
            ListFrame.Navigate(new View.Pages.NewMenuPage());
        }

        private void SentMenuHl_Click(object sender, RoutedEventArgs e)
        {
            ListFrame.Navigate(new View.Pages.SentMenuPage());
        }

        private void DecoratedMenuHl_Click(object sender, RoutedEventArgs e)
        {
            ListFrame.Navigate(new View.Pages.DecoratedMenuPage());
        }

        private void ReturnedMenuHl_Click(object sender, RoutedEventArgs e)
        {
            ListFrame.Navigate(new View.Pages.ReturnedMenuPage());
        }

        private void RunningMenuHl_Click(object sender, RoutedEventArgs e)
        {
            ListFrame.Navigate(new View.Pages.RunningMenuPage());
        }

        private void ExecutedMenuHl_Click(object sender, RoutedEventArgs e)
        {
            ListFrame.Navigate(new View.Pages.ExecutedMenuPage());
        }

        private void ShippedMenuHl_Click(object sender, RoutedEventArgs e)
        {
            ListFrame.Navigate(new View.Pages.ShippedMenuPage());
        }

        private void CancelledMenuHl_Click(object sender, RoutedEventArgs e)
        {
            ListFrame.Navigate(new View.Pages.CancelledMenuPage());
        }
    }
}
