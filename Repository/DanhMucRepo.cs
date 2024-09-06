using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuanLyBanHang2.Models;

namespace QuanLyBanHang2.Repository
{
    

    public class DanhMucRepo : IAllRepository<tbl_DanhMuc>
    {
        private readonly DatabaseSanPhamDataContext _context;
        public List<tbl_DanhMuc> GetAll()
        {
            return _context.tbl_DanhMucs.ToList();
        }
    }
}