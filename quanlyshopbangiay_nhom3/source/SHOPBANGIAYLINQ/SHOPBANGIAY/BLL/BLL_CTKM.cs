using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class BLL_CTKM
    {
        DAL_CTKM ctkm = new DAL_CTKM();
        public List<ghepbangctkm_sanpham> loadbang_ct_sp()
        {
            return ctkm.loadctkm_sanpham();
        }
        public List<ghepbangctkm_sanpham> loadbang_ct_sp_masp(string MASP)
        {
            return ctkm.loadctkm_sanpham_msp(MASP);
        }
        public List<ghepbangctkm_sanpham> loadbang_ct_sp_makm(string MAkm)
        {
            return ctkm.loadctkm_sanpham_mkm(MAkm);
        }
        public bool ktkc_ctkm(CT_KHUYENMAI n)
        {
            return ctkm.ktkc(n);
        }
        public bool themctkm(CT_KHUYENMAI n)
        {
            return ctkm.them(n);
        }

        public bool suactkm(CT_KHUYENMAI n)
        {
            return ctkm.sua(n);
        }

        public bool xoactkm(CT_KHUYENMAI n)
        {
            return ctkm.xoa(n);
        }
    }
}
