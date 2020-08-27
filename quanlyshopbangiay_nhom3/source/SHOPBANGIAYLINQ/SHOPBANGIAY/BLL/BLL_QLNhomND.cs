using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
namespace BLL
{
    public class BLL_QLnhomND
    {
        DAL_QLnhomND dl = new DAL_QLnhomND();

        public List<QLNHOMND> loadbang_qlnhomND()
        {
            return dl.loadbang_qlnhomND();
        }
        public bool ktkc(QLNHOMND n)
        {
            return dl.ktkc(n);
        }
        public bool themnhomnd(QLNHOMND n)
        {
            return dl.them(n);
        }
        public bool xoanhomnd(QLNHOMND n)
        {
            return dl.xoa(n);
        }
        public bool suanhomnd(QLNHOMND n)
        {
            return dl.sua(n);
        }

    }
}
