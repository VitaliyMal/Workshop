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


namespace Workshop.App
{
    /// <summary>
    /// Логика взаимодействия для New_Customer_Window.xaml
    /// </summary>
    public partial class New_Customer_Window : Window
    {
        public New_Customer_Window(/*CustomerViewModel viewModel*/)
        {
            //DataContext = viewModel;
            InitializeComponent();
        }

        private void Accept_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Данные сохранены");
            this.DialogResult = true;
        }
    }
}
