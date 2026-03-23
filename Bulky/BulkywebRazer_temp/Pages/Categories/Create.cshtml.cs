using BulkywebRazer_temp.Data;
using BulkywebRazer_temp.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BulkywebRazer_temp.Pages.Categories
{
    [BindProperties]  // esse Bind faz o bind de todos os objetos da estrutura.
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        //esse Bind propertiy é usado para preencher os objetos no Razor pages diz e for 1 obj
        //[BindProperty]
        public Category Category { get; set; }
        public CreateModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public void OnGet()
        {

        }
        public IActionResult OnPost()
        {
            _db.Categories.Add(Category);
            _db.SaveChanges();
            TempData["success"] = "Category created successfuly";
            return RedirectToPage("Index");
        }
    }
}
