using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_PHIEUDATHANG
    {
        DataClasses1DataContext da = new DataClasses1DataContext();

        public List<PHIEUDATHANGNCC> loadbangphieudathang()
        {
            var dulieu = (from s in da.PHIEUDATHANGNCCs select s);
            return dulieu.ToList<PHIEUDATHANGNCC>();
        }

        public string maphieudathang_ngaydat(DateTime nl)
        {
            var dulieu = (from s in da.PHIEUDATHANGNCCs where s.NGAYLAP==nl select s.SODONHANG).FirstOrDefault();
            return dulieu.ToString();
        }
        public bool ktkc(PHIEUDATHANGNCC ma)
        {
            int r = da.PHIEUDATHANGNCCs.Count(t => t.SODONHANG == ma.SODONHANG.ToString());
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
        public bool them(PHIEUDATHANGNCC pmh)
        {
            try
            {
                da.PHIEUDATHANGNCCs.InsertOnSubmit(pmh);
                da.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool sua(PHIEUDATHANGNCC pmh)
        {
            try
            {
                PHIEUDATHANGNCC thanhvien = da.PHIEUDATHANGNCCs.Where(t => t.SODONHANG == pmh.SODONHANG.ToString()).FirstOrDefault();
                thanhvien.MANCC = pmh.MANCC;
                thanhvien.MANV = pmh.MANV;
                thanhvien.NGAYLAP = pmh.NGAYLAP;
                thanhvien.TONGSOLUONGNHAP = pmh.TONGSOLUONGNHAP;
                thanhvien.TINHTRANGHANG = "Chưa giao hàng";
                da.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool xoa(PHIEUDATHANGNCC pmh)
        {
            try
            {
                PHIEUDATHANGNCC mh = da.PHIEUDATHANGNCCs.Where(t => t.SODONHANG == pmh.SODONHANG.ToString()).FirstOrDefault();
                da.PHIEUDATHANGNCCs.DeleteOnSubmit(mh);
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
