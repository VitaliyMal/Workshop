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
    public class IngredientViewModel : ObservableObject
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

        public IngredientViewModel(IngredientService service)
        {
            ingredientService = service;
            IngredientList = new ObservableCollection<Ingredient>(ingredientService.GetAll());
        }

        private RelayCommand addCommand;
        public RelayCommand AddCommand
        {
            get
            {
                return addCommand ??
                  (addCommand = new RelayCommand(obj =>
                  {
                      ingredientService.Create(
                          new Ingredient(Input)
                          );
                      IngredientList = new ObservableCollection<Ingredient>(ingredientService.GetAll());
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
                      ingredientService.Delete(
                          SelectedIngredient.Id
                          );
                      IngredientList = new ObservableCollection<Ingredient>(ingredientService.GetAll());
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
                      SelectedIngredient.Title = Input;
                      SelectedIngredient.Amount = Convert.ToInt16(Input);
                      SelectedIngredient.MinimalAmount = Convert.ToInt16(Input);
                      SelectedIngredient.Cost = Convert.ToInt16(Input);
                      //SelectedIngredient.Type = Input;
                      ingredientService.Update(
                          SelectedIngredient
                          );
                      IngredientList = new ObservableCollection<Ingredient>(ingredientService.GetAll());
                  }));
            }
        }
    }
}
