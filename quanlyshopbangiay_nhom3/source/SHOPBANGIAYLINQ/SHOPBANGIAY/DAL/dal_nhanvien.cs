using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class dal_nhanvien
    {
        DataClasses1DataContext data = new DataClasses1DataContext();
        public List<NHANVIEN> loadbangnhanvien()
        {
            var dulieu = (from s in data.NHANVIENs select s);
            return dulieu.ToList<NHANVIEN>();
        }

        public List<NHANVIEN> loadbangnhanvien_tk(NHANVIEN ma)
        {
            try
            {
                var dulieu = (from s in data.NHANVIENs where s.MANV.Contains(ma.MANV) || s.TENNV.Contains(ma.TENNV) select s);
                return dulieu.ToList<NHANVIEN>();
            }
            catch
            {
                return null;
            }
        }


        public bool ktkc(NHANVIEN ma)
        {
            int r = data.NHANVIENs.Count(t => t.MANV ==ma.MANV.ToString());
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
        public bool them(NHANVIEN pmh)
        {
            try
            {
                data.NHANVIENs.InsertOnSubmit(pmh);
                data.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool sua(NHANVIEN pmh)
        {
            try
            {
                NHANVIEN thanhvien = data.NHANVIENs.Where(t => t.MANV == pmh.MANV.ToString()).FirstOrDefault();
                thanhvien.TENNV = pmh.TENNV;
                thanhvien.GIOITINH =pmh.GIOITINH;
                thanhvien.SOCMND = pmh.SOCMND;
                thanhvien.DIENTHOAINV = pmh.DIENTHOAINV;
                thanhvien.DIACHI = pmh.DIACHI;
                thanhvien.TINHTRANG = pmh.TINHTRANG;
                thanhvien.NGAYVAOLAM = Convert.ToDateTime(pmh.NGAYVAOLAM);
                thanhvien.MANQL = pmh.MANQL;
                thanhvien.THUONG = Convert.ToDouble(pmh.THUONG);
                thanhvien.TRU = Convert.ToDouble(pmh.TRU);
                thanhvien.THUCLANH = Convert.ToDouble(pmh.THUCLANH);
                data.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool xoa(NHANVIEN pmh)
        {
            try
            {
                NHANVIEN mh = data.NHANVIENs.Where(t => t.MANV == pmh.MANV.ToString()).FirstOrDefault();
                data.NHANVIENs.DeleteOnSubmit(mh);
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
