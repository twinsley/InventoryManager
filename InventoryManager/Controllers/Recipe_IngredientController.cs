using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using InventoryManager.Data;

namespace InventoryManager.Controllers
{
    public class Recipe_IngredientController : Controller
    {
        private readonly ApplicationDbContext _context;

        public Recipe_IngredientController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Recipe_Ingredient
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Recipe_Ingredients.Include(r => r.Ingredient).Include(r => r.Recipe);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Recipe_Ingredient/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Recipe_Ingredients == null)
            {
                return NotFound();
            }

            var recipe_Ingredient = await _context.Recipe_Ingredients
                .Include(r => r.Ingredient)
                .Include(r => r.Recipe)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (recipe_Ingredient == null)
            {
                return NotFound();
            }

            return View(recipe_Ingredient);
        }

        // GET: Recipe_Ingredient/Create
        public IActionResult Create()
        {
            ViewData["IngredientId"] = new SelectList(_context.Ingredients, "Id", "Id");
            ViewData["RecipeId"] = new SelectList(_context.Recipes, "Id", "Id");
            return View();
        }

        // POST: Recipe_Ingredient/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,RecipeId,IngredientId,Quantity")] Recipe_Ingredient recipe_Ingredient)
        {
            if (ModelState.IsValid)
            {
                _context.Add(recipe_Ingredient);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IngredientId"] = new SelectList(_context.Ingredients, "Id", "Id", recipe_Ingredient.IngredientId);
            ViewData["RecipeId"] = new SelectList(_context.Recipes, "Id", "Id", recipe_Ingredient.RecipeId);
            return View(recipe_Ingredient);
        }

        // GET: Recipe_Ingredient/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Recipe_Ingredients == null)
            {
                return NotFound();
            }

            var recipe_Ingredient = await _context.Recipe_Ingredients.FindAsync(id);
            if (recipe_Ingredient == null)
            {
                return NotFound();
            }
            ViewData["IngredientId"] = new SelectList(_context.Ingredients, "Id", "Id", recipe_Ingredient.IngredientId);
            ViewData["RecipeId"] = new SelectList(_context.Recipes, "Id", "Id", recipe_Ingredient.RecipeId);
            return View(recipe_Ingredient);
        }

        // POST: Recipe_Ingredient/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,RecipeId,IngredientId,Quantity")] Recipe_Ingredient recipe_Ingredient)
        {
            if (id != recipe_Ingredient.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(recipe_Ingredient);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Recipe_IngredientExists(recipe_Ingredient.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["IngredientId"] = new SelectList(_context.Ingredients, "Id", "Id", recipe_Ingredient.IngredientId);
            ViewData["RecipeId"] = new SelectList(_context.Recipes, "Id", "Id", recipe_Ingredient.RecipeId);
            return View(recipe_Ingredient);
        }

        // GET: Recipe_Ingredient/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Recipe_Ingredients == null)
            {
                return NotFound();
            }

            var recipe_Ingredient = await _context.Recipe_Ingredients
                .Include(r => r.Ingredient)
                .Include(r => r.Recipe)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (recipe_Ingredient == null)
            {
                return NotFound();
            }

            return View(recipe_Ingredient);
        }

        // POST: Recipe_Ingredient/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Recipe_Ingredients == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Recipe_Ingredients'  is null.");
            }
            var recipe_Ingredient = await _context.Recipe_Ingredients.FindAsync(id);
            if (recipe_Ingredient != null)
            {
                _context.Recipe_Ingredients.Remove(recipe_Ingredient);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Recipe_IngredientExists(int id)
        {
          return (_context.Recipe_Ingredients?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
