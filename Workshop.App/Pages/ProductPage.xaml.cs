using System.Windows;
using System.Windows.Controls;
using Workshop.App.ViewModels;
using static Workshop.App.New_Customer_Window;

namespace Workshop.App
{
    /// <summary>
    /// Логика взаимодействия для ProductPage.xaml
    /// </summary>
    public partial class ProductPage : Page
    {
        private ProductViewModel _viewModel;
        public ProductPage(ProductViewModel viewModel)
        {
            _viewModel = viewModel;
            DataContext = _viewModel;
            InitializeComponent();
        }
        private void Add_Click_Window(object sender, RoutedEventArgs e)
        {
            //New_Customer_Window new_Customer_Window = new New_Customer_Window(_viewModel, FormType.Add);
            //Nullable<bool> dialogResult = new_Customer_Window.ShowDialog();
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            //New_Customer_Window new_Customer_Window = new New_Customer_Window(_viewModel, FormType.Edit);
            //Nullable<bool> dialogResult = new_Customer_Window.ShowDialog();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            //_viewModel.DeleteCommand.Execute(null);
        }
    }
}
