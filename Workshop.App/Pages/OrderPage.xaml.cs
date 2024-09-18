using System.Windows.Controls;
using Workshop.App.ViewModels;

namespace Workshop.App
{
    /// <summary>
    /// Логика взаимодействия для OrderPage.xaml
    /// </summary>
    public partial class OrderPage : Page
    {
        public OrderPage(OrderViewModel viewModel)
        {
            DataContext = viewModel;
            InitializeComponent();
        }
    }
}
