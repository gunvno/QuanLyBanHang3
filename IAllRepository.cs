using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyBanHang2
{
    public interface IAllRepository<T>
    {
        List<T> GetAll();
        
    }
}