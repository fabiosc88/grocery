using Application.Interfaces;
using Application.Models.Category;
using Domain.Entities;
using Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Application
{
    /// <summary>
    /// Class of Category App which is responsible to call CategoryService of Domain
    /// </summary>
    public class CategoryAppService : ICategoryAppService
    {
        #region Properties

        /// <summary>
        /// Category Specialized Service
        /// </summary>
        private readonly ICategoryService _categoryService;

        /// <summary>
        /// Product Specialized Service
        /// </summary>
        private readonly IProductService _productService;

        #endregion Properties

        #region Construtor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="categoryService">Category Service</param>
        public CategoryAppService(ICategoryService categoryService, IProductService productService)
        {
            _categoryService = categoryService;
            _productService = productService;
        }

        #endregion Construtor

        #region Get

        /// <summary>
        /// Get an object by Id
        /// </summary>
        /// <param name="id">Entity Identifier</param>
        /// <param name="lazyLoad">Entities of Relationships</param>
        /// <returns>Object</returns>
        public Category GetById(long id, bool lazyLoad = false)
        {
            var category = _categoryService.GetById(id);

            if (lazyLoad)
                category.ProductList = (List<Product>)_productService.List(x => x.CategoryId == category.Id);

            return category;
        }

        /// <summary>
        /// Get the first object found and obyes the expression "where"
        /// </summary>
        /// <param name="wherePredicate">Lambda Expression "Where" to make an sql</param>
        /// <param name="lazyLoad">Entities of Relationships</param>
        /// <returns>First element</returns>
        public virtual Category GetFirst(Func<Category, bool> wherePredicate, bool lazyLoad = false)
        {
            var category = _categoryService.GetFirst(wherePredicate);

            if (lazyLoad)
                category.ProductList = (List<Product>)_productService.List(x => x.CategoryId == category.Id);

            return category;
        }

        #endregion Get

        #region List

        /// <summary>
        /// List all registers
        /// </summary>
        /// <param name="lazyLoad">Entities of Relationships</param>
        /// <returns></returns>
        public IList<Category> List(bool lazyLoad = false)
        {
            var list = _categoryService.List().ToList();
            
            if (lazyLoad)
                list.ForEach(x => { x.ProductList = new List<Product>(_productService.List(y => y.CategoryId == x.Id)); });

            return list;
        }

        /// <summary>
        /// List all registers which obey the expression "where"
        /// </summary>
        /// <param name="wherePredicate">Lambda Expression "Where" to buil an sql</param>
        /// <param name="lazyLoad">Entities of Relationships</param>
        /// <returns></returns>
        public IList<Category> List(Func<Category, bool> wherePredicate, bool lazyLoad = false)
        {
            var list = _categoryService.List(wherePredicate).ToList();

            if (lazyLoad)
                list.ForEach(x => { x.ProductList = new List<Product>(_productService.List(y => y.CategoryId == x.Id)); });

            return list;
        }

        #endregion List

        #region Insert

        /// <summary>
        /// Insert new Category
        /// </summary>
        /// <param name="newCategoryModel">Category Model of Insertion</param>
        public void Create(CreateCategoryModel newCategoryModel)
        {
            //Insert Category
            _categoryService.Insert(newCategoryModel.Name);
        }

        #endregion Insert

        #region Update

        /// <summary>
        /// Update Category
        /// </summary>
        /// <param name="editCategoryModel">Category Model of Edition</param>
        public void Update(EditCategoryModel editCategoryModel)
        {
            //Update Category
            _categoryService.Update(editCategoryModel.Id, editCategoryModel.Name);
        }

        #endregion Update

        #region Delete

        /// <summary>
        /// Logically Delete
        /// </summary>
        /// <param name="id">Identifier of Entity</param>
        public void Delete(long id)
        {
            //Update Category
            _categoryService.Delete(id);
        }

        #endregion Delete

        #region Dispose

        /// <summary>
        ///  Release object from memory
        /// </summary>
        public void Dispose()
        {
            if (_categoryService != null)
                //Release a concrect class that implements an interface IBaseRepository
                _categoryService.Dispose();

            GC.SuppressFinalize(this);
        }

        #endregion Dispose
    }
}
