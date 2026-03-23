using BulkywebRazer_temp.Data;
using BulkywebRazer_temp.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BulkywebRazer_temp.Pages.Categories
{
    [BindProperties]  // esse Bind faz o bind de todos os objetos da estrutura.
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        //esse Bind propertiy é usado para preencher os objetos no Razor pages diz e for 1 obj
        //[BindProperty]
        public Category Category { get; set; }
        public DeleteModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public void OnGet(int? id)
        {
            if (id != null && id != 0)
            {

                Category = _db.Categories.Find(id);
            }
        }

        public IActionResult OnPost()
        {
            Category obj = _db.Categories.Find(Category.Id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.Categories.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "Category deleted successfuly";
            return RedirectToPage("Index");
        }
    }
}
