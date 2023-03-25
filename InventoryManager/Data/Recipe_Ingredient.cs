using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryManager.Data
{
    public class Recipe_Ingredient
    {
        public int Id { get; set; }
        [ForeignKey("Recipe")]
        public int RecipeId { get; set; }
        public Recipe Recipe { get; set; }
        [ForeignKey("Ingredient")]
        public int IngredientId { get; set; }
        public Ingredient Ingredient { get; set; }
        public double Quantity { get; set; }
    }
}
