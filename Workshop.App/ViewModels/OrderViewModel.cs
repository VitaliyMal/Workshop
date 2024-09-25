using System.Collections.ObjectModel;
using System.Windows;
using Workshop.App.Core;
using Workshop.Core.Service;
using Workshop.Server.DTOs.OrderDTOs;

namespace Workshop.App.ViewModels
{
    public class OrderViewModel : ObservableObject
    {
        private string _description = string.Empty;
        public string Description
        {
            get => _description;
            set
            {
                _description = value;
                OnPropertyChanged("Description");
            }
        }

        private int _product_id = 0; ////////////// нужны ли?
        public int Product_id
        {
            get => _product_id;
            set
            {
                _product_id = value;
                OnPropertyChanged("Product_id");
            }
        }

        private int _customer_id = 0; ////////////// нужны ли?
        public int Customer_id
        {
            get => _customer_id;
            set
            {
                _customer_id = value;
                OnPropertyChanged("Customer_id");
            }
        }

        private int _state_Type_id = 0; ////////////// нужны ли?
        public int State_Type_id
        {
            get => _state_Type_id;
            set
            {
                _state_Type_id = value;
                OnPropertyChanged("State_Type_id");
            }
        }

        private ObservableCollection<OrderDTO> _orderList = new ObservableCollection<OrderDTO>();
        public ObservableCollection<OrderDTO> OrderList { get => _orderList; set { _orderList = value; OnPropertyChanged("OrderList"); } }

        private OrderService orderService;

        private OrderDTO _selectedOrder;
        public OrderDTO SelectedOrder
        {
            get => _selectedOrder;
            set
            {
                _selectedOrder = value;
                OnPropertyChanged("SelectedOrder");
            }
        }

        public OrderViewModel(OrderService service)
        {
            orderService = service;
            Task.Run(() => Fetch());
        }

        public async Task Fetch()
        {
            OrderList = new ObservableCollection<OrderDTO>(await orderService.GetAll());
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
                                  await orderService.Create(
                                      new OrderDTO(0, Description, Product_id, Customer_id, State_Type_id)
                                      );
                                  await Fetch();
                              }
                              catch (Exception ex)
                              {
                                  MessageBox.Show(ex.Message);
                                  //throw(ex);
                                  ///////////////////// логика когда срабатывает 
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
                            await orderService.Delete(
                                SelectedOrder.Id
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
                              await orderService.Update(
                                new UpgradeOrderDTO(
                                    SelectedOrder.Id,
                                    Description,
                                    Product_id,
                                    Customer_id,
                                    State_Type_id
                                    )
                                );
                              await Fetch();
                          }
                          catch (Exception ex)
                          {
                              MessageBox.Show(ex.Message);
                              ////////////////////// логика когда срабатывает 
                          }
                      }))
                  );
            }
        }
    }
}
