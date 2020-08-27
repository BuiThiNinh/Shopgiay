using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
   public class DAL_TKNHAPHANG
    {
        DataClasses1DataContext da = new DataClasses1DataContext();
        public List<PHIEUNHAP> loadpn()
        {
            return da.PHIEUNHAPs.Select(t => t).ToList<PHIEUNHAP>();
        }
        public List<PHIEUNHAP> loadtnhaphang(DateTime ngaybd, DateTime ngaykt)
        {
            var ct = (from cthd in da.PHIEUNHAPs
                      where cthd.NGAYNHAP >= ngaybd && cthd.NGAYNHAP <= ngaykt
                      select cthd).ToList<PHIEUNHAP>();
            return ct.ToList();
        }
        public List<PHIEUNHAP> loadnh_nv(string manv)
        {
            var ct = (from cthd in da.PHIEUNHAPs
                      where cthd.MANV == manv
                      select cthd).ToList<PHIEUNHAP>();
            return ct.ToList();
        }
        public List<PHIEUNHAP> loadnv_ngay(string manv, DateTime ngay)
        {
            var ct = (from cthd in da.PHIEUNHAPs
                      where cthd.MANV == manv && cthd.NGAYNHAP == ngay
                      select cthd).ToList<PHIEUNHAP>();
            return ct.ToList();
        }
    }
}
