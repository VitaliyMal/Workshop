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

namespace Workshop.App.ViewModels
{
    public class OrderViewModel : ObservableObject
    {
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

        private ObservableCollection<Order> _orderList = new ObservableCollection<Order>();
        public ObservableCollection<Order> OrderList { get => _orderList; set { _orderList = value; OnPropertyChanged("OrderList"); } }

        private OrderService orderService;

        private Order _selectedOrder;
        public Order SelectedOrder
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
            OrderList = new ObservableCollection<Order>(orderService.GetAll());
        }

        private RelayCommand addCommand;
        public RelayCommand AddCommand
        {
            get
            {
                return addCommand ??
                  (addCommand = new RelayCommand(obj =>
                  {
                      orderService.Create(
                          new Order(Convert.ToInt32(Input)) // тут возможны проблемы с вводом
                          );
                      OrderList = new ObservableCollection<Order>(orderService.GetAll());
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
                      orderService.Delete(
                          SelectedOrder.OrderId
                          );
                      OrderList = new ObservableCollection<Order>(orderService.GetAll());
                  }));
            }
        }


        //Реализовать в дальнейшем
        //private RelayCommand editCommand;
        //public RelayCommand EditCommand
        //{
        //    get
        //    {
        //        return editCommand ??
        //          (editCommand = new RelayCommand(obj =>
        //          {
        //              SelectedOrder.State = Input;
        //              SelectedCustomer.Name = Input;
        //              SelectedCustomer.Adress = Input;
        //              SelectedCustomer.Login = Input;
        //              SelectedCustomer.Password = Input;
        //              customerService.Update(
        //                  SelectedCustomer
        //                  );
        //              OrderList = new ObservableCollection<Order>(customerService.GetAll());
        //          }));
        //    }
        //}
    }
}
