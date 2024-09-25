using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workshop.App.ViewModels
{
    public class Ingredient_TypeViewModel : ObservableObject
    {
        private string _ingredientTypeTitle = string.Empty;
        public string IngredientTypeTitle
        {
            get => _ingredientTypeTitle;
            set
            {
                _ingredientTypeTitle = value;
                OnPropertyChanged("IngredientTypeTitle");
            }
        }


        private ObservableCollection<Ingredient_TypeDTO> _ingredientTypeTitleList = new ObservableCollection<Ingredient_TypeDTO>();
        public ObservableCollection<Ingredient_TypeDTO> IngredientTypeTitleList { get => _ingredientTypeTitleList; set { _ingredientTypeTitleList = value; OnPropertyChanged("IngredientTypeTitleList"); } }

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

        public Ingredient_TypeViewModel(Ingredient_TypeService service)
        {
            ingredient_TypeService = service;
            Task.Run(() => Fetch());
        }

        public async Task Fetch()
        {
            IngredientTypeTitleList = new ObservableCollection<Ingredient_TypeDTO>(await ingredient_TypeService.GetAll());
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
                                  await ingredient_TypeService.Create(
                                      new Ingredient_TypeDTO(0, IngredientTypeTitle)
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
                            await ingredient_TypeService.Delete(
                                SelectedIngredient_Type.Id
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
                              await ingredient_TypeService.Update(
                                new UpgradeIngredient_TypeDTO(
                                    SelectedIngredient_Type.Id,
                                    IngredientTypeTitle
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
