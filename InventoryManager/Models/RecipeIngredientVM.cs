using InventoryManager.Data;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace InventoryManager.Models
{
    public class RecipeIngredientVM
    {
        public Recipe_Ingredient Recipe_Ingredient { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> RecipeList { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> IngredientList { get; set; }
    }
}
