using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
   public class DAL_Kho
    {
       DataClasses1DataContext da = new DataClasses1DataContext();
       public List<GHEP_Kho_SP> loadKHo()
       {
           var kho = from k in da.KHOs
                     from sp in da.SANPHAMs
                     where k.MASP==sp.MASP
                     select new
                     {
                         k.MASP,
                         sp.TENSP,
                         k.SOLUONG,
                         k.TRANGTHAI
                     };
           var kq = kho.ToList().ConvertAll(t => new GHEP_Kho_SP()
           {
               MASP = t.MASP,
               TENSP = t.TENSP,
               SOLUONG = Convert.ToInt32(t.SOLUONG),
               TRANGTHAI = t.TRANGTHAI
           });
           return kq.ToList<GHEP_Kho_SP>();
       }
       public bool ktkc(KHO pmh)
       {
           int r = da.KHOs.Count(t => t.MASP == pmh.MASP.ToString());
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
       public bool them(KHO pmh)
       {
           try
           {
               da.KHOs.InsertOnSubmit(pmh);
               da.SubmitChanges();
               return true;
           }
           catch
           {
               return false;
           }
       }
       public bool sua(KHO pmh)
       {
           try
           {
               KHO thanhvien = da.KHOs.Where(t => t.MASP == pmh.MASP.ToString()).FirstOrDefault();
               thanhvien.SOLUONG = pmh.SOLUONG;
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
