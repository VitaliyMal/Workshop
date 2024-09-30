using MahApps.Metro.Controls;
using System.Windows;
using Workshop.App.ViewModels;
using Workshop.Core.Data.Remote;
using Workshop.Core.Service;


namespace Workshop.App
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        private Ingredient_TypeService ingredient_typeService = new Ingredient_TypeService(new Ingredient_TypeRemoteDataSource());
        private CustomerService customerService = new CustomerService(new CustomerRemoteDataSource());
        private IngredientService ingredientService = new IngredientService(new IngredientRemoteDataSource());
        private OrderService orderService = new OrderService(new OrderRemoteDataSource());
        private ProductService productService = new ProductService(new ProductRemoteDataSource());
        private RecipeService recipeService = new RecipeService(new RecipeRemoteDataSource());
        private CustomerViewModel customerViewModel;
        private Ingredient_TypeViewModel Ingredient_TypeViewModel;
        private IngredientViewModel ingredientViewModel;
        private OrderViewModel orderViewModel;
        private ProductViewModel productViewModel;
        private RecipeViewModel RecipeViewModel;



        public MainWindow()
        {
            Ingredient_TypeViewModel = new Ingredient_TypeViewModel(ingredient_typeService);
            ingredientViewModel = new IngredientViewModel(ingredientService, ingredient_typeService);
            customerViewModel = new CustomerViewModel(customerService);
            orderViewModel = new OrderViewModel(orderService,productService,customerService);
            productViewModel = new ProductViewModel(productService);
            RecipeViewModel = new RecipeViewModel(recipeService);
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