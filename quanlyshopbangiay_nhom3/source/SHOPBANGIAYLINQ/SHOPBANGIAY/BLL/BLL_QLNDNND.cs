using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class BLL_QLNDNND
    {
        DAL_QLNDNND dl = new DAL_QLNDNND();
        public bool ktkc(QLNDNHOMND n)
        {
            return dl.ktkc(n);
        }
        public bool themndnnd(QLNDNHOMND n)
        {
            return dl.them(n);
        }
        public bool xoandnnd(QLNDNHOMND n)
        {
            return dl.xoa(n);
        }
        public bool suandndn(QLNDNHOMND n)
        {
            return dl.sua(n);
        }

    }
}
