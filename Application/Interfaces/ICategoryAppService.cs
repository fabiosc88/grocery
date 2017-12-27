using Application.Models.Category;
using Domain.Entities;

namespace Application.Interfaces
{
    /// <summary>
    /// Contract of Category App which is responsible to call CategoryService of Domain
    /// </summary>
    public interface ICategoryAppService : IBaseAppService<Category>
    {
        #region Create

        /// <summary>
        /// Create new Category
        /// </summary>
        /// <param name="newCategoryModel">Category Model of Insertion</param>
        void Create(CreateCategoryModel newCategoryModel);

        #endregion Create

        #region Update

        /// <summary>
        /// Update Category
        /// </summary>
        /// <param name="editCategoryModel">Category Model of Edition</param>
        void Update(EditCategoryModel editCategoryModel);

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
