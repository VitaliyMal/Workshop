using System.Windows;
using System.Windows.Controls;
using Workshop.App.ViewModels;

namespace Workshop.App
{
    /// <summary>
    /// Логика взаимодействия для IngredientPage.xaml
    /// </summary>
    public partial class IngredientPage : Page
    {
        private IngredientViewModel _viewModel; // Чтобы сохранить ссылку на viewModel
        public IngredientPage(IngredientViewModel viewModel)
        {
            _viewModel = viewModel;
            DataContext = _viewModel;
            InitializeComponent();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
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
