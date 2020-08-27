using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class BLL_PHANQUYEN
    {
        DAL_PHANQUYEN pq = new DAL_PHANQUYEN();
        public List<Ghepbangphanquyen_manhinh> Load_phanquyen()
        {
            return pq.Load_PHANQUYEN();
        }
        public bool ktkc(QLPHANQUYEN n)
        {
            return pq.ktkc(n);
        }
        public bool thempq(QLPHANQUYEN n)
        {
            return pq.them(n);
        }
        public bool xoapq(QLPHANQUYEN n)
        {
            return pq.xoa(n);
        }
        public bool suapq(QLPHANQUYEN n)
        {
            return pq.sua(n);
        }
    }
}
