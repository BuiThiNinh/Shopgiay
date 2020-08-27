using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
   public class DAL_BBSUCO
    {
        DataClasses1DataContext da = new DataClasses1DataContext();
        public List<BIENBANSUCO> loadBBSC()
        {
            return da.BIENBANSUCOs.Select(t => t).ToList<BIENBANSUCO>();
        }
        public List<GhepBang_SuCo> loadbangBaoHanh()
        {
            var bbsc = from b in da.BIENBANSUCOs
                       from nv in da.NHANVIENs
                       from s in da.SANPHAMs
                       from ct in da.CHITIETHOADONBANs
                       where b.MANV == b.MANV && s.MASP == ct.MASP && nv.MANV == b.MANV
                       select new
                       {
                           b.MABB,
                           b.MANV,
                           nv.TENNV,
                           b.GHICHU,
                           b.NGAYLAPBB,
                           s.TENSP,
                          
                       };
            var kq = bbsc.ToList().ConvertAll(t => new GhepBang_SuCo()
            {
                MABB1 = t.MABB,
                MANV1 = t.MANV,
                TENNV1 = t.TENNV,
                GHICHU1 = t.GHICHU,
                NGAYLAP1 = Convert.ToDateTime(t.NGAYLAPBB),
                TENSP1 = t.TENSP,
               
            });
            return kq.ToList<GhepBang_SuCo>();
        }

        public bool ktkcSUCo(string mabb)
        {
            var kt = (from b in da.BIENBANSUCOs
                      where b.MABB == mabb
                      select b).Count();
            if (kt > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool ThemBBSC(BIENBANSUCO bb)
        {
            try
            {

                da.BIENBANSUCOs.InsertOnSubmit(bb);
                da.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool xoaBBSC(BIENBANSUCO bb)
        {
            try
            {
                BIENBANSUCO mh = da.BIENBANSUCOs.Where(t => t.MABB == bb.MABB.ToString()).FirstOrDefault();
                da.BIENBANSUCOs.DeleteOnSubmit(mh);
                da.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool suaBB(BIENBANSUCO bb)
        {
            try
            {
                BIENBANSUCO mh = da.BIENBANSUCOs.Where(t => t.MABB == bb.MABB.ToString()).FirstOrDefault();
                mh.GHICHU = bb.GHICHU;
               
                da.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public string Laytennv(string manv)
        {
            var layten = (from nv in da.NHANVIENs
                          where nv.MANV == manv
                          select nv.TENNV).FirstOrDefault();
            return layten.ToString();
        }
        public List<CHITIETHOADONBAN> loadcthd()
        {
            return da.CHITIETHOADONBANs.Select(t => t).ToList<CHITIETHOADONBAN>();
        }
        public string laytensp(string ma)
        {
            var lt = (from ct in da.CHITIETHOADONBANs
                      from sp in da.SANPHAMs
                      where ct.MASP == sp.MASP && ct.MACTHDB == ma
                      select sp.TENSP).FirstOrDefault();
            return lt.ToString();
        }
    }
}
