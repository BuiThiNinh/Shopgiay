using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class BLL_CTPHIEUDATHANG
    {
        DAL_CHITIETPHIEUDATHANG dl = new DAL_CHITIETPHIEUDATHANG();

        public List<CTPHIEUDATHANGNCC> loadbang_ctphieudathang()
        {
            return dl.loadbangctphieudathang();
        }

        public List<CTPHIEUDATHANGNCC> loadbang_ctphieudathang_maphieudat(String maphieudat)
        {
            return dl.loadbangctphieudathang_maphieudat(maphieudat);
        }
        public bool ktkc(CTPHIEUDATHANGNCC n)
        {
            return dl.ktkc(n);
        }
        public bool themctpdh(CTPHIEUDATHANGNCC n)
        {
            return dl.them(n);
        }
        public bool xoactpdh(CTPHIEUDATHANGNCC n)
        {
            return dl.xoa(n);
        }
        public bool suactpdh(CTPHIEUDATHANGNCC n)
        {
            return dl.sua(n);
        }

        public bool xoactpdh_maphieudathang(CTPHIEUDATHANGNCC n)
        {
            return dl.xoa_tatcactpd(n);
        }
    }
}
