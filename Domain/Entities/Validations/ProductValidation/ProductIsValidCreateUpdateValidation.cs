using Domain.Entities;
using Domain.Exception;
using Domain.Interfaces.Repositories;
using Domain.Resources;

namespace Domain.Entities.Validations.ProductValidation
{
    /// <summary>
    /// Class to validate data before to salve in database
    /// </summary>
    public class ProductIsValidCreateUpdateValidation
    {
        #region Propertier

        /// <summary>
        /// Product Repository
        /// </summary>
        private readonly IProductRepository _productRepository;

        #endregion Propertier

        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="categoriaRepository">Product Repository</param>
        public ProductIsValidCreateUpdateValidation(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        #endregion Constructor

        #region Methods

        /// <summary>
        /// Validate if the name has already been registered in database
        /// </summary>
        /// <param name="product">Product object instace</param>
        /// <returns></returns>
        public void Validate(Product product)
        {
            bool validation = true;

            //Get product with same name
            var productDb = _productRepository.GetFirst(x => x.Name.ToLower().Trim() == product.Name.ToLower().Trim());

            if (productDb != null)
                //If product has the same name but the Id is the same
                validation = (productDb.Id == product.Id);
            
            if (!validation)
                throw new CustomException(ValidationMessages.ExistingRecord);
        }

        #endregion Methods
    }
}
