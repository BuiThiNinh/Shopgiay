using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
namespace BLL
{
   public class BLL_Kho
    {
       DAL_Kho kh = new DAL_Kho();
       public List<GHEP_Kho_SP> loadKho()
       {
           return kh.loadKHo();
       }

       public bool ktkc_kho(KHO n)
       {
           return kh.ktkc(n);
       }
       public bool themkho(KHO n)
       {
           return kh.them(n);
       }

       public bool suakho(KHO n)
       {
           return kh.sua(n);
       }
    }
}
