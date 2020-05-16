using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebRole1.Models
{
    public class Recipe
    {
        public int RecipeId { get; set; }
        public string Name { get; set; }
        public int Owner { get; set; }
        public string Ingredients { get; set; }
        public string Description { get; set; }
        public EnumCuisine Cuisine { get; set; }

        public Recipe()
        {

        }

    }

    public class ModelCuisine
    {
        [Display(Name = "Nature of your inquiry")]
        [EnumDataType(typeof(EnumCuisine))]
        public EnumCuisine? EnumCuisine { get; set; }
        
    }

    public enum EnumCuisine 
    {
        
       
        American = 1,
        BBQ = 2,
        Chinese = 3,
        [Display(Name = "Eastern European")]
        EasternEuropean = 4,
        French = 5,
        German = 6,
        Indian = 7,
        Japanese = 8,
        Mexican = 9,
        [Display(Name = "Middle Eastern")]
        MiddleEastern = 10,
        Russian = 11,
        Scandinavian = 12
    }
}

