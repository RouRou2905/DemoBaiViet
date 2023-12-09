using QuanLyTinTuc.Models;
using Microsoft.Ajax.Utilities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;

namespace QuanLyTinTuc.Controllers
{

    public class HomeController : Controller
    {
        public DataTableDataContext db = new DataTableDataContext();
        public ActionResult Index()
        {
            return View();
        }

        public string get_All()
        {
            APIResult_ett<List<post>> rs = new APIResult_ett<List<post>>();
            try
            {
                //truy vấn db để lấy toàn bộ dữ liệu về ds sinh viên
                var qr = db.posts.Where(o => o.isDelete == null || o.isDelete == 0);
                if (qr.Any())
                {
                    rs.ErrCode = EnumErrCode.Success;
                    rs.ErrDesc = "Lấy danh sách tin tức thành công";
                    rs.Data = qr.ToList();
                }
                else
                {
                    //không có dữ liệu thỏa mãn
                    rs.ErrCode = EnumErrCode.Empty;
                    rs.ErrDesc = "Danh sách tin tức rỗng";
                    rs.Data = null;
                }
            }
            catch (Exception ex)
            {
                rs.ErrCode = EnumErrCode.Error;
                rs.ErrDesc = "Có lỗi xảy ra trong quá trình lấy về danh sách tin tức. Chi tiết lỗi: " + ex.Message;
                rs.Data = null;
            }

            return JsonConvert.SerializeObject(rs);
        }

        public string Del_TT()
        {
            APIResult_ett<string> rs = new APIResult_ett<string>();

            try
            {

                //xử lý trường hợp xóa
                //lấy về mssv cần xóa
                string matin = Request["matin"];
                int maBV = int.Parse(matin);
                if (!string.IsNullOrEmpty(matin))
                {
                    //thực hiện xóa và nên xóa mềm
                    var qr = db.posts.Where(o => o.id == maBV);
                    if (qr.Any())
                    {
                        //trường hợp có dữ liệu
                        post del_obj = qr.SingleOrDefault();
                        del_obj.isDelete = 1;
                        del_obj.DeleteTime = DateTime.Now.ToString();

                        db.SubmitChanges();

                        rs.ErrCode = EnumErrCode.Success;
                        rs.ErrDesc = "Xóa SV có MSSV " + maBV + " thành công";
                        rs.Data = del_obj.title;
                    }
                    else
                    {
                        rs.ErrCode = EnumErrCode.NotExistent;
                        rs.ErrDesc = "Xóa tin tức có mã " + maBV + " thất bại do không tìm thấy";
                        rs.Data = null;

                    }
                }
                else
                {
                    rs.ErrCode = EnumErrCode.Empty;
                    rs.ErrDesc = "Vui lòng chọn tin cần xóa";
                    rs.Data = null;
                }
            }
            catch (Exception ex)
            {
                rs.ErrCode = EnumErrCode.Error;
                rs.ErrDesc = "Xóa tin tức thất bại. Chi tiết lỗi: " + ex.Message;
                rs.Data = null;
            }

            return JsonConvert.SerializeObject(rs);
        }
    }
}