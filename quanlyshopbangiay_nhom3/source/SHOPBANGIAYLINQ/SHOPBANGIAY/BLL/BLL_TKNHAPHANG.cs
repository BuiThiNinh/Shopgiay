using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
namespace BLL
{
   public class BLL_TKNHAPHANG
    {
        DAL_TKNHAPHANG nh = new DAL_TKNHAPHANG();
        public List<PHIEUNHAP> loadphieunhap()
        {
            return nh.loadpn();
        }
        public List<PHIEUNHAP> loadphieunhapNgay(DateTime ngaybd, DateTime ngaykt)
        {
            return nh.loadtnhaphang(ngaybd, ngaykt);
        }
        public List<PHIEUNHAP> loaddl_nv(string nv)
        {
            return nh.loadnh_nv(nv);
        }
        public List<PHIEUNHAP> loadnv_ngay(string nv, DateTime ngay)
        {
            return nh.loadnv_ngay(nv, ngay);
        }
    }
}
