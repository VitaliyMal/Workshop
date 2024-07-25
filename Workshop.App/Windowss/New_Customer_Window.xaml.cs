using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using Workshop.App.ViewModels;
using Workshop.Core.Entity;
using Workshop.Core.Service;


namespace Workshop.App
{
    /// <summary>
    /// Логика взаимодействия для New_Customer_Window.xaml
    /// </summary>
    public partial class New_Customer_Window : Window
    {
        private CustomerViewModel _viewModel;
        public New_Customer_Window(CustomerViewModel viewModel)
        {
            _viewModel = viewModel;
            DataContext = _viewModel;
            InitializeComponent();
        }

        private void Accept_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Данные сохранены");
            this.DialogResult = true;
        }
    }
}
