using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuanLyBanHang2.Models;

namespace QuanLyBanHang2.Controllers
{
    public class DanhMucController : Controller
    {
        DatabaseSanPhamDataContext _context = new DatabaseSanPhamDataContext("Data Source=DESKTOP-KSC3C39\\SQLEXPRESS;Initial Catalog=QuanLyBanHang;Integrated Security=True;TrustServerCertificate=True");
        // GET: DanhMuc
        public ActionResult Index()
        {   
            var x = _context.tbl_DanhMucs.ToList();
            return View(x);
        }

        [HttpPost]
        public ActionResult GetListDanhMuc()
        {
            
            List < tbl_DanhMuc > a = _context.tbl_DanhMucs.ToList();
            return Json(new
            {
                data = a,
                hoten = "Ta Van Long",
                sdt = "0386404269"
            }, JsonRequestBehavior.AllowGet) ;
            
        }

    }
}