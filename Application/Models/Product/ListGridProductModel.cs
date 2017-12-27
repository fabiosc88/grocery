
namespace Application.Models.Product
{
    /// <summary>
    /// Model of Product List
    /// </summary>
    public sealed class ListGridProductModel : BaseModel
    {
        /// <summary>
        /// Name of Product
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Unit of Product (Ex: Grams, Unity, Liters)
        /// </summary>
        public string Unit { get; set; }

        /// <summary>
        /// Price of Product
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Name of Category
        /// </summary>
        public string CategoryName { get; set; }
    }
}
