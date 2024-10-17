using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SV21T1020533.DataLayers
{
    /// <summary>
    /// Đĩnh nghĩa các phép xly dữ liêu chung
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface ICommonDAL<T> where T : class
    {
        /// <summary>
        /// Tkiem lấy dsach dưới dạng phân trang
        /// </summary>
        /// <param name="page"> trang cần hiển thị </param>
        /// <param name="pageSize">số dòng hiện thị trên mỗi trang(= 0 if ko phân trang)</param>
        /// <param name="searchValue">Chuỗi cần tìm (chuỗi rỗng nếu lấy all data)</param>
        /// <returns></returns>
        List<T> List(int page = 1, int pageSize = 0, string searchValue = "");
        /// <summary>
        /// đếm số dòng dữ liệu tìm được
        /// </summary>
        /// <param name="searchValue"></param>
        /// <returns></returns>
        int Count(String searchValue = "");
        /// <summary>
        /// Bổ sung dữ liệu vào csdl, hàm trả về id của dữ liệu được bổ sung
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        int Add(T data);
        /// <summary>
        /// cập nhật dlieu
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        bool Update(T data);
        /// <summary>
        /// Xóa dlieu dựa vào id
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        bool Delete(int id);
        /// <summary>
        /// lấy 1 dòng dlieu
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        T? Get(int id);
        /// <summary>
        /// kiểm tra 1 dòng ldieu có khóa là id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool InUsed(int id);
    }
}
