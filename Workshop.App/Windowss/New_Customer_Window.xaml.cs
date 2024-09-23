using System.Windows;
using Workshop.App.ViewModels;


namespace Workshop.App
{
    /// <summary>
    /// Логика взаимодействия для New_Customer_Window.xaml
    /// </summary>
    public partial class New_Customer_Window : Window
    {
        //Можно сделать эту форму универсальной и для добавления и для редактирования, например, передавая в конструкторе помимо ViewModel ещё и флаг или Enum(на будущее, вдруг нужна будет небинарное разделение). Тогда в Accept делаем switch по этому enum и выполняем соответствующую команду из VM
        private CustomerViewModel _viewModel;
        public New_Customer_Window(CustomerViewModel viewModel)
        {
            _viewModel = viewModel;
            DataContext = _viewModel;
            InitializeComponent();
        }

        private void Accept_Click(object sender, RoutedEventArgs e)
        {
            var vm = this.DataContext as CustomerViewModel;
            if (vm.AddCommand.CanExecute(null))
                vm.AddCommand.Execute(null);
            MessageBox.Show("Данные сохранены");
            this.DialogResult = true;
        }
    }
}
