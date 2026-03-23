using BulkywebRazer_temp.Data;
using BulkywebRazer_temp.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BulkywebRazer_temp.Pages.Categories
{
    [BindProperties]  // esse Bind faz o bind de todos os objetos da estrutura.
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        //esse Bind propertiy é usado para preencher os objetos no Razor pages diz e for 1 obj
        //[BindProperty]
        public Category Category { get; set; }
        public EditModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public void OnGet(int? id)
        {
            if (id !=null && id != 0){

                Category = _db.Categories.Find(id);
            }
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                _db.Categories.Update(Category);
                _db.SaveChanges();
                TempData["success"] = "Category Updated successfuly";
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
