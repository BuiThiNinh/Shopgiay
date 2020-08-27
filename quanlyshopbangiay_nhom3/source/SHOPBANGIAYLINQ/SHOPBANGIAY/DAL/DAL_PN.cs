using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_PN
    {
        DataClasses1DataContext data = new DataClasses1DataContext();
        public List<PHIEUNHAP> loadbangPN()
        {
            var dulieu = (from s in data.PHIEUNHAPs select s);
            return dulieu.ToList<PHIEUNHAP>();
        }

        public bool ktkc(PHIEUNHAP ma)
        {
            int r = data.PHIEUNHAPs.Count(t => t.MAPN == ma.MAPN.ToString());
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
        public bool them(PHIEUNHAP pmh)
        {
            try
            {
                data.PHIEUNHAPs.InsertOnSubmit(pmh);
                data.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }


        public bool sua(PHIEUNHAP pmh)
        {
            try
            {
                PHIEUNHAP thanhvien = data.PHIEUNHAPs.Where(t => t.MAPN == pmh.MAPN.ToString()).FirstOrDefault();
                data.Refresh(RefreshMode.OverwriteCurrentValues, thanhvien);
                thanhvien.SODONHANG = pmh.SODONHANG;
                thanhvien.NGAYNHAP = pmh.NGAYNHAP;
                thanhvien.TONGTIENNHAP = pmh.TONGTIENNHAP;
                data.SubmitChanges();
                return true;
            }
            catch(Exception e)
            {
                return false;
            }
        }
        public bool xoa(PHIEUNHAP pmh)
        {
            try
            {
                PHIEUNHAP mh = data.PHIEUNHAPs.Where(t => t.MAPN == pmh.MAPN.ToString()).FirstOrDefault();
                data.PHIEUNHAPs.DeleteOnSubmit(mh);
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
