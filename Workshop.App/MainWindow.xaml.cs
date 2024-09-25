using System.Windows;
using Workshop.App.ViewModels;
using Workshop.Core.Data.Remote;
using Workshop.Core.Service;

namespace Workshop.App
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private CustomerViewModel customerViewModel = new CustomerViewModel(new CustomerService(new CustomerRemoteDataSource()));
        private IngredientViewModel ingredientViewModel = new IngredientViewModel(new IngredientService(new IngredientRemoteDataSource()));
        private OrderViewModel orderViewModel = new OrderViewModel(new OrderService(new OrderRemoteDataSource()));
        private ProductViewModel productViewModel = new ProductViewModel(new ProductService(new ProductRemoteDataSource()));
        private Ingredient_TypeViewModel Ingredient_TypeViewModel= new Ingredient_TypeViewModel(new Ingredient_TypeService(new Ingredient_TypeRemoteDataSource()));
        private RecipeViewModel RecipeViewModel = new RecipeViewModel(new RecipeService(new RecipeRemoteDataSource()));

        

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