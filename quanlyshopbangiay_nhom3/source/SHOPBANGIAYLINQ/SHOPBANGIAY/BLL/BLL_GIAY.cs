using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class BLL_GIAY
    {
        DAL_LOAIGIAY dl = new DAL_LOAIGIAY();

        public List<LOAIGIAY> loadbang_loaigiay()
        {
            return dl.loadbangloaigiay();
        }

        public bool ktkc_lg(LOAIGIAY n)
        {
            return dl.ktkc(n);
        }
        public bool themlg(LOAIGIAY n)
        {
            return dl.them(n);
        }

        public bool sualg(LOAIGIAY n)
        {
            return dl.sua(n);
        }
    }
}
