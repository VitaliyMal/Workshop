using System.Collections.ObjectModel;
using Workshop.App.Core;
//using Workshop.Core.Entity;
using Workshop.Core.Service;

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

        private int _ingredientType_id = 0; // нужен ли он ???????????????????????????????????????????????????
        public int IngredientType_id
        {
            get => _ingredientType_id;
            set
            {
                _ingredientType_id = value;
                OnPropertyChanged("IngredientType_id");
            }
        }

        private ObservableCollection<IngredientDTO> _ingredientList = new ObservableCollection<IngredientDTO>();
        public ObservableCollection<IngredientDTO> IngredientList { get => _ingredientList; set { _ingredientList = value; OnPropertyChanged("IngredientList"); } }

        private IngredientService ingredientService;

        private IngredientDTO _selectedIngredient;
        public IngredientDTO SelectedIngredient
        {
            get => _selectedIngredient;
            set
            {
                _selectedIngredient = value;
                OnPropertyChanged("SelectedIngredient");
            }
        }

        public IngredientViewModel(IngredientService service)
        {
            ingredientService = service;
            Task.Run(() => Fetch());
        }

        public async Task Fetch()
        {
            IngredientList = new ObservableCollection<IngredientDTO>(await ingredientService.GetAll());
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
                                  await ingredientService.Create(
                                      new IngredientDTO(0, Title, Amount, MinimalAmount, Cost, IngredientType_id)
                                      );
                                  await Fetch();
                              }
                              catch (Exception ex)
                              {
                                  MessageBox.Show(ex.Message);
                                  //throw(ex);                                  
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
                                SelectedIngredient.Id
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
                              await ingredientService.Update(
                                new UpdateIngredientDTO(
                                    SelectedIngredient.Id,
                                    Title,
                                    Amount,
                                    MinimalAmount,
                                    Cost,
                                    IngredientType_id
                                    )
                                );
                              await Fetch();
                          }
                          catch (Exception ex)
                          {
                              ////////////////////// логика когда срабатывает                              
                          }
                      }))
                  );
            }
        }
    }
}
