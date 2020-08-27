using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_TKBH
    {
        DataClasses1DataContext da = new DataClasses1DataContext();
        public List<HOADONBAN> loaddlhoadon()
        {
            return da.HOADONBANs.Select(t => t).ToList<HOADONBAN>();

        }
        public List<CHITIETHOADONBAN> loadCTHDB(string mahd)
        {
            var ct = (from cthd in da.CHITIETHOADONBANs
                      where cthd.MAHD == mahd
                      select cthd).ToList<CHITIETHOADONBAN>();
            return ct.ToList();
        }

        public List<HOADONBAN> loadtkbanhang(DateTime ngay)
        {
            var ct = (from cthd in da.HOADONBANs
                      where cthd.NGAYLAP == ngay
                      select cthd).ToList<HOADONBAN>();
            return ct.ToList();
        }
        public List<HOADONBAN> loadhd_nv(string manv)
        {
            var ct = (from cthd in da.HOADONBANs
                      where cthd.MANV == manv
                      select cthd).ToList<HOADONBAN>();
            return ct.ToList();
        }
        public List<HOADONBAN> loadnv_ngay(string manv, DateTime ngay)
        {
            var ct = (from cthd in da.HOADONBANs
                      where cthd.MANV == manv && cthd.NGAYLAP == ngay
                      select cthd).ToList<HOADONBAN>();
            return ct.ToList();
        }

    }
}
