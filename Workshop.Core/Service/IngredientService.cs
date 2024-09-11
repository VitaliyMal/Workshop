using Workshop.Core.Data;
using Workshop.Core.Entity;

namespace Workshop.Core.Service
{
    public class IngredientService
    {
        public IngredientDataSource _dataSource;
        private List<Ingredient> _ingredients = [];

        public IngredientService(IngredientDataSource dataSource)
        {
            _dataSource = dataSource;
            _ingredients = _dataSource.Get() ?? new List<Ingredient>();
        }

        public List<Ingredient> GetAll()
        {
            return _ingredients;
        }

        public Ingredient Get(int id)
        {
            foreach (Ingredient ingredient in _ingredients)
            {
                if (ingredient.Id == id)
                {
                    return ingredient;
                }
            }
            return null;
        }
        public void Create(Ingredient ingredient)
        {
            _ingredients.Add(ingredient);
            _dataSource.Write(_ingredients);

        }

        public void Delete(int id)
        {
            foreach (Ingredient ingredient in _ingredients)
            {
                if (ingredient.Id == id)
                {
                    _ingredients.Remove(ingredient);
                    break;
                }
            }

            _dataSource.Write(_ingredients);
        }

        public void Update(Ingredient ingredient)
        {
            for (int i = 0; i < _ingredients.Count; i++)
                if (ingredient.Id == _ingredients[i].Id)
                    _ingredients[i] = ingredient;
            _dataSource.Write(_ingredients);

        }


    }
}
