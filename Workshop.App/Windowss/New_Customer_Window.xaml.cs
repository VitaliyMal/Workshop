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
        private FormType formType;

        public New_Customer_Window(CustomerViewModel viewModel, FormType formType = FormType.Add)
        {
            _viewModel = viewModel;
            this.formType = formType;
            DataContext = _viewModel;
            InitializeComponent();
            Loaded += New_Customer_Window_Loaded;
        }

        private async void Accept_Click(object sender, RoutedEventArgs e) ///async
        {
            var vm = this.DataContext as CustomerViewModel;
            switch (formType)
            {
                case FormType.Add:

                    if (vm.AddCommand.CanExecute(null))
                    {
                        try
                        {
                            await vm.AddCommand.Execute(null); ///////////// execute + await
                            MessageBox.Show("Данные сохранены");
                            this.DialogResult = true;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);                            
                        }
                    }
                    break;
                case FormType.Edit:

                    if (vm.EditCommand.CanExecute(null))
                    {
                        try
                        {
                            await vm.EditCommand.Execute(null);
                            MessageBox.Show("Данные изменены");
                            this.DialogResult = true;

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
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
