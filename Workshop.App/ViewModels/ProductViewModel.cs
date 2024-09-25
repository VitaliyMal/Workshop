using System.Collections.ObjectModel;
using System.Windows;
using Workshop.App.Core;
using Workshop.Core.Service;
using Workshop.Server.DTOs.ProductDTOs;

namespace Workshop.App.ViewModels
{
    public class ProductViewModel : ObservableObject
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

        private int _price = 0;
        public int Price
        {
            get => _price;
            set
            {
                _price = value;
                OnPropertyChanged("Price");
            }
        }

        private int _production_time = 0;
        public int Production_time
        {
            get => _production_time;
            set
            {
                _production_time = value;
                OnPropertyChanged("Production_time");
            }
        }

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

        public ProductViewModel(ProductService service)
        {
            productService = service;
            Task.Run(() => Fetch());
        }

        public async Task Fetch()
        {
            ProductList = new ObservableCollection<ProductDTO>(await productService.GetAll());
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
                                  await productService.Create(
                                      new ProductDTO(0, Name , Description , Price , Production_time)
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
                            await productService.Delete(
                                SelectedProduct.Id
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
                              await productService.Update(
                                new UpgradeProductDTO(
                                    SelectedProduct.Id,
                                    Name,
                                    Description,
                                    Price,
                                    Production_time
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
