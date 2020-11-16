using System.ComponentModel.DataAnnotations;

namespace src.Web.DTOs
{
    public class CategoryDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="{0} alanı boş olamaz."),Display(Name ="Category Name")]
        public string Name { get; set; }
    }
}
