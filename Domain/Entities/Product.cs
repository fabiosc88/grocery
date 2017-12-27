
using Domain.Resources;
using Domain.Validation;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace Domain.Entities
{
    /// <summary>
    /// Entity of Product
    /// </summary>
    [XmlRoot("Product")]
    public class Product : BaseEntity
    {
        #region Properties

        /// <summary>
        /// Name of Product
        /// </summary>
        [XmlElement("Name")]
        [DataMember]
        public string Name { get; set; }

        /// <summary>
        /// Unit of Product (Ex: Grams, Unity, Liters)
        /// </summary>
        [XmlElement("Unit")]
        [DataMember]
        public string Unit { get; set; }

        /// <summary>
        /// Price of Product
        /// </summary>
        [XmlElement("Price")]
        [DataMember]
        public decimal Price { get; set; }

        /// <summary>
        /// Product in the Basket
        /// </summary>
        [XmlElement("Basket")]
        [DataMember]
        public bool Basket { get; set; }

        /// <summary>
        /// Product in the Basket
        /// </summary>
        [XmlElement("BasketOrder")]
        [DataMember]
        public int BasketOrder { get; set; }

        #region Relationships

        /// <summary>
        /// Category of Product
        /// </summary>
        [XmlIgnore]
        public virtual Category Category { get; set; }

        /// <summary>
        /// Category Identifier - FK
        /// </summary>
        [XmlElement("CategoryId")]
        public long CategoryId { get; set; }

        #endregion Relationships

        #endregion Properties

        #region Construtor

        /// <summary>
        /// Parameterless Constructor
        /// </summary>
        protected Product() { }

        /// <summary>
        /// Constructor responsible for creating an already completed entity
        /// </summary>
        /// <param name="nome">Name of Product</param>
        /// <param name="status">Status</param>
        /// <param name="unit"></param>
        /// <param name="price">Price of Product</param>
        /// <param name="category">Product Category</param>
        public Product(string name, string unit, decimal price, Category category)
        {
            this.Name = name;
            this.Unit = unit;
            this.Price = price;
            this.Category = category;
            this.CategoryId = category.Id;
        }

        #endregion Construtor

        #region Methods

        /// <summary>
        /// ToString on Entity
        /// </summary>
        /// <returns>Name of Product</returns>
        public override string ToString()
        {
            return this.Name.ToString();
        }

        /// <summary>
        /// Validate Entity Data
        /// </summary>
        public override void Validate()
        {
            AssertionConcern.AssertArgumentLength(this.Name, 3, 64, string.Format(ValidationMessages.MinMaxLength, "name", 3, 64));
            AssertionConcern.AssertArgumentLength(this.Unit, 3, 16, string.Format(ValidationMessages.MinMaxLength, "unit", 3, 16));
            AssertionConcern.AssertArgumentNotEquals(this.Price, 0, string.Format(ValidationMessages.InvalidPrice, "0"));
            AssertionConcern.AssertArgumentNotNull(this.Category, string.Format(ValidationMessages.RequiredField, "category"));
        }

        /// <summary>
        /// Update Entity Data
        /// </summary>
        /// <param name="nome">Name of Product</param>
        /// <param name="status">Status</param>
        /// <param name="unit"></param>
        /// <param name="price">Price of Product</param>
        /// <param name="category">Product Category</param>
        public void Update(string name, string unit, decimal price, Category category)
        {
            this.Name = name;
            this.Unit = unit;
            this.Price = price;
            this.Category = category;
            this.CategoryId = category.Id;
        }

        /// <summary>
        /// Put the Product in the Basket
        /// </summary>
        /// <param name="basket">Basket</param>
        public void PutBasket(bool basket, int basketOrder)
        {
            this.Basket = basket;
            this.BasketOrder = BasketOrder;
        }

        /// <summary>
        /// Sort the items of Basket
        /// </summary>
        /// <param name="basketOrder">Basket Order</param>
        public void SortBasket(int basketOrder)
        {
            this.BasketOrder = basketOrder;
        }

        #endregion Methods
    }
}
