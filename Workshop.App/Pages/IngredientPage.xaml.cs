using System.Windows.Controls;
using Workshop.App.ViewModels;

namespace Workshop.App
{
    /// <summary>
    /// Логика взаимодействия для IngredientPage.xaml
    /// </summary>
    public partial class IngredientPage : Page
    {
        public IngredientPage(IngredientViewModel viewModel)
        {
            DataContext = viewModel;
            InitializeComponent();
        }
    }
}
