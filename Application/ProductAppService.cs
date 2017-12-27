
using Application.Interfaces;
using Application.Models.Product;
using Domain.Entities;
using Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Application
{
    /// <summary>
    /// Class of Product App which is responsible to call ProductService of Domain
    /// </summary>
    public class ProductAppService : IProductAppService
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
        /// <param name="productService">Product Service</param>
        public ProductAppService(ICategoryService categoryService, IProductService productService)
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
        public Product GetById(long id, bool lazyLoad = false)
        {
            var product = _productService.GetById(id);

            if (lazyLoad)
                product.Category = _categoryService.GetById(product.CategoryId);

            return product;
        }

        /// <summary>
        /// Get the first object found and obyes the expression "where"
        /// </summary>
        /// <param name="wherePredicate">Lambda Expression "Where" to make an sql</param>
        /// <param name="lazyLoad">Entities of Relationships</param>
        /// <returns>First element</returns>
        public virtual Product GetFirst(Func<Product, bool> wherePredicate, bool lazyLoad = false)
        {
            var product = _productService.GetFirst(wherePredicate);

            if (lazyLoad)
                product.Category = _categoryService.GetById(product.CategoryId);

            return product;
        }

        #endregion Get

        #region List

        /// <summary>
        /// List all registers
        /// </summary>
        /// <param name="lazyLoad">Entities of Relationships</param>
        /// <returns></returns>
        public IList<Product> List(bool lazyLoad = false)
        {
            var list = _productService.List().ToList();

            if (lazyLoad)
                list.ForEach(x => { x.Category = _categoryService.GetById(x.CategoryId); });

            return list;
        }

        /// <summary>
        /// List all registers which obey the expression "where"
        /// </summary>
        /// <param name="wherePredicate">Lambda Expression "Where" to buil an sql</param>
        /// <param name="lazyLoad">Entities of Relationships</param>
        /// <returns></returns>
        public IList<Product> List(Func<Product, bool> wherePredicate, bool lazyLoad = false)
        {
            var list = _productService.List(wherePredicate).ToList();

            if (lazyLoad)
                list.ForEach(x => { x.Category = _categoryService.GetById(x.CategoryId); });

            return list;
        }

        #endregion List

        #region Create

        /// <summary>
        /// Insert new Product
        /// </summary>
        /// <param name="newProductModel">Product Model of Insertion</param>
        public void Create(CreateProductModel newProductModel)
        {
            //Insert Product
            _productService.Create(newProductModel.Name, 
                newProductModel.Unit, 
                newProductModel.Price, 
                _categoryService.GetById(newProductModel.CategoryId));
        }

        #endregion Create

        #region Update

        /// <summary>
        /// Update Product
        /// </summary>
        /// <param name="editCategoryModel">Product Model of Edition</param>
        public void Update(EditProductModel editProductModel)
        {
            //Update Product
            _productService.Update(editProductModel.Id,
                editProductModel.Name,
                editProductModel.Unit,
                editProductModel.Price,
                _categoryService.GetById(editProductModel.CategoryId));
        }

        /// <summary>
        /// Put the Product in the Basket
        /// </summary>
        /// <param name="id">Identifier of Entity</param>
        /// <param name="basket">Product in the Basket</param>
        /// <param name="categoryId">Identifier of Category</param>
        public void PutBasket(long id, bool basket, long categoryId)
        {
            //Update Product
            _productService.PutBasket(id, basket, _categoryService.GetById(categoryId));
        }

        /// <summary>
        /// Sort the items of Basket
        /// </summary>
        /// <param name="ids">Array of Products Ids</param>
        public void SortBasket(long[] ids)
        {
            //Update Product
            _productService.SortBasket(ids, _categoryService.List());
        }

        #endregion Update

        #region Delete

        /// <summary>
        /// Logically Delete
        /// </summary>
        /// <param name="id">Identifier of Entity</param>
        public void Delete(long id)
        {
            //Update Product
            _productService.Delete(id);
        }

        #endregion Delete

        #region Dispose

        /// <summary>
        ///  Release object from memory
        /// </summary>
        public void Dispose()
        {
            if (_productService != null)
                //Release a concrect class that implements an interface IBaseRepository
                _productService.Dispose();

            GC.SuppressFinalize(this);
        }

        #endregion Dispose
    }
}
