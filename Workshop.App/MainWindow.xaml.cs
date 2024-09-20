using System.Windows;
using Workshop.App.ViewModels;
using Workshop.Core.Service;

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