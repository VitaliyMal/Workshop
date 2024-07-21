using System.Runtime.CompilerServices;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Workshop.Core.Service;
using Workshop.Core.Data;
using Workshop.App.ViewModels;

namespace Workshop.App
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private CustomerViewModel customerViewModel = new CustomerViewModel(new CustomerService(new CustomerDataSource()));
        private IngredientViewModel ingredientViewModel = new IngredientViewModel(new IngredientService(new IngredientDataSource()));
        private OrderViewModel orderViewModel = new OrderViewModel(new OrderService(new OrderDataSource()));
        private ProductViewModel productViewModel = new ProductViewModel(new ProductService(new ProductDataSource()));

        public MainWindow()
        {
            InitializeComponent();
        }

        private void CustomerPage_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new CustomerPage(customerViewModel);
        }

        private void IngredientPage_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new IngredientPage(ingredientViewModel);
        }

        private void OrderPage_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new OrderPage(orderViewModel);
        }

        private void ProductPage_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new ProductPage(productViewModel);
        }
    }
}