using System.Windows.Controls;
using Workshop.App.ViewModels;

namespace Workshop.App
{
    /// <summary>
    /// Логика взаимодействия для ProductPage.xaml
    /// </summary>
    public partial class ProductPage : Page
    {
        public ProductPage(ProductViewModel viewModel)
        {
            DataContext = viewModel;
            InitializeComponent();
        }
    }
}
