﻿namespace WorkshopWeb.Entity
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public int Production_time { get; set; }
        
        public int Recipe_id { get; set; }
        public string? RecipeTitle { get; set; }
    }
}
