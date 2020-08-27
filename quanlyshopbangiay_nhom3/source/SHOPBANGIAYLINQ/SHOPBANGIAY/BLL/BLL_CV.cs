using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class BLL_CV
    {
        DLL_CHUVU cv = new DLL_CHUVU();
        public List<CHUCVU> loadchucvu()
        {
            return cv.loadbangchucvu();
        }
    }
}
