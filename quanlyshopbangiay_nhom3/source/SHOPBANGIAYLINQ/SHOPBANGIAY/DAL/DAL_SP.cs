using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_SP
    {
        DataClasses1DataContext data = new DataClasses1DataContext();
        public List<SANPHAM> loadbangsanpham()
        {
            var dulieu = (from s in data.SANPHAMs select s);
            return dulieu.ToList<SANPHAM>();
        }
        
        public List<SANPHAM> loadbangsanpham_masp(string maloai)
        {
            var dulieu = (from s in data.SANPHAMs where s.MALOAI==maloai select s);
            return dulieu.ToList<SANPHAM>();
        }

        DataClasses1DataContext da = new DataClasses1DataContext();
        public List<bangghepsp_loaigiay_kho_sizegiay> loadKHo()
        {
            var kho = from k in da.KHOs
                      from l in da.LOAIGIAYs
                      from ncc in da.NHACCs
                      from sp in da.SANPHAMs
                      from s in da.SIZEGIAYs
                      where k.MASP == sp.MASP && l.MALOAI == sp.MALOAI && ncc.MANCC == sp.MANCC && s.MASP==sp.MASP
                      select new
                      {
                          sp.MASP,
                          sp.TENSP,
                          l.TENLOAI,
                          sp.MAU,
                          sp.CHATLIEU,
                          k.SOLUONG,
                          s.SOLUONGSIZE,
                          s.SIZE,
                          ncc.TENNCC,
                          sp.TINHTRANGSP
                      };
            var kq = kho.ToList().ConvertAll(t => new bangghepsp_loaigiay_kho_sizegiay()
            {
                MASP1 = t.MASP,
                TENSP1 = t.TENSP,
                TENLOAI1 = t.TENLOAI,
                MAU1 = t.MAU,
                CHATLIEU1 = t.CHATLIEU,
                SOLUONGKHO1=Convert.ToInt32(t.SOLUONG),
                SOLUONGSIZE1=Convert.ToInt32(t.SOLUONGSIZE),
                TENNCC1 = t.TENNCC,
                TINHTRANGSP1 = t.TINHTRANGSP,
                SIZE1=t.SIZE
            });
            return kq.ToList<bangghepsp_loaigiay_kho_sizegiay>();
        }
        public bool ktkc(SANPHAM pmh)
        {
            int r = data.SANPHAMs.Count(t => t.MASP == pmh.MASP.ToString());
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
        public bool them(SANPHAM pmh)
        {
            try
            {
                data.SANPHAMs.InsertOnSubmit(pmh);
                data.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }


        public bool sua(SANPHAM pmh)
        {
            try
            {
                SANPHAM thanhvien = data.SANPHAMs.Where(t => t.MASP == pmh.MASP.ToString()).FirstOrDefault();
                thanhvien.TENSP = pmh.TENSP;
                thanhvien.MAU = pmh.MAU;
                thanhvien.CHATLIEU = pmh.CHATLIEU;
                thanhvien.TINHTRANGSP = pmh.TINHTRANGSP;
                thanhvien.MALOAI = pmh.MALOAI;
                thanhvien.MANCC = pmh.MANCC;
                data.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool xoa(SANPHAM pmh)
        {
            try
            {
                SANPHAM mh = data.SANPHAMs.Where(t => t.MASP == pmh.MASP.ToString()).FirstOrDefault();
                data.SANPHAMs.DeleteOnSubmit(mh);
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
