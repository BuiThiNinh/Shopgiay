using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
namespace BLL
{
    public class BLL_TKBH
    {
        DAL_TKBH tkbh = new DAL_TKBH();
        public List<HOADONBAN> loadhd()
        {
            return tkbh.loaddlhoadon();
        }
        public List<CHITIETHOADONBAN> loadcthoadon(string ma)
        {
            return tkbh.loadCTHDB(ma);
        }
        public List<HOADONBAN> loadhdcodh(DateTime ngay)
        {
            return tkbh.loadtkbanhang(ngay);
        }

        public List<HOADONBAN> Loadhoadon_nv(string nv)
        {
            return tkbh.loadhd_nv(nv);
        }
        public List<HOADONBAN> loadnv_ngay(string nv, DateTime ngay)
        {
            return tkbh.loadnv_ngay(nv, ngay);
        }
    }
}
