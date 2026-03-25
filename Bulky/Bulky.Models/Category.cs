using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Security.Principal;

namespace Bulky.Models
{
    public class Category
    {
      //  [Key]   // isso chama dat Annotation, serve para indicar qual variável é a chave primária.
        public int Id { get; set; }
        [Required] // define que as varivéis do objeto precisam ser preenchidas antes de enviar, mas se não indicar nada, isso ja é definido por default
        [MaxLength(30)]
        [DisplayName("Category Name")]
        public string Name { get; set; }
        [DisplayName("Display Order")]
        [Range(1, 30, ErrorMessage ="Display Order must be between 1-30")]
        public int DisplayOrder { get; set; }
    }
}
