using System.Windows;
using Workshop.App.ViewModels;


namespace Workshop.App
{
    /// <summary>
    /// Логика взаимодействия для New_Customer_Window.xaml
    /// </summary>
    public partial class New_Customer_Window : Window
    {
        private CustomerViewModel _viewModel;
        public New_Customer_Window(CustomerViewModel viewModel)
        {
            _viewModel = viewModel;
            DataContext = _viewModel;
            InitializeComponent();
        }

        private void Accept_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Данные сохранены");
            this.DialogResult = true;
        }
    }
}
