using System.Windows;
using System.Windows.Controls;
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
        private FormType formType;

        public New_Customer_Window(CustomerViewModel viewModel, FormType formType = FormType.Add)
        {
            _viewModel = viewModel;
            this.formType = formType;
            DataContext = _viewModel;
            InitializeComponent();
            Loaded += New_Customer_Window_Loaded;
        }

        private void Accept_Click(object sender, RoutedEventArgs e)
        {
            var vm = this.DataContext as CustomerViewModel;
            switch (formType)
            {
                case FormType.Add:

                    if (vm.AddCommand.CanExecute(null))
                    {
                            vm.AddCommand.Execute(null);
                            MessageBox.Show("Данные сохранены");
                            this.DialogResult = true; /// по этим направлениям добавить try-catch и при ошибке не выполнять эту команду
                    }
                    break;
                case FormType.Edit:

                    if (vm.EditCommand.CanExecute(null))
                    {
                        vm.EditCommand.Execute(null);
                        MessageBox.Show("Данные изменены");
                        this.DialogResult = true; /// по этим направлениям добавить try-catch и при ошибке не выполнять эту команду
                    }
                        break;
                default:
                    break;
            }

        }

        private void New_Customer_Window_Loaded(object sender, RoutedEventArgs e)
        {
            // Очищаем поля ввода
            Name.Text = string.Empty;
            LastName.Text = string.Empty;
            Adress.Text = string.Empty;
            Login.Text = string.Empty;
            Password.Text = string.Empty;
        }


        public enum FormType
        {
            Add,
            Edit
        }
    }
}
