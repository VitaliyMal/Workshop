using System.Collections.ObjectModel;
using System.Windows;
using Workshop.App.Core;
using Workshop.Core.Service;
using Workshop.Server.DTOs.RecipeDTOs;

namespace Workshop.App.ViewModels
{
    public class RecipeViewModel : ObservableObject
    {
        private int _id_Ingredient = 0;
        public int Id_Ingredient
        {
            get => _id_Ingredient;
            set
            {
                _id_Ingredient = value;
                OnPropertyChanged("Id_Ingredient");
            }
        }

        private int _id_Product;
        public int Id_Product
        {
            get => _id_Product;
            set
            {
                _id_Product = value;
                OnPropertyChanged("Id_Product");
            }
        }

        private ObservableCollection<RecipeDTO> _recipeList = new ObservableCollection<RecipeDTO>();
        public ObservableCollection<RecipeDTO> RecipeList { get => _recipeList; set { _recipeList = value; OnPropertyChanged("RecipeList"); } }

        private RecipeService recipeService;

        private RecipeDTO _selectedRecipe;
        public RecipeDTO SelectedRecipe
        {
            get => _selectedRecipe;
            set
            {
                _selectedRecipe = value;
                OnPropertyChanged("SelectedRecipe");
            }
        }

        public RecipeViewModel(RecipeService service)
        {
            recipeService = service;
            Task.Run(() => Fetch());
        }

        public async Task Fetch()
        {
            RecipeList = new ObservableCollection<RecipeDTO>(await recipeService.GetAll());
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
                                  await recipeService.Create(
                                      new RecipeDTO(0, Id_Ingredient, Id_Product)
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
                            await recipeService.Delete(
                                SelectedRecipe.Id
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
                              await recipeService.Update(
                                new UpgradeRecipeDTO(
                                    SelectedRecipe.Id,
                                    Id_Ingredient,
                                    Id_Product
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
