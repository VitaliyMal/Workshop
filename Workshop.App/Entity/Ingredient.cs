using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop.Server.DTOs.Ingredient_TypeDTOs;
using Workshop.Server.DTOs.IngredientDTOs;

namespace Workshop.App.Entity
{
    public class Ingredient
    {
        public Ingredient(IngredientDTO x, Ingredient_TypeDTO ingredient_TypeDTO)
        {
            ingredientDTO = x;
            ingredientTypeDTO = ingredient_TypeDTO;
        }

        public IngredientDTO? ingredientDTO { get; set; }
        public Ingredient_TypeDTO? ingredientTypeDTO { get; set;}

    }
}
