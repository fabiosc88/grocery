using Application.Models.Product;
using Domain.Entities;

namespace Application.Interfaces
{
    /// <summary>
    /// Contract of Product App which is responsible to call ProductService of Domain
    /// </summary>
    public interface IProductAppService : IBaseAppService<Product>
    {
        #region Create

        /// <summary>
        /// Insert new Product
        /// </summary>
        /// <param name="newProductModel">Product Model of Insertion</param>
        void Create(CreateProductModel newProductModel);

        #endregion Create

        #region Update

        /// <summary>
        /// Update Product
        /// </summary>
        /// <param name="editProductModel">Product Model of Edition</param>
        void Update(EditProductModel editProductModel);

        /// <summary>
        /// Put the Product in the Basket
        /// </summary>
        /// <param name="id">Identifier of Entity</param>
        /// <param name="basket">Basket</param>
        /// <param name="categoryId">Identifier of Category</param>
        void PutBasket(long id, bool basket, long categoryId);

        /// <summary>
        /// Sort the items of Basket
        /// </summary>
        /// <param name="ids">Array of Products Ids</param>
        void SortBasket(long[] ids);

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
