using System.Windows;
using System.Windows.Controls;
using Workshop.App.ViewModels;
using Workshop.App.Windowss;
using static Workshop.App.Windowss.Order_Window;

namespace Workshop.App
{
    /// <summary>
    /// Логика взаимодействия для OrderPage.xaml
    /// </summary>
    public partial class OrderPage : Page
    {
        private OrderViewModel _viewModel;
        public OrderPage(OrderViewModel viewModel)
        {
            _viewModel = viewModel;
            DataContext = _viewModel;
            InitializeComponent();
        }

        private void Add_Click_Window(object sender, RoutedEventArgs e)
        {
            Order_Window order_Window = new Order_Window(_viewModel, FormType.Add);
            Nullable<bool> dialogResult = order_Window.ShowDialog();
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            Order_Window order_Window = new Order_Window(_viewModel, FormType.Edit);
            Nullable<bool> dialogResult = order_Window.ShowDialog();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.DeleteCommand.Execute(null);
        }
    }
}
