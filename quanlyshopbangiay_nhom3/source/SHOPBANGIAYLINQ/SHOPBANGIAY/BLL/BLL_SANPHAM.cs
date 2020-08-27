using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class BLL_SANPHAM
    {
        DAL_SP sp = new DAL_SP();
        public List<SANPHAM> loadbang_sanpham()
        {
            return sp.loadbangsanpham();
        }

        public List<SANPHAM> loadbang_sanpham_masp(String maloai)
        {
            return sp.loadbangsanpham_masp(maloai);
        }
        public List<bangghepsp_loaigiay_kho_sizegiay> loaddlsanpham()
        {
            return sp.loadKHo();
        }

        public bool ktkc_sp(SANPHAM n)
        {
            return sp.ktkc(n);
        }
        public bool themsp(SANPHAM n)
        {
            return sp.them(n);
        }

        public bool suasp(SANPHAM n)
        {
            return sp.sua(n);
        }

        public bool xoasp(SANPHAM n)
        {
            return sp.xoa(n);
        }
    }
}
