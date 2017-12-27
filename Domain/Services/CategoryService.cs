using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Domain.Entities.Validations.CategoryValidation;
using Domain.Resources;
using Domain.Exception;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Services
{
    /// <summary>
    /// Category Service Class
    /// </summary>
    public class CategoryService : BaseService<Category>, ICategoryService
    {
        #region Properties

        /// <summary>
        /// Category Specialized Repository
        /// </summary>
        private readonly ICategoryRepository _categoryRepository;

        /// <summary>
        /// Product Specialized Repository
        /// </summary>
        private readonly IProductRepository _productRepository;

        #endregion Properties

        #region Construtor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="categoriaRepository">Category Repository</param>
        /// <param name="categoriaRepository">Category Repository</param>
        public CategoryService(ICategoryRepository categoryRepository, IProductRepository productRepository)
            : base(categoryRepository)
        {
            _categoryRepository = categoryRepository;
            _productRepository = productRepository;
        }

        #endregion Construtor

        #region Insert

        /// <summary>
        /// Insert new Category
        /// </summary>
        /// <param name="name">Name of Category</param>
        public void Insert(string name)
        {
            //Create a new object
            var category = new Category(name);

            //Validate object
            category.Validate();

            //Validate insert process
            new CategoryIsValidCreateUpdateValidation(_categoryRepository).Validate(category);

            //Insert category
            _categoryRepository.Create(category);
        }

        #endregion Insert

        #region Update

        /// <summary>
        /// Update Category
        /// </summary>
        /// <param name="id">Identifier of Entity</param>
        /// <param name="name">Name of Category</param>
        public void Update(long id, string name)
        {
            //Get the category which has the Id received by param
            var categoryDb = _categoryRepository.GetById(id);

            //Check if regiter exists
            if (categoryDb == null)
                throw new CustomException(ValidationMessages.RecordNotFoundUpdate);

            //Update properties of entity
            categoryDb.Update(name);

            //Validate object
            categoryDb.Validate();

            //Validate insert process
            new CategoryIsValidCreateUpdateValidation(_categoryRepository).Validate(categoryDb);

            //Update category
            _categoryRepository.Update(categoryDb);
        }

        #endregion Update

        #region Delete

        /// <summary>
        /// Logically Delete
        /// </summary>
        /// <param name="id">Identifier of Entity</param>
        public void Delete(long id)
        {
            //Get the category which has the Id received by param
            var categoryDb = _categoryRepository.GetById(id);
            categoryDb.ProductList = _productRepository.List(x => x.CategoryId == categoryDb.Id).ToList();

            //Check if regiter exists
            if (categoryDb == null)
                throw new CustomException(ValidationMessages.RecordNotFoundUpdate);

            //Validate delete process
            new CategoryIsValidDeleteValidation(_categoryRepository).Validate(categoryDb);

            //Delete category
            _categoryRepository.Delete(categoryDb);
        }

        #endregion Delete
    }
}
