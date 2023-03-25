using System.ComponentModel.DataAnnotations;

namespace InventoryManager.Data
{
    public class Ingredient
    {
        [Key]
        public int SKU { get; set; }
        public int Size { get; set; }
        public string SizeUnit { get; set; }
        public float Onhand { get; set; }
        public decimal Price { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

    }
}
