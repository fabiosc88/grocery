using Application.Interfaces;
using Application.Models.Product;
using AutoMapper;
using Domain.Entities;
using GRC.UI.MVC.Notifications;
using Domain.Resources;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Domain.Exception;
using System.Linq;

namespace GRC.UI.MVC.Controllers
{
    public class ProductsController : Controller
    {
        #region Properties

        /// <summary>
        /// Product App Service
        /// </summary>
        private readonly IProductAppService _productService;

        /// <summary>
        /// Category App Service
        /// </summary>
        private readonly ICategoryAppService _categoryService;

        #endregion Properties

        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="productService"></param>
        /// <param name="categoryService"></param>
        public ProductsController(IProductAppService productService, ICategoryAppService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }

        #endregion Constructor

        #region Index

        /// <summary>
        /// Load Main Page
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            var list = _productService.List(true).OrderByDescending(x => x.Id).ToList();

            var vm = Mapper.Map<IList<Product>, IList<ListGridProductModel>>(list);

            return View(vm);
        }

        #endregion Index

        #region Create

        /// <summary>
        /// Load Page
        /// </summary>
        /// <returns>ViewModel Empty</returns>
        public ActionResult Create()
        {
            var vm = new CreateProductModel()
            {
                CategoryList = _categoryService.List().OrderBy(x => x.Name).ToList()
            };

            return View(vm);
        }

        /// <summary>
        /// Create a new product
        /// </summary>
        /// <param name="vm">ViewModel</param>
        /// <returns>Result of Operation</returns>
        [HttpPost]
        public ActionResult Create(CreateProductModel vm)
        {
            try
            {
                //Keep the list of DropDown
                vm.CategoryList = _categoryService.List().OrderBy(x => x.Name).ToList();

                //Check data validation
                if (!ModelState.IsValid)
                {
                    this.AddToastMessage(Messages.InvalidValueField, ToastType.Error);
                    return View("Create", vm);
                }

                //Create Product
                _productService.Create(vm);

                //Successfully message
                this.AddToastMessage(string.Format(Messages.RecordSavedSuccessfully, "product"), ToastType.Success);

                return RedirectToAction("Index");
            }
            catch (CustomException ex)
            {
                this.AddToastMessage(ex.Message, ToastType.Error);
                return View("Create", vm);
            }
            catch (Exception ex)
            {
                this.AddToastMessage(Messages.GeneralError, ToastType.Error);
                return View("Create", vm);
            }
        }

        #endregion Create

        #region Edit

        /// <summary>
        /// Load Page
        /// </summary>
        /// <param name="id">Identifier of Entity</param>
        /// <returns>ViewModel Filled</returns>
        public ActionResult Edit(long id)
        {
            try
            {
                var vm = Mapper.Map<Product, EditProductModel>(_productService.GetById(id));
                vm.CategoryList = _categoryService.List().OrderBy(x => x.Name).ToList();

                if (vm == null)
                    this.AddToastMessage(ValidationMessages.RecordNotFound, ToastType.Info);

                return View(vm);
            }
            catch (Exception ex)
            {
                this.AddToastMessage(Messages.GeneralError, ToastType.Error);
                return View("Edit", new EditProductModel());
            }
        }

        /// <summary>
        /// Edit a product
        /// </summary>
        /// <param name="vm"></param>
        /// <returns>Result of Operation</returns>
        [HttpPost]
        public ActionResult Edit(EditProductModel vm)
        {
            try
            {
                //Keep the list of DropDown
                vm.CategoryList = _categoryService.List().OrderBy(x => x.Name).ToList();

                //Check data validation
                if (!ModelState.IsValid)
                {
                    this.AddToastMessage(Messages.InvalidValueField, ToastType.Error);
                    return View("Edit", vm);
                }

                //Update Product
                _productService.Update(vm);

                //Successfully message
                this.AddToastMessage(string.Format(Messages.RecordSavedSuccessfully, "product"), ToastType.Success);

                return RedirectToAction("Index");
            }
            catch (CustomException ex)
            {
                this.AddToastMessage(ex.Message, ToastType.Error);
                return View("Edit", vm);
            }
            catch (Exception ex)
            {
                this.AddToastMessage(Messages.GeneralError, ToastType.Error);
                return View("Edit", vm);
            }
        }

        #endregion Edit

        #region Delete

        /// <summary>
        /// DeleteProduct
        /// </summary>
        /// <param name="id">Identifier of Entity</param>
        /// <returns></returns>
        [HttpDelete]
        public ActionResult Delete(long id)
        {
            try
            {
                //Delete
                _productService.Delete(id);

                //Successfully message
                this.AddToastMessage(string.Format(Messages.RecordDeletedSuccessfully, "product"), ToastType.Success);

                return RedirectToAction("Index");
            }
            catch (CustomException ex)
            {
                this.AddToastMessage(ex.Message, ToastType.Error);
                return View();
            }
            catch (Exception ex)
            {
                this.AddToastMessage(Messages.GeneralError, ToastType.Error);
                return View();
            }
        }

        #endregion Delete
    }
}