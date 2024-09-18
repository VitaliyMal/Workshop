using System.Collections.ObjectModel;
using Workshop.App.Core;
using Workshop.Core.Entity;
using Workshop.Core.Service;

namespace Workshop.App.ViewModels
{
    public class ProductViewModel : ObservableObject
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

        private ObservableCollection<Product> _productList = new ObservableCollection<Product>();
        public ObservableCollection<Product> ProductList { get => _productList; set { _productList = value; OnPropertyChanged("ProductList"); } }

        private ProductService productService;

        private Product _selectedProduct;
        public Product SelectedProduct
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
            ProductList = new ObservableCollection<Product>(productService.GetAll());
        }

        private RelayCommand addCommand;
        public RelayCommand AddCommand
        {
            get
            {
                return addCommand ??
                  (addCommand = new RelayCommand(obj =>
                  {
                      productService.Create(
                          new Product(Input)
                          );
                      ProductList = new ObservableCollection<Product>(productService.GetAll());
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
                      productService.Delete(
                          SelectedProduct.Id
                          );
                      ProductList = new ObservableCollection<Product>(productService.GetAll());
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
                      SelectedProduct.Name = Input;
                      SelectedProduct.Description = Input;
                      SelectedProduct.Price = Convert.ToInt16(Input);
                      SelectedProduct.Production_time = Convert.ToInt16(Input);
                      //SelectedProduct.Ingredients = Input;
                      productService.Update(
                          SelectedProduct
                          );
                      ProductList = new ObservableCollection<Product>(productService.GetAll());
                  }));
            }
        }
    }
}
