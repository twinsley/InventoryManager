﻿using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace InventoryManager.Data
{
    public class Ingredient
    {
        [Key]
        public int Id { get; set; }
        public string SKU { get; set; }
        public int Size { get; set; }
        [DisplayName("Size unit (oz, lb, etc)")]
        public string SizeUnit { get; set; }
        [DisplayName("Number on hand")]
        public float Onhand { get; set; }
        public decimal Price { get; set; }
        public string Name { get; set; }
        [AllowNull]
        [ValidateNever]
        public string? Description { get; set; }
    }
}
