using BelajarRazor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BelajarRazor.Pages.Categories
{
    [BindProperties]
    public class CreateModel : PageModel
    {
        private readonly DataContext _db;
        public CreateModel(DataContext db)
        {
            _db = db;
        }
        public Category Category { get; set; } 
        public void OnGet() { }
       
        public async Task<IActionResult> OnPost()
        {
            if (Category.Name == Category.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Category.Name", "Name and Display Order can't be the same");
            }
            if(!ModelState.IsValid) return Page();
            await _db.Category.AddAsync(Category);
            await _db.SaveChangesAsync();
            TempData["success"] = "Data Created Successfully";
            return RedirectToPage("Index");
        }
    }
}
