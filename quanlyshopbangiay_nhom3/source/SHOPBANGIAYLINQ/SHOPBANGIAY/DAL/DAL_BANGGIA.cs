using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_BANGGIA
    {
        DataClasses1DataContext data = new DataClasses1DataContext();
        public List<bangghepbanggia_sanpham> Load_bangghepgia_sp()
        {
            var bangghepgia_sp = from s in data.LICHSUGIAs
                               join q in data.SANPHAMs on s.MASP equals (q.MASP)
                               select new
                               {
                                   s.MASP,
                                   q.TENSP,
                                   s.MUCGIA,
                                   s.NGAYAPDUNG,
                                   s.NGAYKETTHUC
                               };
            var kq = bangghepgia_sp.ToList().ConvertAll(t => new bangghepbanggia_sanpham()
            {
                MASP1 = t.MASP,
                TENSP1 = t.TENSP,
                MUCGIA1=Convert.ToDouble(t.MUCGIA),
                NGAYAPDUNG1=Convert.ToDateTime(t.NGAYAPDUNG),
                NGAYKETTHUC1=Convert.ToDateTime(t.NGAYKETTHUC)
            });
            return kq.ToList<bangghepbanggia_sanpham>();
        }
        public bool ktkc(LICHSUGIA pmh)
        {
            int r = data.LICHSUGIAs.Count(t => t.MASP == pmh.MASP.ToString() && t.NGAYAPDUNG == Convert.ToDateTime(pmh.NGAYAPDUNG.ToString()));
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
        public bool them(LICHSUGIA pmh)
        {
            try
            {
                data.LICHSUGIAs.InsertOnSubmit(pmh);
                data.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }


        public bool sua(LICHSUGIA pmh)
        {
            try
            {
                LICHSUGIA thanhvien = data.LICHSUGIAs.Where(t => t.MASP == pmh.MASP.ToString() && t.NGAYAPDUNG==Convert.ToDateTime(pmh.NGAYAPDUNG.ToString())).FirstOrDefault();
                thanhvien.MUCGIA = pmh.MUCGIA;
                thanhvien.NGAYKETTHUC = Convert.ToDateTime(pmh.NGAYKETTHUC);
                data.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public Double giaban(string ma)
        {
            try
            {
                var dulieu = (from s in data.LICHSUGIAs where s.MASP.Equals(ma) && s.NGAYAPDUNG >= DateTime.Now.Date && s.NGAYKETTHUC !=null select s.MUCGIA).FirstOrDefault();
                return Convert.ToDouble(dulieu.ToString());
            }
            catch
            {
                return 0;
            }
        }

        
    }
}
