using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Workshop.App.Core;
using Workshop.Core.Service;
using Workshop.Core;
using Workshop.Core.Entity;
using System.Windows;

namespace Workshop.App.ViewModels
{
    public class CustomerViewModel : ObservableObject
    {
        private string _name = string.Empty;
        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged("Name");
            }
        }        
        
        private string _input = string.Empty;
        public string Input
        {
            get => _input;
            set
            {
                _input = value;
                OnPropertyChanged("Input");
            }
        }

        private ObservableCollection<Customer> _customerList = new ObservableCollection<Customer>();
        public ObservableCollection<Customer> CustomerList { get => _customerList; set { _customerList = value; OnPropertyChanged("CustomerList"); } }

        private CustomerService customerService;

        private Customer _selectedCustomer;
        public Customer SelectedCustomer
        {
            get => _selectedCustomer;
            set
            {
                _selectedCustomer = value;
                Input = value.Name;
                OnPropertyChanged("SelectedCustomer");
            }
        }

        public CustomerViewModel(CustomerService service)
        {
            customerService = service;
            CustomerList = new ObservableCollection<Customer>(customerService.GetAll());
        }

        private RelayCommand addCommand;
        public RelayCommand AddCommand
        {
            get
            {
                return addCommand ??
                  (addCommand = new RelayCommand(obj =>
                  {
                      customerService.Create(
                          new Customer(Name)
                          );
                      CustomerList = new ObservableCollection<Customer>(customerService.GetAll());
                  }));
            }
        }

        private RelayCommand deleteCommand;
        public RelayCommand DeleteCommand
        {
            get
            {
                return deleteCommand ??
                  (deleteCommand = new RelayCommand(obj =>
                  {
                      customerService.Delete(
                          SelectedCustomer.Id
                          );
                      CustomerList = new ObservableCollection<Customer>(customerService.GetAll());
                  }));
            }
        }

        private RelayCommand editCommand;
        public RelayCommand EditCommand
        {
            get
            {
                return editCommand ??
                  (editCommand = new RelayCommand(obj =>
                  {
                      SelectedCustomer.LastName = Input;
                      SelectedCustomer.Name = Input;
                      SelectedCustomer.Adress = Input;
                      SelectedCustomer.Login = Input;
                      SelectedCustomer.Password = Input;
                      customerService.Update(
                          SelectedCustomer
                          );
                      CustomerList = new ObservableCollection<Customer>(customerService.GetAll());
                  }));
            }
        }
    }
}
