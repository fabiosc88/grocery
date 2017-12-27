using Domain.Entities;
using Domain.Interfaces.Repositories;

namespace Infra.Data.Repositories
{
    /// <summary>
    /// Product Repository
    /// </summary>
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        #region Construtor

        /// <summary>
        /// Constructor
        /// </summary>
        public ProductRepository()
        {

        }

        #endregion Construtor
    }
}
