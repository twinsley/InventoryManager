using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace InventoryManager.Data
{
    public class Recipe_Ingredient
    {
        public int Id { get; set; }
        public int RecipeId { get; set; }
        [ValidateNever]
        public Recipe Recipe { get; set; }
        public int IngredientId { get; set; }
        [ValidateNever]
        public Ingredient Ingredient { get; set; }
        public double Quantity { get; set; }
        [DisplayName("Size unit (oz, lb, etc)")]
        public string QuantityMeasure { get; set; }
    }
}
