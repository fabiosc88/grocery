using Domain.Entities;
using Domain.Exception;
using Domain.Interfaces.Repositories;
using Domain.Resources;
using System.Linq;

namespace Domain.Entities.Validations.CategoryValidation
{
    /// <summary>
    /// Validate if Category doesn't have relationship with Product
    /// </summary>
    public class CategoryIsValidDeleteValidation
    {
        #region Propertier

        /// <summary>
        /// Category Repository
        /// </summary>
        private readonly ICategoryRepository _categoryRepository;

        #endregion Propertier

        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="categoriaRepository">Category Repository</param>
        public CategoryIsValidDeleteValidation(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        #endregion Constructor

        #region Methods

        /// <summary>
        /// Validate if the name has already been registered in database
        /// </summary>
        /// <param name="category"> Category object instace</param>
        /// <returns></returns>
        public void Validate(Category category)
        {
            //If Category doesn't have product associated it's True
            if (category.ProductList != null && category.ProductList.Count > 0)
            {
                string[] products = category.ProductList.Select(x => { return x.Name; }).ToArray();
                string menssage = string.Format(ValidationMessages.ExistingRelationship, "products: " + string.Join(",", products));

                throw new CustomException(menssage);
            }
        }

        #endregion Methods
    }
}
