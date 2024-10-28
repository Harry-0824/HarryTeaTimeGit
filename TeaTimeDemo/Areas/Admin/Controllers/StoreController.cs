﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using TeaTimeDemo.DataAccess.Data;
using TeaTimeDemo.DataAccess.Repository.IRepository;
using TeaTimeDemo.Models;
using TeaTimeDemo.Models.ViewModels;
using TeaTimeDemo.Utility;

namespace TeaTimeDemo.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin + ", " + SD.Role_Employee + ", " + SD.Role_Manager)]
    public class StoreController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public StoreController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            List<Store> objStoreList = _unitOfWork.Store.GetAll().ToList();
            return View(objStoreList);
        }
        public IActionResult Upsert(int? id)
        {
            if(id == null || id == 0)
            {
                //執行新增
                return View(new Store());
            }
            else
            {
                //執行編輯
                Store storeObj = _unitOfWork.Store.Get(u => u.Id == id);
                return View();
            }
        }
        [HttpPost]
        public IActionResult Upsert(Store storeObj)
        {
            if (ModelState.IsValid)
            {
                if (storeObj.Id == 0)
                {
                    _unitOfWork.Store.Add(storeObj);
                }
                else
                {
                    _unitOfWork.Store.Update(storeObj);
                }
                _unitOfWork.Save();
                TempData["success"] = "店铺新增成功";
                return RedirectToAction("Index");
            }
            else
            {
                return View(storeObj);
            }
        }
        #region API CALLS
        [HttpGet]
        public IActionResult GetAll()
        {
            List<Store> objStoreList = _unitOfWork.Store.GetAll().ToList();
            return Json(new { data = objStoreList });
        }
        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            var storeToBeDeleted = _unitOfWork.Product.Get(u => u.Id == id);
            if (storeToBeDeleted == null)
            {
                return Json(new { success = false, message = "删除失败" });
            }
            _unitOfWork.Product.Remove(storeToBeDeleted);
            _unitOfWork.Save();
            return Json(new { success = true, message = "删除成功" });
        }
        #endregion

    }
}
