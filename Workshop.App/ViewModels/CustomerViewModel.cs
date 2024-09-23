using System.Collections.ObjectModel;
using System.Windows;
using Workshop.App.Core;
//using Workshop.Core.Entity;
using Workshop.Core.Service;
using Workshop.Server.DTOs.CustomerDTOs;
using Workshop.Server.Migrations;

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

        private ObservableCollection<CustomerDTO> _customerList = new ObservableCollection<CustomerDTO>();
        public ObservableCollection<CustomerDTO> CustomerList { get => _customerList; set { _customerList = value; OnPropertyChanged("CustomerList"); } }

        private CustomerService customerService;

        private CustomerDTO _selectedCustomer;
        public CustomerDTO SelectedCustomer
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
            Task.Run(() => Fetch());
        }

        public async Task Fetch()
        {
            CustomerList = new ObservableCollection<CustomerDTO>(await customerService.GetAll());
        }


        private AsyncRelayCommand addCommand;
        public AsyncRelayCommand AddCommand
        {
            get
            {
                return addCommand ?? (
                    addCommand = new AsyncRelayCommand(() => Task.Run(
                          async () =>
                          {
                              try
                              {
                                  await customerService.Create(
                                      new CustomerDTO(0, Name, LastName, Adress, Login, Password)
                                      );
                                  await Fetch();
                              }
                              catch (Exception ex)
                              {
                                  MessageBox.Show(ex.Message);
                                  //throw(ex);
                                  ///////////////////// логика когда срабатывает валидатор (поля логин и пароль)
                              }
                          }))
                    );

            }
        }

        private AsyncRelayCommand deleteCommand;
        public AsyncRelayCommand DeleteCommand
        {
            get
            {
                return deleteCommand ?? (
                    deleteCommand = new AsyncRelayCommand(() => Task.Run(
                        async () =>
                        {
                            await customerService.Delete(
                                SelectedCustomer.Id
                                    );
                            await Fetch();
                        }))
                    );
            }
        }

        private AsyncRelayCommand editCommand;
        public AsyncRelayCommand EditCommand
        {
            get
            {
                return editCommand ??
                  (editCommand = new AsyncRelayCommand(() => Task.Run(
                      async () =>
                      {
                          try
                          {
                              await customerService.Update(
                                new UpgradeCustomerDTO(
                                    SelectedCustomer.Id,
                                    Name,
                                    LastName,
                                    Adress,
                                    Login,
                                    Password
                                    )
                                );
                              await Fetch();
                          }
                          catch (Exception ex)
                          {
                              ////////////////////// логика когда срабатывает валидатор (поля логин и пароль)
                          }
                      }))
                  );
            }
        }
    }
}