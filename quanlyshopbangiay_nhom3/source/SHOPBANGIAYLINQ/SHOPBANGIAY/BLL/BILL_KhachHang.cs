using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
namespace BLL
{
   public class BILL_KhachHang
    {
       DAL_Khachhang kh = new DAL_Khachhang();
       public List<KHACHHANG> loadkh()
       {
           return kh.loadsp();
       }
       public string makh(string sdt)
       {
           return kh.laymakh(sdt);
       }
       public string makh1(string mkh)
       {
           return kh.laymakh1(mkh);
       }
       public bool ktkc(string pma)
       {
           return kh.ktkc_kh(pma);
       }
       public bool themkh(KHACHHANG k)
       {
           return kh.them(k);
       }
       public bool suakh(KHACHHANG ma)
       {
           return kh.sua(ma);
       }
       public string sinhma()
       {
           return kh.sinhmakh();
       }
    }
}
