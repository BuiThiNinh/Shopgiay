using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_KHUYENMAI
    {
        DataClasses1DataContext data = new DataClasses1DataContext();
        public List<KHUYENMAI> laymakm(String masp)
        {
            var dulieu = (from s in data.KHUYENMAIs 
                          from k in data.CT_KHUYENMAIs
                          where k.MASP == masp && k.MAKM==s.MAKM && s.APDUNG==true select s);
            return dulieu.ToList<KHUYENMAI>();
        }
        public List<KHUYENMAI> loaddlkm()
        {
            var dulieu = (from s in data.KHUYENMAIs
                          select s);
            return dulieu.ToList<KHUYENMAI>();
        }
        public List<ghepbangkm_ctkm> loadbangkm_ctkm_msp(String masp)
        {
            var dulieu = (from s in data.KHUYENMAIs
                          from k in data.CT_KHUYENMAIs
                          where k.MASP == masp && k.MAKM == s.MAKM && s.APDUNG == true
                          select new
                          {
                              s.MAKM,
                              s.TENKM,
                              k.MASP,
                              s.MUCGIAM,
                              k.NBD,
                              k.NKT,
                              s.APDUNG
                          });
            var kq = dulieu.ToList().ConvertAll(t => new ghepbangkm_ctkm()
            {
                MAKM1 = t.MAKM,
                TENKM1 = t.TENKM,
                MASP1 = t.MASP,
                MUCGIAM1 = Convert.ToDouble(t.MUCGIAM),
                NBD1 = t.NBD,
                NKT1 = Convert.ToDateTime(t.NKT),
                APDUNG1 = Convert.ToBoolean(t.APDUNG)
            });
            return kq.ToList<ghepbangkm_ctkm>();
        }
        public Double laymucgiam(String makm)
        {
            var dulieu = (from s in data.KHUYENMAIs
                          where s.MAKM==makm && s.APDUNG == true
                          select s.MUCGIAM).FirstOrDefault();
            return Convert.ToDouble(dulieu.ToString());
        }
        public bool ktkc(KHUYENMAI ma)
        {
            int r = data.KHUYENMAIs.Count(t => t.MAKM == ma.MAKM.ToString());
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
        public bool them(KHUYENMAI pmh)
        {
            try
            {
                data.KHUYENMAIs.InsertOnSubmit(pmh);
                data.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }


        public bool sua(KHUYENMAI pmh)
        {
            try
            {
                KHUYENMAI thanhvien = data.KHUYENMAIs.Where(t => t.MAKM == pmh.MAKM.ToString()).FirstOrDefault();
                thanhvien.TENKM = pmh.TENKM;
                thanhvien.MUCGIAM = pmh.MUCGIAM;
                thanhvien.APDUNG = pmh.APDUNG;
                data.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool xoa(KHUYENMAI pmh)
        {
            try
            {
                KHUYENMAI mh = data.KHUYENMAIs.Where(t => t.MAKM == pmh.MAKM.ToString()).FirstOrDefault();
                data.KHUYENMAIs.DeleteOnSubmit(mh);
                data.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
