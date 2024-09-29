using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Workshop.App.ViewModels;

namespace Workshop.App.Windowss
{
    /// <summary>
    /// Логика взаимодействия для Order_Window.xaml
    /// </summary>
    public partial class Order_Window : Window
    {
        private OrderViewModel _viewModel;
        private FormType formType;

        public Order_Window(OrderViewModel viewModel, FormType formType = FormType.Add)
        {
            _viewModel = viewModel;
            this.formType = formType;
            DataContext = _viewModel;
            InitializeComponent();
            Loaded += New_Order_Window_Loaded;
        }

        private async void Accept_Click(object sender, RoutedEventArgs e) ///async
        {
            var vm = this.DataContext as OrderViewModel;
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

        private void New_Order_Window_Loaded(object sender, RoutedEventArgs e)
        {
            // Очищаем поля ввода
            Description.Text = string.Empty;
            //LastName.Text = string.Empty;
            //Adress.Text = string.Empty;
            //Login.Text = string.Empty;
            //Password.Text = string.Empty;
        }


        public enum FormType
        {
            Add,
            Edit
        }
    }
}
