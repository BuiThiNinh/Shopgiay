using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class BLL_SIZEGIAY
    {
        DAL_SIZE dl = new DAL_SIZE();
        public List<Int32> loadsizegiay(string masp)
        {
            return dl.loadbangsize_masp(masp);
        }
        public List<SIZEGIAY> loadsizeg()
        {
            return dl.loadbangsize();
        }
        public bool ktkc_sizegiay(SIZEGIAY n)
        {
            return dl.ktkc(n);
        }
        public bool ktkc_sizegiay1(SIZEGIAY n)
        {
            return dl.ktkc1(n);
        }
        public bool themsizegiay(SIZEGIAY n)
        {
            return dl.them(n);
        }

        public bool suasizegiay(SIZEGIAY n)
        {
            return dl.sua(n);
        }

        public bool xoasizegiay(SIZEGIAY n)
        {
            return dl.xoa(n);
        }
    }
}
