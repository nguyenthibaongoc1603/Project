using Microsoft.AspNetCore.Mvc;
using SV21T1020533.BusinessLayers;
using SV21T1020533.DomainModels;

namespace SV21T1020533.Web.Controllers
{
    public class SupplierController : Controller
    {
        public const int PAGE_SIZE = 10;
        public IActionResult Index(int page = 1, string searchValue = "")
        {
            int rowCount;
            var data = CommonDataService.ListOfSuppliers(out rowCount, page, PAGE_SIZE, searchValue ?? "");
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
            ViewBag.Title = "Bổ sung nhà cung cấp";
            var data = new Supplier()
            {
                SupplierID = 0,
            };
            return View("Edit", data);
        }
        public IActionResult Edit(int id = 0)
        {
            ViewBag.Title = "Cập nhật thông tin nhà cung cấp";
            var data = CommonDataService.GetSupplier(id);
            if (data == null)
                return RedirectToAction("Index");
            return View(data);
        }
        public IActionResult Delete(int id = 0)
        {
            if (Request.Method == "POST")
            {
                bool a = CommonDataService.DeleteSupplier(id);
                return RedirectToAction("Index");
            }
            var data = CommonDataService.GetSupplier(id);
            if (data == null)
                return RedirectToAction("Index");

            return View(data);
        }
        [HttpPost]
        public IActionResult Save(Supplier data)
        {
            //TODO: Kiem tra du lieu dau vao dung hay khong?
            if (data.SupplierID == 0)
            {
                int id = CommonDataService.AddSupplier(data);
            }
            else
            {
                bool result = CommonDataService.UpdateSupplier(data);
            }
            return RedirectToAction("Index");
        }
    }
}
