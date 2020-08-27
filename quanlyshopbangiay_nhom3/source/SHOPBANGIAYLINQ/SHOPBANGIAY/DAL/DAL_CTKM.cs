using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_CTKM
    {
        DataClasses1DataContext da = new DataClasses1DataContext();
        public List<ghepbangctkm_sanpham> loadctkm_sanpham()
        {
            var ctkm = from k in da.CT_KHUYENMAIs
                       from l in da.SANPHAMs
                       where k.MASP == l.MASP
                       select new
                       {
                           k.MAKM,
                           k.MASP,
                           l.TENSP,
                           k.NBD,
                           k.NKT
                       };
            var kq = ctkm.ToList().ConvertAll(t => new ghepbangctkm_sanpham()
            {
                MAKM1 = t.MAKM,
                MASP1 = t.MASP,
                TENSP1 = t.TENSP,
                NBD1 = t.NBD,
                NKT1 = Convert.ToDateTime(t.NKT)
            });
            return kq.ToList<ghepbangctkm_sanpham>();
        }
        public List<ghepbangctkm_sanpham> loadctkm_sanpham_msp(string masp)
        {
            var ctkm = from k in da.CT_KHUYENMAIs
                       from l in da.SANPHAMs
                       where k.MASP == masp && k.MASP==l.MASP
                       select new
                       {
                           k.MAKM,
                           k.MASP,
                           l.TENSP,
                           k.NBD,
                           k.NKT
                       };
            var kq = ctkm.ToList().ConvertAll(t => new ghepbangctkm_sanpham()
            {
                MAKM1 = t.MAKM,
                MASP1 = t.MASP,
                TENSP1 = t.TENSP,
                NBD1 = t.NBD,
                NKT1 = Convert.ToDateTime(t.NKT)
            });
            return kq.ToList<ghepbangctkm_sanpham>();
        }
        public List<ghepbangctkm_sanpham> loadctkm_sanpham_mkm(string makm)
        {
            var ctkm = from k in da.CT_KHUYENMAIs
                       from l in da.SANPHAMs
                       where k.MAKM == makm && k.MASP == l.MASP
                       select new
                       {
                           k.MAKM,
                           k.MASP,
                           l.TENSP,
                           k.NBD,
                           k.NKT
                       };
            var kq = ctkm.ToList().ConvertAll(t => new ghepbangctkm_sanpham()
            {
                MAKM1 = t.MAKM,
                MASP1 = t.MASP,
                TENSP1 = t.TENSP,
                NBD1 = t.NBD,
                NKT1 = Convert.ToDateTime(t.NKT)
            });
            return kq.ToList<ghepbangctkm_sanpham>();
        }
        public bool ktkc(CT_KHUYENMAI pmh)
        {
            int r = da.CT_KHUYENMAIs.Count(t => t.MAKM == pmh.MAKM.ToString() && t.MASP == pmh.MASP.ToString() && t.NBD == Convert.ToDateTime(pmh.NBD.ToString()));
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
        public bool them(CT_KHUYENMAI pmh)
        {
            try
            {
                da.CT_KHUYENMAIs.InsertOnSubmit(pmh);
                da.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }


        public bool sua(CT_KHUYENMAI pmh)
        {
            try
            {
                CT_KHUYENMAI thanhvien = da.CT_KHUYENMAIs.Where(t => t.MAKM == pmh.MAKM.ToString() && t.MASP == pmh.MASP.ToString() && t.NBD == Convert.ToDateTime(pmh.NBD.ToString())).FirstOrDefault();
                thanhvien.MASP = pmh.MASP;
                thanhvien.NBD = pmh.NBD;
                thanhvien.NKT = pmh.NKT;
                da.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool xoa(CT_KHUYENMAI pmh)
        {
            try
            {
                CT_KHUYENMAI mh = da.CT_KHUYENMAIs.Where(t => t.MAKM == pmh.MAKM.ToString() && t.MASP==pmh.MASP.ToString() && t.NBD==Convert.ToDateTime(pmh.NBD.ToString())).FirstOrDefault();
                da.CT_KHUYENMAIs.DeleteOnSubmit(mh);
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
