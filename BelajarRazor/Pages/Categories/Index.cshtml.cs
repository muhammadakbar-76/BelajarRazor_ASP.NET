
using BelajarRazor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BelajarRazor.Pages.Categories
{
    public class IndexModel : PageModel
    {
        private readonly DataContext _db;

        public IndexModel(DataContext db)
        {
            _db = db;
        }
        public IEnumerable<Category> Categories { get; set; }
        public void OnGet()
        {
            Categories = _db.Category;
        }
    }
}
