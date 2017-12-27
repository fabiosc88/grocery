using Application.Interfaces;
using Application.Models.Shop;
using AutoMapper;
using Domain.Entities;
using Domain.Exception;
using Domain.Resources;
using GRC.UI.MVC.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace GRC.UI.MVC.Controllers
{
    public class ShopController : Controller
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
        public ShopController(IProductAppService productService, ICategoryAppService categoryService)
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
            //Get all products
            var productList = _productService.List(true);

            var vm = new ListShopModel()
            {
                BasketList = Mapper.Map<IList<Product>, IList<ShopModel>>(productList.Where(x => x.Basket).OrderBy(x => x.BasketOrder).ToList()),
                AvailableProductList = Mapper.Map<IList<Product>, IList<ShopModel>>(productList.Where(x => !x.Basket).OrderBy(x => x.Name).ToList()),
            };

            return View(vm);
        }

        #endregion Index

        #region Post

        /// <summary>
        /// Put the product in the basket
        /// </summary>
        /// <param name="productId">Product Identifier</param>
        /// <param name="basket">It's in the basket or not</param>
        /// <param name="categoryId">Identifier Category</param>
        /// <returns>Result of Operation</returns>
        [HttpPost]
        public JsonResult PutBasket(long productId, bool basket, long categoryId)
        {
            try
            {
                if (productId != 0)
                {
                    //Update Product
                    _productService.PutBasket(productId, basket, categoryId);
                }

                return Json(new { success = true, view = Index() }, JsonRequestBehavior.AllowGet);
            }
            catch (CustomException ex)
            {
                return Json(new { success = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = Messages.GeneralError }, JsonRequestBehavior.AllowGet);
            }
        }

        /// <summary>
        /// Update the order the itens in the basket
        /// </summary>
        /// <param name="ids">Array of Products Ids</param>
        /// <returns>Result of Operation</returns>
        [HttpPost]
        public JsonResult SortBasket(long[] ids)
        {
            try
            {
                if (ids.Count() > 0)
                {
                    //Update Product
                    _productService.SortBasket(ids);
                }

                return Json(new { success = true }, JsonRequestBehavior.AllowGet);
            }
            catch (CustomException ex)
            {
                return Json(new { success = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = Messages.GeneralError }, JsonRequestBehavior.AllowGet);
            }
        }

        #endregion Post
    }
}