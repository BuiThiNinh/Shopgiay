using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class BLL_DMMH
    {
        DAL_MAHINHCHUCNANG mh = new DAL_MAHINHCHUCNANG();
        public List<DMMANHINH> Load_dmmh()
        {
            return mh.loadbang_dmmanhinh();
        }
    }
}
