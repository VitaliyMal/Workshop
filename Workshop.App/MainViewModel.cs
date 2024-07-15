using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using Workshop.App.Core;
using Workshop.Core.Entity;
using Workshop.Core.Service;




namespace Workshop.App
{
    public class MainViewModel: ObservableObject
    {
        private ObservableCollection<Customer> _customerList=new ObservableCollection<Customer>();
        public ObservableCollection<Customer> CustomerList { get => _customerList; set {  _customerList = value; OnPropertyChanged() } }//чиним
        public MainViewModel()
        {
            //Починить!!!
            // CustomerService customerService = new CustomerService(new Workshop.Core.Data.CustomerDataSource);
            // Customers = customerService.GetAll();


        }
        private string _input = string.Empty; public string Input
        {
            get => _input; 
            set
            {
                _input = value; OnPropertyChanged("Input");
            }
        }

        private string _output = string.Empty; public string Output
        {
            get => _output;
            set
            {
                _output = value; OnPropertyChanged("Output");
            }
        }

        private RelayCommand showCommand;
        public RelayCommand ShowCommand
        {
            get
            {
                return showCommand ??
                  (showCommand = new RelayCommand(obj => {
                      Output = Input;
                  }));
            }
        }

        private RelayCommand clearCommand;
        public RelayCommand ClearCommand
        {
            get
            {
                return clearCommand ?? (clearCommand = new RelayCommand(obj =>
                {
                    Output = string.Empty;
                    Input = string.Empty;
                }));
            }
        }
    }
}
