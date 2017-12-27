using Application.Interfaces;
using Application.Models.Category;
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
    public class CategoriesController : Controller
    {
        #region Properties

        /// <summary>
        /// Service App Category
        /// </summary>
        private readonly ICategoryAppService _categoryService;

        #endregion Properties

        #region Constructor

        /// <summary>
        /// 
        /// </summary>
        /// <param name="service"></param>
        public CategoriesController(ICategoryAppService service)
        {
            _categoryService = service;
        }

        #endregion Constructor

        #region Index

        /// <summary>
        /// Load Main Page
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            var list = _categoryService.List().OrderByDescending(x => x.Id).ToList();
            
            var vm = Mapper.Map<IList<Category>, IList<ListGridCategoryModel>>(list);

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
            return View(new CreateCategoryModel());
        }

        /// <summary>
        /// Create a new category
        /// </summary>
        /// <param name="vm">ViewModel</param>
        /// <returns>Result of Operation</returns>
        [HttpPost]
        public ActionResult Create(CreateCategoryModel vm)
        {
            try
            {
                //Check data validation
                if (!ModelState.IsValid)
                {
                    this.AddToastMessage(Messages.InvalidValueField, ToastType.Error);
                    return View("Create", vm);
                }

                //Create Category
                _categoryService.Create(vm);

                //Successfully message
                this.AddToastMessage(string.Format(Messages.RecordSavedSuccessfully, "category"), ToastType.Success);

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
                var vm = Mapper.Map<Category, EditCategoryModel>(_categoryService.GetById(id));

                if(vm == null)
                    this.AddToastMessage(ValidationMessages.RecordNotFound, ToastType.Info);

                return View(vm);
            }
            catch (Exception ex)
            {
                this.AddToastMessage(Messages.GeneralError, ToastType.Error);
                return View("Edit", new EditCategoryModel());
            }
        }

        /// <summary>
        /// Edit a category
        /// </summary>
        /// <param name="vm"></param>
        /// <returns>Result of Operation</returns>
        [HttpPost]
        public ActionResult Edit(EditCategoryModel vm)
        {
            try
            {
                //Check data validation
                if (!ModelState.IsValid)
                {
                    this.AddToastMessage(Messages.InvalidValueField, ToastType.Error);
                    return View("Edit", vm);
                }

                //Update Category
                _categoryService.Update(vm);

                //Successfully message
                this.AddToastMessage(string.Format(Messages.RecordSavedSuccessfully, "category"), ToastType.Success);

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
        /// Delete Category
        /// </summary>
        /// <param name="id">Identifier of Entity</param>
        /// <returns></returns>
        [HttpDelete]
        public ActionResult Delete(long id)
        {
            try
            {
                //Delete
                _categoryService.Delete(id);

                //Successfully message
                this.AddToastMessage(string.Format(Messages.RecordDeletedSuccessfully, "category"), ToastType.Success);
            }
            catch (CustomException ex)
            {
                this.AddToastMessage(ex.Message, ToastType.Error);
            }
            catch (Exception ex)
            {
                this.AddToastMessage(Messages.GeneralError, ToastType.Error);
            }

            return RedirectToAction("Index");
        }

        #endregion Delete
    }
}