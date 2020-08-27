using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class BLL_KHUYENMAI
    {
        DAL_KHUYENMAI dl = new DAL_KHUYENMAI();

        public List<KHUYENMAI> loadbang_km(string masp)
        {
            return dl.laymakm(masp);
        }
        public List<KHUYENMAI> loaddlkm()
        {
            return dl.loaddlkm();
        }
        public List<ghepbangkm_ctkm> loadbang_km_ctkm(string masp)
        {
            return dl.loadbangkm_ctkm_msp(masp);
        }
        public double loadbang_km1(string makm)
        {
            return dl.laymucgiam(makm);
        }
        public bool ktkc_km(KHUYENMAI n)
        {
            return dl.ktkc(n);
        }
        public bool themkm(KHUYENMAI n)
        {
            return dl.them(n);
        }

        public bool suakm(KHUYENMAI n)
        {
            return dl.sua(n);
        }

        public bool xoakm(KHUYENMAI n)
        {
            return dl.xoa(n);
        }
    }
}
