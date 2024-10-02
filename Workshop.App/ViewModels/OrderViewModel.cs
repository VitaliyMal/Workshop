using System.Collections.ObjectModel;
using System.Windows;
using Workshop.App.Core;
using Workshop.Core.Service;
using Workshop.Server.DTOs.CustomerDTOs;
using Workshop.Server.DTOs.OrderDTOs;
using Workshop.Server.DTOs.ProductDTOs;
using Workshop.Server.DTOs.State_TypeDTOs;

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

        //private int _product_id = 0; ////////////// нужны ли?
        //public int Product_id
        //{
        //    get => _product_id;
        //    set
        //    {
        //        _product_id = value;
        //        OnPropertyChanged("Product_id");
        //    }
        //}

        //private int _customer_id = 0; ////////////// нужны ли?
        //public int Customer_id
        //{
        //    get => _customer_id;
        //    set
        //    {
        //        _customer_id = value;
        //        OnPropertyChanged("Customer_id");
        //    }
        //}

        //private int _state_Type_id = 0; ////////////// нужны ли?
        //public int State_Type_id
        //{
        //    get => _state_Type_id;
        //    set
        //    {
        //        _state_Type_id = value;
        //        OnPropertyChanged("State_Type_id");
        //    }
        //}

        private ObservableCollection<ProductDTO> _productList = new ObservableCollection<ProductDTO>();
        public ObservableCollection<ProductDTO> ProductList { get => _productList; set { _productList = value; OnPropertyChanged("ProductList"); } }

        private ProductService productService;

        private ProductDTO _selectedProduct;
        public ProductDTO SelectedProduct
        {
            get => _selectedProduct;
            set
            {
                _selectedProduct = value;
                OnPropertyChanged("SelectedProduct");
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

        private ObservableCollection<State_TypeDTO> _state_TypeList = new ObservableCollection<State_TypeDTO>();
        public ObservableCollection<State_TypeDTO> State_TypeList { get => _state_TypeList; set { _state_TypeList = value; OnPropertyChanged("State_TypeList"); } }

        private State_TypeService state_TypeService;

        private State_TypeDTO _selectedState_Type;
        public State_TypeDTO SelectedState_Type
        {
            get => _selectedState_Type;
            set
            {
                _selectedState_Type = value;
                OnPropertyChanged("SelectedState_Type");
            }
        }


        ///////////////////////////////////////////////////////////////////////////////////////////////
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

        public OrderViewModel(OrderService service, ProductService productService, CustomerService customerService, State_TypeService state_TypeService)
        {
            orderService = service;
            this.productService = productService;
            this.customerService = customerService;
            this.state_TypeService= state_TypeService;
            Task.Run(() => Fetch());
        }

        public async Task Fetch()
        {
            ProductList = new ObservableCollection<ProductDTO>(await productService.GetAll());
            CustomerList = new ObservableCollection<CustomerDTO>(await customerService.GetAll());
            State_TypeList = new ObservableCollection<State_TypeDTO>(await state_TypeService.GetAll());

            OrderList = new ObservableCollection<Order>((await orderService.GetAll()).Select(
                x=> new Order(x,
                ProductList.First(y=>y,Id=x.Product_id),
                CustomerList.First(w=>w,Id=x.Customer_id),
                State_TypeList.First(z=>z,Id=x.State_Type_id)
                )));
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
                                if ((SelectedProduct !=null)&&(SelectedCustomer !=null)&&(SelectedState_Type !=null)){
                                  await orderService.Create(
                                      new OrderDTO(0, Description, SelectedProduct.Id, SelectedCustomer.Id, SelectedState_Type.Id)
                                      );
                                  await Fetch();
                                  }
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
                                SelectedOrder.orderDTO.Id
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
                        if ((SelectedProduct !=null)&&(SelectedCustomer !=null)&&(SelectedState_Type !=null)){
                          try
                          {
                              await orderService.Update(
                                new UpgradeOrderDTO(
                                    SelectedOrder.orderDTO.Id,
                                    Description,
                                    SelectedProduct.Id,
                                    SelectedCustomer.Id,
                                    SelectedState_Type.Id
                                    )
                                );
                              await Fetch();
                          }
                          catch (Exception ex)
                          {
                              MessageBox.Show(ex.Message);
                              ////////////////////// логика когда срабатывает 
                          }
                        }
                      }))
                  );
            }
        }
    }
}
