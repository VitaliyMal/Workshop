using System.Windows;
using System.Windows.Controls;
using Workshop.App.ViewModels;

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
