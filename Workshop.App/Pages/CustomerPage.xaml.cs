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
using Workshop.App.ViewModels;
using Workshop.Core.Data;
using Workshop.Core.Service;

namespace Workshop.App
{
    /// <summary>
    /// Логика взаимодействия для CustomerPage.xaml
    /// </summary>
    public partial class CustomerPage : Page
    {
        private CustomerViewModel _viewModel; // Чтобы сохранить ссылку на viewModel
        public CustomerPage(CustomerViewModel viewModel)
        {
            _viewModel = viewModel;
            DataContext = _viewModel;
            InitializeComponent();
        }

        private void Add_Click_Window(object sender, RoutedEventArgs e)
        {
            New_Customer_Window new_Customer_Window = new New_Customer_Window(_viewModel);
            Nullable<bool> dialogResult = new_Customer_Window.ShowDialog();
        }
    }
}
