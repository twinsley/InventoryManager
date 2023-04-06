using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;

namespace InventoryManager.Data
{
    public class Recipe
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [AllowNull]
        public string? Description { get; set; }
        public string Directions { get; set; }
        [DisplayName("Time to prepare the recipe")]
        public string PrepTime { get; set; }
    }
}
