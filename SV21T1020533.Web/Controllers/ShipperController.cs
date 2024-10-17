using Microsoft.AspNetCore.Mvc;
using SV21T1020533.BusinessLayers;
using SV21T1020533.DomainModels;
using System.Buffers;

namespace SV21T1020533.Web.Controllers
{
    public class ShipperController : Controller
    {
        public int PAGE_SIZE = 10;
        public IActionResult Index(int page = 1, string searchValue = "")
        {
            int rowCount;
            var data = CommonDataService.ListOfShippers(out rowCount, page, PAGE_SIZE, searchValue ?? "");
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
            ViewBag.Title = "Bổ sung người giao hàng";
            var data = new Shipper()
            {
                ShipperID = 0
                
            };
            return View("Edit", data);
        }
        public IActionResult Edit(int id = 0)
        {
            ViewBag.Title = "Cập nhật thông tin người giao hàng";
            var data = CommonDataService.GetShipper(id);
            if (data == null)
                return RedirectToAction("Index");
            return View(data);
        }
        public IActionResult Delete(int id = 0)
        {
            if (Request.Method == "POST")
            {
                bool a = CommonDataService.DeleteShipper(id);
                return RedirectToAction("Index");
            }
            var data = CommonDataService.GetShipper(id);
            if (data == null)
                return RedirectToAction("Index");

            return View(data);
            
        }
        [HttpPost]
        public IActionResult Save(Shipper data)
        {
            //TODO: Kiem tra du lieu dau vao dung hay khong?
            if (data.ShipperID == 0)
            {
                int id = CommonDataService.AddShipper(data);
            }
            else
            {
                bool result = CommonDataService.UpdateShipper(data);
            }
            return RedirectToAction("Index");
        }
    }
}
