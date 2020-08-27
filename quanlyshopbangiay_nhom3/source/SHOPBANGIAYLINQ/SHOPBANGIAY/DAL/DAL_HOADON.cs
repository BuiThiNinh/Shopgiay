using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_HOADON
    {
        DataClasses1DataContext da = new DataClasses1DataContext();

        public List<HOADONBAN> loadbang_hdb()
        {
            var dulieu = (from s in da.HOADONBANs select s);
            return dulieu.ToList<HOADONBAN>();
        }
        public Double laygiasp(String masp)
        {
            try
            {
                var dulieu1 = (from s in da.LICHSUGIAs where s.MASP == masp select s.NGAYKETTHUC).FirstOrDefault().ToString();
                
                var dulieu = (from s in da.LICHSUGIAs where s.MASP==masp && dulieu1=="" select s.MUCGIA).FirstOrDefault();
                return Convert.ToDouble(dulieu.ToString());
            }
            catch(Exception e)
            {
                return 0;
            }
        }
        public int capsoluongkho(String masp, int soluongban)
        {
            try
            {
                var dulieu = (from s in da.KHOs
                              where s.MASP==masp
                              select s.SOLUONG).FirstOrDefault();
                int sl=Convert.ToInt32(dulieu.ToString())-soluongban;
                if (sl >= 0)
                {
                    return sl;
                }
                else
                {
                    return -1;
                }
            }
            catch(Exception e)
            {
                return -1;
            }
        }
        public int capsoluongkho1(String masp, int soluongban)
        {
            try
            {
                var dulieu = (from s in da.KHOs
                              where s.MASP == masp
                              select s.SOLUONG).FirstOrDefault();
                int sl = Convert.ToInt32(dulieu.ToString()) + soluongban;
                return sl;
            }
            catch (Exception e)
            {
                return -1;
            }
        }
        public bool ktkc(HOADONBAN pmh)
        {
            int r = da.HOADONBANs.Count(t => t.MAHD == pmh.MAHD.ToString());
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
        public bool them(HOADONBAN pmh)
        {
            try
            {
                da.HOADONBANs.InsertOnSubmit(pmh);
                da.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool sua(HOADONBAN pmh)
        {
            try
            {
                HOADONBAN thanhvien = da.HOADONBANs.Where(t => t.MAHD == pmh.MAHD.ToString()).FirstOrDefault();
                thanhvien.MANV = pmh.MANV;
                thanhvien.NGAYLAP = pmh.NGAYLAP;
                thanhvien.MAKHTT = pmh.MAKHTT;
                thanhvien.KHVANGLAI = pmh.KHVANGLAI;
                thanhvien.CHIECKHAU = pmh.CHIECKHAU;
                thanhvien.TONGTIEN = pmh.TONGTIEN;
                da.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool xoa(HOADONBAN pmh)
        {
            try
            {
                HOADONBAN mh = da.HOADONBANs.Where(t => t.MAHD == pmh.MAHD.ToString()).FirstOrDefault();
                da.HOADONBANs.DeleteOnSubmit(mh);
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
