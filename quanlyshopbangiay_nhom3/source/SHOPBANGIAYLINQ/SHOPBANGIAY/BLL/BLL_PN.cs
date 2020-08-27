using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class BLL_PN
    {
        DAL_PN hd = new DAL_PN();
        public List<PHIEUNHAP> loadbang_PN()
        {
            return hd.loadbangPN();
        }
        public bool ktkc(PHIEUNHAP n)
        {
            return hd.ktkc(n);
        }
        public bool thempn(PHIEUNHAP n)
        {
            return hd.them(n);
        }

        public bool suapn(PHIEUNHAP n)
        {
            return hd.sua(n);
        }


        public bool xoapn(PHIEUNHAP n)
        {
            return hd.xoa(n);
        }
    }
}
