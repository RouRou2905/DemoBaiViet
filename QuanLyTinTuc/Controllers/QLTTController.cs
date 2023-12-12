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

    public class QLTTController : Controller
    {
        public DataTableDataContext db = new DataTableDataContext();

        // GET: QLTT
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult ThemTinTuc()
        {
            return View();
        }

        public ActionResult SuaTinTuc()
        {
            return View();
        }
        


        public string Add()
        {
            //ví dụ về linq to sql
            //var qr = db.tbl_SVs; //select * from tbl_SV
            //var qr1 = db.tbl_SVs.Where(o => o.MSSV == "1234"); //select * from tbl_SV where mssv == "1234"

            string danhmuc = Request["txt_category"];
            string tieude = Request["txt_title"];
            string mota = Request["txt_key"];

            string thoigian = DateTime.Now.ToString();
            string noidung = Request["summernote"];

            
            //string uploadPath = Server.MapPath("~/Content/Image/" + fileName );
            //var uploadPath = Server.MapPath("~/Content/picture/");
            //var filePath = Path.Combine(uploadPath, fileName);


            HttpPostedFileBase fileImage = Request.Files["txt_image"];
            var fileName = fileImage.FileName;
            //var filePath = Server.MapPath("~/Views/QLTT/picture/" + fileName);
            //var filePath = Path.Combine(uploadPath, fileName);
            var filePath = Server.MapPath("~/Content/dist/picture/" + fileName);
            //var filePath = 
            fileImage.SaveAs(filePath);


            if (!string.IsNullOrEmpty(tieude) && !string.IsNullOrEmpty(noidung) && !string.IsNullOrEmpty(mota) && !string.IsNullOrEmpty(danhmuc))
            {

                try
                {
                    //trường hợp muốn insert
                    post tt = new post();
                    tt.title = tieude;
                    tt.content = noidung;
                    tt.script = mota;
                    tt.category = danhmuc;
                    tt.imgName = fileName;
                    tt.imgFile = filePath;
                    tt.DateCreate = thoigian;

                    db.posts.InsertOnSubmit(tt);
                    db.SubmitChanges();

                    return "Thêm mới tin tức thành công";
                }
                catch (Exception ex)
                {
                    return "Thêm mới tin tức thất bại. Chi tiết lỗi: " + ex.Message;
                }
            }
            else
            {
                return "Mày chơi tao không được đâu";
            }
        }
    
        public string get_TT_Info()
    {

            string matin = Request["matin"];
            //validate input
            if (!string.IsNullOrEmpty(matin))
            {
                try
                {
                    int maBV  = int.Parse(matin);
                    //trường hợp lấy được mssv từ trang suaSV
                    var qr = db.posts.Where(o => o.id == maBV);
                    if (qr.Any())
                    {
                        //trường hợp có dữ liệu trả về - tìm thấy sv có mssv theo yêu cầu
                        var tt_obj = qr.SingleOrDefault();

                        return JsonConvert.SerializeObject(tt_obj);
                    }
                    else
                    {
                        return "Không tìm thấy tin tức có mã tin = " + maBV;
                    }

                }
                catch (Exception ex)
                {
                    return "Lấy thông tin tin tức thất bại. Chi tiết lỗi: " + ex.Message;
                }
                //ok
                //return "MSSV: " + mssv + "; Họ tên: " + hoten + "; Mật khẩu: " + mk;

            }
            else
            {
                return "Vui lòng chọn tin tức để chỉnh sửa";
            }
        }

        public string get_TT_Edit()
    {
            
            string matin = Request["number"];
           
            //string maBV = Request["id"];

        //validate input
        if (!string.IsNullOrEmpty(matin))
        {
            try
            {
                    int maBV = int.Parse(matin);
                    //trường hợp muốn update
                    var qrs = db.posts.Where(o => o.id == maBV);
                if (qrs.Any())
                {
                    //có trả về bản ghi.
                    post tt = qrs.SingleOrDefault();

                    return JsonConvert.SerializeObject(tt);
                }
                else
                {
                    return "KHÔNG tìm thấy tin tức có mã = " + maBV;
                }
            }
            catch (Exception ex)
            {
                return "Cập nhật thông tin tin tức thất bại. Chi tiết lỗi: " + ex.Message;
            }
        }
        else
        {
            return "Mày chơi tao không được đâu";
        }
    }

        public string Edit()
    {
            //ví dụ về linq to sql
            //var qr = db.tbl_SVs; //select * from tbl_SV
            //var qr1 = db.tbl_SVs.Where(o => o.MSSV == "1234"); //select * from tbl_SV where mssv == "1234"

            //post baiviet = new post();
            //int Ma = baiviet.id;
            //string ID = Ma.ToString();
            string matin = Request["txt_id"];


            string danhmuc = Request["txt_category"];
            string tieude = Request["txt_title"];
            string mota = Request["txt_key"];


            string noidung = Request["note-editable"];

            HttpPostedFileBase fileImage = Request.Files["txt_image"];
            var fileName = fileImage.FileName;
            //var uploadPath = Server.MapPath("~/QLTT/picture/");
            //var filePath = Path.Combine(uploadPath, fileName);

            //HttpPostedFileBase fileImage = Request.Files["txt_image"];
            //string fileName = fileImage.FileName;
            ////string uploadPath = Server.MapPath("~/Content/Image/" + fileName );
            var filePath = Server.MapPath("~/Content/dist/picture/" + fileName);
            ////string uploadPath = Server.MapPath("~/Uploads/");
            ////string filePath = Path.Combine(uploadPath, fileName);
            fileImage.SaveAs(filePath);


            //string filePath = Request["txt_image"];

            //HttpPostedFileBase fileImage = Request.Files["txt_image"];
            //string fileName = fileImage.FileName;
            //string uploadPath = Server.MapPath("~/Content/Image/");
            ////string uploadPath = Server.MapPath("~/Uploads/");
            //string filePath = Path.Combine(uploadPath, fileName);

            //validate input
            if (!string.IsNullOrEmpty(matin) && !string.IsNullOrEmpty(tieude) && !string.IsNullOrEmpty(noidung) && !string.IsNullOrEmpty(mota) && !string.IsNullOrEmpty(danhmuc))
        {
            //if (id == mssv)
            //{
                 try
                    {
                    int maBV = int.Parse(matin);
                    //trường hợp muốn update
                    var qrs = db.posts.Where(o => o.id == maBV);
                        if (qrs.Any())
                        {
                            //có trả về bản ghi.
                            post tt = qrs.SingleOrDefault();
                            tt.title = tieude;
                            tt.content = noidung;
                            tt.script = mota;
                            tt.category = danhmuc;
                            tt.imgName = fileName;
                            tt.imgFile = filePath;
                            db.SubmitChanges();

                            return "Cập nhật thông tin tin tức thành công";
                        }
                        else
                        {
                            return "KHÔNG tìm thấy tin tức có mã = " + maBV;
                        }
                    }
                    catch (Exception ex)
                    {
                        return "Cập nhật thông tin tin tức thất bại. Chi tiết lỗi: " + ex.Message;
                    }
        }
        else
        {
            return "Mày chơi tao không được đâu";
        }
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

        public string Search_TT()
        {
            APIResult_ett<List<post>> rs = new APIResult_ett<List<post>>();
            try
            {
                string search_val = Request["search_val"];
                string search_type = Request["search_type"];

                if (!string.IsNullOrEmpty(search_val) && !string.IsNullOrEmpty(search_type))
                {
                    //truy vấn db để lấy toàn bộ dữ liệu về ds sinh viên
                    IQueryable<post> qr = null;

                    switch (search_type)
                    {
                        case "danhmuc":
                            qr = db.posts.Where(o => o.category == search_val && (o.isDelete == null || o.isDelete == 0));
                            break;
                        case "tieude":
                            qr = db.posts.Where(o => o.title.Contains(search_val) && (o.isDelete == null || o.isDelete == 0));
                            break;
                        case "mota":
                            qr = db.posts.Where(o => o.script.Contains(search_val) && (o.isDelete == null || o.isDelete == 0));
                            break;
                        default:
                            break;
                    }

                    if (qr.Any())
                    {
                        //có dữ liệu => chính là dssv
                        rs.ErrCode = EnumErrCode.Success;
                        rs.ErrDesc = "Tìm kiếm tin tức thành công";
                        rs.Data = qr.ToList();
                    }
                    else
                    {
                        //không có dữ liệu thỏa mãn
                        rs.ErrCode = EnumErrCode.Empty;
                        rs.ErrDesc = "Không tìm thấy tin tức thỏa mãn điều kiện tìm kiếm";
                        rs.Data = null;
                    }
                }
                else
                {
                    //get all
                    var qr = db.posts.Where(o => o.isDelete == null || o.isDelete == 0);
                    if (qr.Any())
                    {
                        //có dữ liệu => chính là dssv
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

                    //rs.ErrCode = EnumErrCode.InputEmpty;
                    //rs.ErrDesc = "Vui lòng nhập đầy đủ giá trị và tiêu chí cần tìm kiếm";
                    //rs.Data = null;
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
        public ActionResult DSTT()
        {
            return View();
        }

        public string Del_TT()
        {
            APIResult_ett<string> rs = new APIResult_ett<string>();
            
            try
            {

                //xử lý trường hợp xóa
                //lấy về mssv cần xóa
                string matin = Request["matin"];

                if (!string.IsNullOrEmpty(matin))
                {
                    //int.TryParse(matin, out int maBV);
                    //thực hiện xóa và nên xóa mềm
                    int maBV = int.Parse(matin);
                    var qr = db.posts.Where(o => o.id == maBV);
                    if (qr.Any())
                    {
                        //trường hợp có dữ liệu
                        post del_obj = qr.SingleOrDefault();

                        del_obj.isDelete = 1;
                        del_obj.DeleteTime = DateTime.Now.ToString();

                        db.SubmitChanges();

                        rs.ErrCode = EnumErrCode.Success;
                        rs.ErrDesc = "Xóa tin tức có mã = " + matin + " thành công";

                        rs.Data = del_obj.id.ToString();
                        rs.Data = del_obj.title;
                        rs.Data = del_obj.content;
                        rs.Data = del_obj.script;
                        rs.Data = del_obj.category;
                        rs.Data = del_obj.imgName;
                        rs.Data = del_obj.imgFile;
                        rs.Data = del_obj.DateCreate;
                    }
                    else
                    {
                        rs.ErrCode = EnumErrCode.NotExistent;
                        rs.ErrDesc = "Xóa tin tức có mã = " + matin + " thất bại do không tìm thấy";
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