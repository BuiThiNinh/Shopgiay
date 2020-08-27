using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_CHITIETPHIEUDATHANG
    {
        DataClasses1DataContext da = new DataClasses1DataContext();

        public List<CTPHIEUDATHANGNCC> loadbangctphieudathang()
        {
            var dulieu = (from s in da.CTPHIEUDATHANGNCCs select s);
            return dulieu.ToList<CTPHIEUDATHANGNCC>();
        }

        public List<CTPHIEUDATHANGNCC> loadbangctphieudathang_maphieudat(String maphieudat)
        {
            var dulieu = (from s in da.CTPHIEUDATHANGNCCs where s.SODONHANG==maphieudat select s);
            return dulieu.ToList<CTPHIEUDATHANGNCC>();
        }

        public bool ktkc(CTPHIEUDATHANGNCC pmh)
        {
            int r = da.CTPHIEUDATHANGNCCs.Count(t => t.SODONHANG == pmh.SODONHANG.ToString() && t.MASP==pmh.MASP && t.COSIZE==pmh.COSIZE);
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
        public bool them(CTPHIEUDATHANGNCC pmh)
        {
            try
            {  
                da.CTPHIEUDATHANGNCCs.InsertOnSubmit(pmh);
                da.SubmitChanges();
                da.Refresh(RefreshMode.OverwriteCurrentValues, pmh);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool sua(CTPHIEUDATHANGNCC pmh)
        {
            try
            {
                CTPHIEUDATHANGNCC thanhvien = da.CTPHIEUDATHANGNCCs.Where(t => t.SODONHANG == pmh.SODONHANG.ToString() && t.MASP==pmh.MASP && t.COSIZE==pmh.COSIZE).FirstOrDefault();
                thanhvien.SOLUONG = pmh.SOLUONG;
                da.SubmitChanges();
                da.Refresh(RefreshMode.OverwriteCurrentValues, thanhvien);
                da.Refresh(RefreshMode.OverwriteCurrentValues, pmh);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool xoa(CTPHIEUDATHANGNCC pmh)
        {
            try
            {
                CTPHIEUDATHANGNCC mh = da.CTPHIEUDATHANGNCCs.Where(t => t.SODONHANG == pmh.SODONHANG.ToString() && t.MASP==pmh.MASP && t.COSIZE==pmh.COSIZE).FirstOrDefault();
                da.CTPHIEUDATHANGNCCs.DeleteOnSubmit(mh);
                da.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool xoa_tatcactpd(CTPHIEUDATHANGNCC pmh)
        {
            try
            {
                CTPHIEUDATHANGNCC mh = da.CTPHIEUDATHANGNCCs.Where(t => t.SODONHANG == pmh.SODONHANG.ToString()).FirstOrDefault();
                da.CTPHIEUDATHANGNCCs.DeleteOnSubmit(mh);
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

