using Domain.Resources;
using Domain.Validation;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace Domain.Entities
{
    /// <summary>
    /// Entity of Category
    /// </summary>
    [XmlRoot("Category")]
    public class Category : BaseEntity
    {
        #region Properties

        /// <summary>
        /// Name of Category
        /// </summary>
        [DataMember]
        [XmlElement("Name")]
        public string Name { get; set; }

        #region Relationships

        /// <summary>
        /// List of de Products
        /// </summary>
        [XmlIgnore]
        public virtual List<Product> ProductList { get; set; }

        #endregion Relationships

        #endregion Properties

        #region Construtor

        /// <summary>
        /// Parameterless Constructor
        /// </summary>
        protected Category() { }

        /// <summary>
        /// Constructor responsible for creating an already completed entity and validating the values
        /// </summary>
        /// <param name="nome">Name of Category</param>
        public Category(string name)
        {
            this.Name = name;
        }

        #endregion Construtor

        #region Methods

        /// <summary>
        /// ToString on Entity
        /// </summary>
        /// <returns>Name of Category</returns>
        public override string ToString()
        {
            return this.Name.ToString();
        }

        /// <summary>
        /// Validate Entity Data
        /// </summary>
        public override void Validate()
        {
            AssertionConcern.AssertArgumentLength(this.Name, 3, 32, string.Format(ValidationMessages.MinMaxLength, "name", 3, 32));
        }

        /// <summary>
        /// Update Entity Data
        /// </summary>
        /// <param name="nome">Name of Category</param>
        public void Update(string name)
        {
            this.Name = name;
        }

        #endregion Methods
    }
}
