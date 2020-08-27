using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class BLL_NCC
    {
        DAL_NCC ncc = new DAL_NCC();
        public List<NHACC> loadbang_ncc()
        {
            return ncc.loadbangnhacungcap();
        }

        public List<NHACC> loadbang_ncc_mancc(string mancc)
        {
            return ncc.loadbangnhacungcap_mancc(mancc);
        }

        public bool ktkc(NHACC n)
        {
            return ncc.ktkc(n);
        }
        public bool themncc(NHACC n)
        {
            return ncc.them(n);
        }
       
        public bool suancc(NHACC n)
        {
            return ncc.sua(n);
        }
    }
}
