using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class BLL_PHIEUDATHANG
    {
        DAL_PHIEUDATHANG dl = new DAL_PHIEUDATHANG();

        public List<PHIEUDATHANGNCC> loadbang_phieudathang()
        {
            return dl.loadbangphieudathang();
        }
        public string laymapd_ngaydat(DateTime nl)
        {
            return dl.maphieudathang_ngaydat(nl);
        }
        public bool ktkc(PHIEUDATHANGNCC n)
        {
            return dl.ktkc(n);
        }
        public bool thempdh(PHIEUDATHANGNCC n)
        {
            return dl.them(n);
        }
        public bool xoapdh(PHIEUDATHANGNCC n)
        {
            return dl.xoa(n);
        }
        public bool suapdh(PHIEUDATHANGNCC n)
        {
            return dl.sua(n);
        }
    }
}
