using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Domain.Entities.Validations.ProductValidation;
using Domain.Resources;
using Domain.Exception;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Services
{
    /// <summary>
    /// Product Service Class
    /// </summary>
    public class ProductService : BaseService<Product>, IProductService
    {
        #region Properties

        /// <summary>
        /// Product Specialized Repository
        /// </summary>
        private readonly IProductRepository _productRepository;

        #endregion Properties

        #region Construtor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="productRepository">Product Repository</param>
        public ProductService(IProductRepository productRepository)
            : base(productRepository)
        {
            _productRepository = productRepository;
        }

        #endregion Construtor

        #region Create

        /// <summary>
        /// Insert new Product
        /// </summary>
        /// <param name="name">Name of Product</param>
        /// <param name="unit"></param>
        /// <param name="price">Price of Product</param>
        /// <param name="category">Product Category</param>
        public void Create(string name, string unit, decimal price, Category category)
        {
            //Create a new object
            var product = new Product(name, unit, price, category);

            //Validate object
            product.Validate();

            //Validate insert process
            new ProductIsValidCreateUpdateValidation(_productRepository).Validate(product);

            //Create category
            _productRepository.Create(product);
        }

        #endregion Create

        #region Update

        /// <summary>
        /// Update Product
        /// </summary>
        /// <param name="id">Identifier of Entity</param>
        /// <param name="name">Name of Product</param>
        /// <param name="unit"></param>
        /// <param name="price">Price of Product</param>
        /// <param name="category">Product Category</param>
        public void Update(long id, string name, string unit, decimal price, Category category)
        {
            //Get the product which has the Id received by param
            var productDb = _productRepository.GetById(id);

            //Check if regiter exists
            if (productDb == null)
                throw new CustomException(ValidationMessages.RecordNotFoundUpdate);

            //Update properties of entity
            productDb.Update(name, unit, price, category);

            //Validate object
            productDb.Validate();

            //Validate update process
            new ProductIsValidCreateUpdateValidation(_productRepository).Validate(productDb);

            //Update product
            _productRepository.Update(productDb);
        }

        /// <summary>
        /// Update Category
        /// </summary>
        /// <param name="id">Identifier of Entity</param>
        /// <param name="basket">Product in the Basket</param>
        /// <param name="category">Product Category</param>
        public void PutBasket(long id, bool basket, Category category)
        {
            //Get the product which has the Id received by param
            var productDb = _productRepository.GetById(id);
            productDb.Category = category;

            //Check if resgiter exists
            if (productDb == null)
                throw new CustomException(ValidationMessages.RecordNotFoundUpdate);

            var productListDb = _productRepository.List();

            //Get the last position of the product in the basket
            int basketOrder = productListDb.Count > 0 ? productListDb.Max(x => x.BasketOrder) + 1 : 1;

            //Update properties of entity
            productDb.PutBasket(basket, basketOrder);

            //Update product
            _productRepository.Update(productDb);
        }

        /// <summary>
        /// Sort the items of Basket
        /// </summary>
        /// <param name="ids">Array of Products Ids</param>
        /// <param name="categoryList">List of Category</param>
        public void SortBasket(long[] ids, IList<Category> categoryList)
        {
            //Get the product which has the Id received by param
            var productListDb = _productRepository.List(x => x.Basket).ToList();
            
            for (int i = 0; i < ids.Count(); i++)
            {
                //Get the product which has the same Id
                var productDb = productListDb.FirstOrDefault(x => x.Id == ids[i]);

                //If the product exists
                if (productDb != null)
                {
                    //Associate the category with each product of the list - To valdiation
                    productDb.Category = categoryList.FirstOrDefault(y => y.Id == productDb.CategoryId);

                    //Update the basket order
                    productDb.SortBasket(i + 1);

                    //Update the product
                    _productRepository.Update(productDb);
                }
            }
        }

        #endregion Update

        #region Delete

        /// <summary>
        /// Logically Delete
        /// </summary>
        /// <param name="id">Identifier of Entity</param>
        public void Delete(long id)
        {
            //Get the product which has the Id received by param
            var productDb = _productRepository.GetById(id);

            //Check if regiter exists
            if (productDb == null)
                throw new CustomException(ValidationMessages.RecordNotFoundUpdate);

            //Delete category
            _productRepository.Delete(productDb);
        }

        #endregion Delete
    }
}
