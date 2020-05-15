using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebRole1.Models
{
    public class Recipe
    {
        public int RecipeId { get; set; }
        public string Name { get; set; }
        public int Owner { get; set; }
        public string Ingredients { get; set; }
        public string Description { get; set; }
        public Cuisine Cuisine { get; set; }

        public Recipe()
        {

        }

    }
    public enum Cuisine
    {
        American,
        BBQ,
        Chinese,
        EasternEuropean,
        French,
        German,
        Indian,
        Japanese,
        Mexican,
        MiddleEastern,
        Russian,
        Scandinavian
    }
}

