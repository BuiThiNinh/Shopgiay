using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
   public class DAL_SanPham
    {
         DataClasses1DataContext da = new DataClasses1DataContext();
         public List<bangghepsp_loaigiay_kho_sizegiay> loadKHo()
         {
             var kho = from k in da.KHOs
                       from l in da.LOAIGIAYs
                       from ncc in da.NHACCs
                       from sp in da.SANPHAMs
                       where k.MASP == sp.MASP && l.MALOAI==sp.MALOAI && ncc.MANCC==sp.MANCC
                       select new
                       {
                          sp.MASP,
                          sp.TENSP,
                          l.TENLOAI,
                          sp.MAU,
                          sp.CHATLIEU,
                          ncc.TENNCC,
                          k.TRANGTHAI
                       };
             var kq = kho.ToList().ConvertAll(t => new bangghepsp_loaigiay_kho_sizegiay()
             {
                MASP1=t.MASP,
                TENSP1=t.TENSP,
                TENLOAI1=t.TENLOAI,
                MAU1=t.MAU,
                CHATLIEU1=t.CHATLIEU,
                TENNCC1=t.TENNCC,
                TINHTRANGSP1=t.TRANGTHAI
             });
             return kq.ToList<bangghepsp_loaigiay_kho_sizegiay>();
         }
    } 
}
