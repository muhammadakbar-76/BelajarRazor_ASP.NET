using BelajarRazor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BelajarRazor.Pages.Categories
{
    public class DeleteModel : PageModel
    {
        private readonly DataContext _db;
        public DeleteModel(DataContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Category Category { get; set; }
        public IActionResult OnGet(int Id)
        {
            var cat = _db.Category.Find(Id);
            if (cat == null) return RedirectToPage("Index");
            Category = cat;
            return Page();
        }

        public IActionResult OnPost()
        {
            //ModelState isn't working on disabled input
            _db.Category.Remove(Category);
            _db.SaveChanges();
            TempData["success"] = "Data Deleted Successfully";
            return RedirectToPage("Index");
        }
    }
}
