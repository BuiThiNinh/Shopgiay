using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class BLL_BAOHANH
    {
        DAL_BAOHANH dl = new DAL_BAOHANH();

        public List<PHIEUBAOHANH> loadbang_baohanh()
        {
            return dl.loadbangbaohanh();
        }

        public bool thempbh(PHIEUBAOHANH n)
        {
            return dl.them(n);
        }
        public bool xoapbh(PHIEUBAOHANH n)
        {
            return dl.xoa(n);
        }
    }
}
