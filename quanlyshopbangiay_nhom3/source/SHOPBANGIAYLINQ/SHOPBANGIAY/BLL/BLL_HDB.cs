using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class BLL_HDB
    {
        DAL_HOADON dl = new DAL_HOADON();

        public List<HOADONBAN> loadbang_hdb()
        {
            return dl.loadbang_hdb();
        }

        public bool ktkc_hdb(HOADONBAN n)
        {
            return dl.ktkc(n);
        }
        public bool themhdb(HOADONBAN n)
        {
            return dl.them(n);
        }

        public bool suahdb(HOADONBAN n)
        {
            return dl.sua(n);
        }

        public bool xoahdb(HOADONBAN n)
        {
            return dl.xoa(n);
        }
        public Double laygiasp(String msp)
        {
            return dl.laygiasp(msp);
        }

        public int capnhatkho(String msp, int sl)
        {
            return dl.capsoluongkho(msp, sl);
        }
        public int capnhatkho1(String msp, int sl)
        {
            return dl.capsoluongkho1(msp, sl);
        }
    }
}
