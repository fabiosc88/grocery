using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Application.Models.Product
{
    /// <summary>
    /// Model of Create Product
    /// </summary>
    public sealed class CreateProductModel : BaseModel
    {
        /// <summary>
        /// Name of Product
        /// </summary>
        [Required(ErrorMessage = "O campo {0} é requerido.")]
        [MaxLength(64, ErrorMessage = "O campo {0} pode ter no máximo {1} caracteres.")]
        [DisplayName("Nome")]
        public string Name { get; set; }

        /// <summary>
        /// Unit of Product (Ex: Grams, Unity, Liters)
        /// </summary>
        [Required(ErrorMessage = "O campo {0} é requerido.")]
        [MaxLength(16, ErrorMessage = "O campo {0} pode ter no máximo {1} caracteres.")]
        [DisplayName("Unidade")]
        public string Unit { get; set; }

        /// <summary>
        /// Price of Product
        /// </summary>
        [Required(ErrorMessage = "O campo {0} é requerido.")]
        [DisplayName("Preço")]
        public decimal Price { get; set; }

        /// <summary>
        /// List of Categories
        /// </summary>
        public IEnumerable<Domain.Entities.Category> CategoryList { get; set; }

        /// <summary>
        /// Identifier of Category
        /// </summary>
        [Required(ErrorMessage = "O campo {0} é requerido.")]
        [DisplayName("Categoria")]
        public long CategoryId { get; set; }
    }
}
