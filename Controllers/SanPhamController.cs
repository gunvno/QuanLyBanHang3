using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuanLyBanHang2.Models;

namespace QuanLyBanHang2.Controllers
{
    public class SanPhamController : Controller
    {
        DatabaseSanPhamDataContext _context = new DatabaseSanPhamDataContext("Data Source=DESKTOP-KSC3C39\\SQLEXPRESS;Initial Catalog=QuanLyBanHang;Integrated Security=True;TrustServerCertificate=True");
        // GET: SanPham
        public ActionResult Index()
        {
            var a = _context.SanPhams.ToList();
            return View(a);
        }
        public ActionResult Add()
        {
            return View();
        }
        public ActionResult Create(FormCollection form)
        {
            string MaSanPham = form["MaSanPham"];
            string TenSanPham = form["TenSanPham"];
            string DonViTinh = form["DonViTinh"];
            //doi kieu du lieu sang int 
            int ma = Convert.ToInt32(MaSanPham);
            
            SanPham newObj = new SanPham();
            newObj.MaSanPham = ma;
            newObj.TenSanPham = TenSanPham;
            newObj.DonViTinh = DonViTinh;

            _context.SanPhams.InsertOnSubmit(newObj);
            _context.SubmitChanges();

            var a = _context.SanPhams.ToList();
            return View("Index", a);

        }
        public ActionResult Edit()
        {
            string ma = Request.QueryString["id"];
            int MaSanPham = Convert.ToInt32(ma);

            SanPham editObj = _context.SanPhams.Where(o => o.MaSanPham == MaSanPham).FirstOrDefault();
            if (editObj != null)
            {
                return View(editObj);
            }
            else
            {
                return View(HttpNotFound());
            }

        }
        public ActionResult PostEdit(FormCollection form)
        {
            int MaSanPham = Convert.ToInt32(form["MaSanPham"]);
            string TenSanPham = form["TenSanPham"];
            string DonViTinh = form["DonViTinh"];

            SanPham editObj1 = _context.SanPhams.FirstOrDefault(p => p.MaSanPham == MaSanPham);
            if (editObj1 != null)
            {
                editObj1.MaSanPham = MaSanPham;
                editObj1.TenSanPham = TenSanPham;   
                editObj1.DonViTinh = DonViTinh;

                _context.SubmitChanges();

                var x = _context.SanPhams.ToList();
                return View("Index", x);
            }
            else
            {
                return View("Error");
            }
        }
        public ActionResult Delete()
        {
            String ma = Request.QueryString["id"];
            int MaSanPham = Convert.ToInt32(ma);

            SanPham delObj = _context.SanPhams.Where(o => o.MaSanPham == MaSanPham).FirstOrDefault();
            _context.SanPhams.DeleteOnSubmit(delObj);
            _context.SubmitChanges();

            var x = _context.SanPhams.ToList();
            return View("Index", x);    
        }
    }
}