using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_CTPN
    {
        DataClasses1DataContext da = new DataClasses1DataContext();
        public List<bangghepctpn> loadctpn_sanpham()
        {
            var kho = from k in da.CHITIETPHIEUNHAPs
                      from sp in da.SANPHAMs
                      where k.MASP == sp.MASP
                      select new
                      {
                         k.MACTPN,
                         k.MAPN,
                         k.MASP,
                         sp.TENSP,
                         k.SOLUONGSP,
                         k.GIATIEN
                      };
            var kq = kho.ToList().ConvertAll(t => new bangghepctpn()
            {
               MACTPN1=t.MACTPN,
               MAPN1=t.MAPN,
               MSP1=t.MASP,
               TENSP1=t.TENSP,
               sl1=Convert.ToInt32(t.SOLUONGSP),
               dg1 = Convert.ToDouble(t.GIATIEN)
            });
            return kq.ToList<bangghepctpn>();
        }
        public List<bangghepctpn> loadctpn_sanpham_mpn(String mapn)
        {
            var kho = from k in da.CHITIETPHIEUNHAPs
                      from sp in da.SANPHAMs
                      where k.MASP == sp.MASP && k.MAPN==mapn
                      select new
                      {
                          k.MACTPN,
                          k.MAPN,
                          k.MASP,
                          sp.TENSP,
                          k.SOLUONGSP,
                          k.GIATIEN
                      };
            var kq = kho.ToList().ConvertAll(t => new bangghepctpn()
            {
                MACTPN1 = t.MACTPN,
                MAPN1 = t.MAPN,
                MSP1 = t.MASP,
                TENSP1 = t.TENSP,
                sl1 = Convert.ToInt32(t.SOLUONGSP),
                dg1 = Convert.ToDouble(t.GIATIEN)
            });
            return kq.ToList<bangghepctpn>();
        }
        public bool ktkc(CHITIETPHIEUNHAP ma)
        {
            int r = da.CHITIETPHIEUNHAPs.Count(t => t.MACTPN == ma.MACTPN.ToString());
            try
            {
                if (r == 0)
                {
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }
        public bool them(CHITIETPHIEUNHAP pmh)
        {
            try
            {
                da.CHITIETPHIEUNHAPs.InsertOnSubmit(pmh);
                da.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }


        public bool sua(CHITIETPHIEUNHAP pmh)
        {
            try
            {
                CHITIETPHIEUNHAP thanhvien = da.CHITIETPHIEUNHAPs.Where(t => t.MACTPN == pmh.MACTPN.ToString()).FirstOrDefault();
                thanhvien.MAPN = pmh.MAPN;
                thanhvien.MASP = pmh.MASP;
                thanhvien.SOLUONGSP = pmh.SOLUONGSP;
                thanhvien.GIATIEN = pmh.GIATIEN;
                da.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool xoa(CHITIETPHIEUNHAP pmh)
        {
            try
            {
                CHITIETPHIEUNHAP mh = da.CHITIETPHIEUNHAPs.Where(t => t.MACTPN == pmh.MACTPN.ToString()).FirstOrDefault();
                da.CHITIETPHIEUNHAPs.DeleteOnSubmit(mh);
                da.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
