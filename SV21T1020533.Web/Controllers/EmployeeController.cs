using Microsoft.AspNetCore.Mvc;
using SV21T1020533.BusinessLayers;
using SV21T1020533.DomainModels;

namespace SV21T1020533.Web.Controllers
{
    public class EmployeeController : Controller
    {
        public int PAGE_SIZE = 10;
        public IActionResult Index(int page = 1, string searchValue = "")
        {
            int rowCount;
            var data = CommonDataService.ListOfEmployees(out rowCount, page, PAGE_SIZE, searchValue ?? "");
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
            ViewBag.Title = "Bổ sung nhân viên";
            var data = new Employee()
            {
                EmployeeID = 0,
                IsWorking = false
            };
            return View("Edit", data);
        }
        public IActionResult Edit(int id = 0)
        {
            ViewBag.Title = "Cập nhật thông tin nhân viên";
            var data = CommonDataService.GetEmployee(id);
            if (data == null)
                return RedirectToAction("Index");
            return View(data);
        }
        public IActionResult Delete(int id = 0)
        {
            if (Request.Method == "POST")
            {
                bool a = CommonDataService.DeleteEmployee(id);
                return RedirectToAction("Index");
            }
            var data = CommonDataService.GetEmployee(id);
            if (data == null)
                return RedirectToAction("Index");

            return View(data);
        }
        [HttpPost]
        public IActionResult Save(Employee data)
        {
            //TODO: Kiem tra du lieu dau vao dung hay khong?
            if (data.EmployeeID == 0)
            {
                int id = CommonDataService.AddEmployee(data);
            }
            else
            {
                bool result = CommonDataService.UpdateEmployee(data);
            }
            return RedirectToAction("Index");
        }
    }
}
