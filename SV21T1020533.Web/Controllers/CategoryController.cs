﻿using Microsoft.AspNetCore.Mvc;
using SV21T1020533.BusinessLayers;
using SV21T1020533.DomainModels;

namespace SV21T1020533.Web.Controllers
{
    public class CategoryController : Controller
    {
        public const int PAGE_SIZE = 5;
        public IActionResult Index(int page = 1, string searchValue ="")
        {
            int rowCount;
            var data = CommonDataService.ListOfCategories(out rowCount, page, PAGE_SIZE, searchValue ?? "");
            int pageCount = 1;
            pageCount = rowCount / PAGE_SIZE;
            if (rowCount % PAGE_SIZE > 0)
                pageCount += 1;

            ViewBag.Page = page;
            ViewBag.RowCount = rowCount;
            ViewBag.PageCount = pageCount;
            ViewBag.SearchValue = searchValue;
            ViewBag.SearchValue = searchValue;
            return View(data);
        }
        public IActionResult Create()
        {
            ViewBag.Title = "Bổ sung loại hàng";
            var data = new Category()
            {
                CategoryID = 0
            };
            return View("Edit", data);
        }
        public IActionResult Edit(int id = 0)
        {
            ViewBag.Title = "Cập nhật thông tin loại hàng";
            var data = CommonDataService.GetCategory(id);
            if (data == null)
                return RedirectToAction("Index");
            return View(data);
        }
        public IActionResult Delete(int id = 0)
        {
            if (Request.Method == "POST")
            {
                bool a = CommonDataService.DeleteCategory(id);
                return RedirectToAction("Index");
            }
            var data = CommonDataService.GetCategory(id);
            if (data == null)
                return RedirectToAction("Index");
            return View(data);
        }
        [HttpPost]
        public IActionResult Save(Category data)
        {
            //TODO: Kiem tra du lieu dau vao dung hay khong?
            if (data.CategoryID == 0)
            {
                int id = CommonDataService.AddCategory(data);
            }
            else
            {
                bool result = CommonDataService.UpdateCategory(data);
            }
            return RedirectToAction("Index");
        }
    }
}
