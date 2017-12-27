using Domain.Entities;
using Domain.ValueObjects;

namespace Domain.Interfaces.Services
{
    /// <summary>
    ///  Contract of Category Service
    /// </summary>
    public interface ICategoryService : IBaseService<Category>
    {
        #region Insert

        /// <summary>
        /// Insert new Category
        /// </summary>
        /// <param name="name">Name of Category</param>
        void Insert(string name);

        #endregion Insert

        #region Update

        /// <summary>
        /// Update Category
        /// </summary>
        /// <param name="id">Identifier of Entity</param>
        /// <param name="name">Name of Product</param>
        void Update(long id, string name);

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
