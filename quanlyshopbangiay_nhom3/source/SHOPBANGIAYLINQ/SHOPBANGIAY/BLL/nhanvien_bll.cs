using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class nhanvien_bll
    {
        dal_nhanvien nv = new dal_nhanvien();
        public List<NHANVIEN> loadnhanvien()
        {
            return nv.loadbangnhanvien();
        }
        public List<NHANVIEN> loadnhanvien_tk(NHANVIEN manv)
        {
            try
            {
                return nv.loadbangnhanvien_tk(manv);
            }
            catch
            {
                return null;
            }
        }
        public bool ktkc(NHANVIEN n)
        {
            return nv.ktkc(n);
        }
        public bool themnhanvien(NHANVIEN n)
        {
            return nv.them(n);
        }
        public bool xoanhanvien(NHANVIEN n)
        {
            return nv.xoa(n);
        }
        public bool suanhanvien(NHANVIEN n)
        {
            return nv.sua(n);
        }
    }
}
