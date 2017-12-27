using Domain.Entities;
using Domain.ValueObjects;
using System.Collections.Generic;

namespace Domain.Interfaces.Services
{
    /// <summary>
    ///  Contract of Product Service
    /// </summary>
    public interface IProductService : IBaseService<Product>
    {
        #region Create

        /// <summary>
        /// Insert new Product
        /// </summary>
        /// <param name="name">Name of Product</param>
        /// <param name="unit"></param>
        /// <param name="price">Price of Product</param>
        /// <param name="category">Product Category</param>
        void Create(string name, string unit, decimal price, Category category);

        #endregion Create

        #region Update

        /// <summary>
        /// Update Product
        /// </summary>
        /// <param name="id">Identifier of Entity</param>
        /// <param name="name">Name of Product</param>
        /// <param name="unit"></param>
        /// <param name="price">Price of Product</param>
        /// <param name="category">Product Category</param>
        void Update(long id, string name, string unit, decimal price, Category category);

        /// <summary>
        /// Put the Product in the Basket
        /// </summary>
        /// <param name="id">Identifier of Entity</param>
        /// <param name="basket">Basket</param>
        /// <param name="category">Product Category</param>
        void PutBasket(long id, bool basket, Category category);

        /// <summary>
        /// Sort the items of Basket
        /// </summary>
        /// <param name="ids">Array of Products Ids</param>
        /// <param name="categoryList">List Of Category</param>
        void SortBasket(long[] ids, IList<Category> categoryList);

        #endregion Update

        #region Delete

        /// <summary>
        /// Logically Delete
        /// </summary>
        /// <param name="id">Identifier of Entity</param>
        void Delete(long id);

        #endregion Delete
    }
}
