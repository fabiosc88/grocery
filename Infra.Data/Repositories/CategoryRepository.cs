using Domain.Entities;
using Domain.Interfaces.Repositories;

namespace Infra.Data.Repositories
{
    /// <summary>
    /// Category Repository
    /// </summary>
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        #region Construtor

        /// <summary>
        /// Constructor
        /// </summary>
        public CategoryRepository()
        {

        }

        #endregion Construtor
    }
}
