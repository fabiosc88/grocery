using Domain.Entities;
using Domain.Exception;
using Domain.Interfaces.Repositories;
using Domain.Resources;

namespace Domain.Entities.Validations.CategoryValidation
{
    /// <summary>
    /// Validate data before to salve in database
    /// </summary>
    public class CategoryIsValidCreateUpdateValidation
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
        public CategoryIsValidCreateUpdateValidation(ICategoryRepository categoryRepository)
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
            bool validation = true;

            //Get category with same name
            var categoryDb = _categoryRepository.GetFirst(x => x.Name.ToLower().Trim() == category.Name.ToLower().Trim());

            if (categoryDb != null)
                //If category has the same name but  the Id is the same
                validation = (categoryDb.Id == category.Id); 

            if(!validation)
                throw new CustomException(ValidationMessages.ExistingRecord);
        }

        #endregion Methods
    }
}
