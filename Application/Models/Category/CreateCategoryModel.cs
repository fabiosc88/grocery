using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Application.Models.Category
{
    /// <summary>
    ///  Create Category Model
    /// </summary>
    public sealed class CreateCategoryModel : BaseModel
    {
        /// <summary>
        /// Name of Category
        /// </summary>
        [Required(ErrorMessage = "O campo {0} é requerido.")]
        [MaxLength(32, ErrorMessage = "O campo {0} pode ter no máximo {1} caracteres.")]
        [DisplayName("Nome")]
        public string Name { get; set; }
    }
}
