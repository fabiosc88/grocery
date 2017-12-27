namespace Application.Models.Shop
{
    public sealed class ShopModel : BaseModel
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
        /// Basket
        /// </summary>
        public bool Basket { get; set; }

        /// <summary>
        /// Identifier of Category
        /// </summary>
        public long CategoryId { get; set; }

        /// <summary>
        /// Name of Category
        /// </summary>
        public string CategoryName { get; set; }
    }
}
