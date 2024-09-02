using Microsoft.CodeAnalysis.CSharp.Syntax;
using WorkshopWeb.Entity;
using Workshop.Server.DTOs;

namespace Workshop.Server.Mapper
{
    public static class IngredientMapper
    {
        public static Ingredient ToEntity(this AddIngredientDTO addIngredient)
        {
            return new Ingredient()
            {
                //AuthorId = game.AuthorId,
                //Title = game.Title,
                //Description = game.Description,
            };
        }
    }
}
