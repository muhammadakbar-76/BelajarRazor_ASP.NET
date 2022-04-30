using BelajarRazor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BelajarRazor.Pages.Categories
{
    [BindProperties]
    public class EditModel : PageModel
    {
        private readonly DataContext _db;

        public Category Category { get; set; }

        public EditModel(DataContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> OnGet(int Id)
        {
            var cat = await _db.Category.FindAsync(Id);
            if (cat == null) return RedirectToPage("Index");
            Category = cat;
            return Page();
        }

        public IActionResult OnPost()
        {
            if (Category.Name == Category.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Category.Name", "Name and Display Order can't be the same");
            }
            if (!ModelState.IsValid) return Page();
            _db.Category.Update(Category);
            _db.SaveChanges();
            TempData["success"] = "Data Edited Successfully";
            return RedirectToPage("Index");
        }
    }
}
