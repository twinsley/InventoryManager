using System.ComponentModel;

namespace InventoryManager.Data
{
    public class Recipe
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        [DisplayName("Time to prepare the recipe")]
        public string PrepTime { get; set; }

        public ICollection<Recipe_Ingredient> Recipe_Ingredients { get; set; }
    }
}
