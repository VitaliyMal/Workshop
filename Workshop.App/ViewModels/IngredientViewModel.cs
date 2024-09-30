using System.Collections.ObjectModel;
using System.Windows;
using Workshop.App.Core;
using Workshop.App.Entity;

//using Workshop.Core.Entity;
using Workshop.Core.Service;
using Workshop.Server.DTOs.Ingredient_TypeDTOs;
using Workshop.Server.DTOs.IngredientDTOs;

namespace Workshop.App.ViewModels
{
    public class IngredientViewModel : ObservableObject
    {
        private string _title = string.Empty;
        public string Title
        {
            get => _title;
            set
            {
                _title = value;
                OnPropertyChanged("Title");
            }
        }

        private int _amount = 0;
        public int Amount
        {
            get => _amount;
            set
            {
                _amount = value;
                OnPropertyChanged("Amount");
            }
        }

        private int _minimalAmount = 0;
        public int MinimalAmount
        {
            get => _minimalAmount;
            set
            {
                _minimalAmount = value;
                OnPropertyChanged("MinimalAmount");
            }
        }

        private int _cost = 0;
        public int Cost
        {
            get => _cost;
            set
            {
                _cost = value;
                OnPropertyChanged("Cost");
            }
        }

        //private int _ingredientType_id = 0; // не нужно, пробуем сюда подавать VM и в остальных так же
        //public int IngredientType_id
        //{
        //    get => _ingredientType_id;
        //    set
        //    {
        //        _ingredientType_id = value;
        //        OnPropertyChanged("IngredientType_id");
        //    }
        //}
        private ObservableCollection<Ingredient_TypeDTO> _ingredientTypeTitleList = new ObservableCollection<Ingredient_TypeDTO>();
        public ObservableCollection<Ingredient_TypeDTO> IngredientTypeTitleList 
        { 
            get => _ingredientTypeTitleList; 
            set { _ingredientTypeTitleList = value; OnPropertyChanged("IngredientTypeTitleList"); } }

        private Ingredient_TypeService ingredient_TypeService;

        private Ingredient_TypeDTO _selectedIngredient_Type;
        public Ingredient_TypeDTO SelectedIngredient_Type
        {
            get => _selectedIngredient_Type;
            set
            {
                _selectedIngredient_Type = value;
                OnPropertyChanged("SelectedIngredient_Type");
            }
        }

        private ObservableCollection<Ingredient> _ingredientList = new ObservableCollection<Ingredient>();
        public ObservableCollection<Ingredient> IngredientList { get => _ingredientList; set { _ingredientList = value; OnPropertyChanged("IngredientList"); } }

        private IngredientService ingredientService;

        private Ingredient _selectedIngredient;
        public Ingredient SelectedIngredient
        {
            get => _selectedIngredient;
            set
            {
                _selectedIngredient = value;
                OnPropertyChanged("SelectedIngredient");
            }
        }

        public IngredientViewModel(IngredientService service, Ingredient_TypeService ingredient_TypeService)
        {
            ingredientService = service;
            this.ingredient_TypeService = ingredient_TypeService;
            Task.Run(() => Fetch());
        }

        public async Task Fetch()
        {
            IngredientTypeTitleList = new ObservableCollection<Ingredient_TypeDTO>(await ingredient_TypeService.GetAll());
            IngredientList = new ObservableCollection<Ingredient>((await ingredientService.GetAll()).Select(x=>new Ingredient(x,IngredientTypeTitleList.First(y=>y.Id==x.IngredientType_id))));
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
                                  if (SelectedIngredient_Type != null) // проверка выбора не пустого поля
                                  {
                                      await ingredientService.Create(
                                          new IngredientDTO(0, Title, Amount, MinimalAmount, Cost, SelectedIngredient_Type.Id));
                                      await Fetch();
                                  }
                              }
                              catch (Exception ex)
                              {
                                  MessageBox.Show(ex.Message);
                                  //throw(ex);                      ////////////////////// логика когда срабатывает             
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
                            await ingredientService.Delete(
                                SelectedIngredient.ingredientDTO.Id
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
                          if (SelectedIngredient_Type != null) // проверка выбора не пустого поля
                          {
                              try
                              {
                                  await ingredientService.Update(
                                    new UpdateIngredientDTO(
                                        SelectedIngredient.ingredientDTO.Id,
                                        Title,
                                        Amount,
                                        MinimalAmount,
                                        Cost,
                                        SelectedIngredient_Type.Id
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
