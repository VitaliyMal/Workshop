using System.Collections.ObjectModel;
using Workshop.App.Core;
using Workshop.Core.Entity;
using Workshop.Core.Service;

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

        private string _lastName = string.Empty;
        public string LastName
        {
            get => _lastName;
            set
            {
                _lastName = value;
                OnPropertyChanged("LastName");
            }
        }

        private string _adress = string.Empty;
        public string Adress
        {
            get => _adress;
            set
            {
                _adress = value;
                OnPropertyChanged("Adress");
            }
        }

        private string _login = string.Empty;
        public string Login
        {
            get => _login;
            set
            {
                _login = value;
                OnPropertyChanged("Login");
            }
        }

        private string _password = string.Empty;
        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged("Password");
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
                          new Customer(Name, LastName, Adress, Login, Password)
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
                      SelectedCustomer.Name = Name;
                      SelectedCustomer.LastName = LastName;
                      SelectedCustomer.Adress = Adress;
                      SelectedCustomer.Login = Login;
                      SelectedCustomer.Password = Password;
                      customerService.Update(
                          SelectedCustomer
                          );
                      CustomerList = new ObservableCollection<Customer>(customerService.GetAll());
                  }));
            }
        }
    }
}