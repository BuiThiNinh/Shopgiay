using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
namespace BLL
{
   public class BLL_BBSUCO
    {
        DAL_BBSUCO bb = new DAL_BBSUCO();
        public List<BIENBANSUCO> loadBBSC()
        {
            return bb.loadBBSC();
        }
        public List<GhepBang_SuCo> loadBienBangSuCo()
        {
            return bb.loadbangBaoHanh();
        }
        public bool ThemBBSC(BIENBANSUCO bbsc)
        {
            return bb.ThemBBSC(bbsc);
        }
        public bool ktkcbb(string ma)
        {
            return bb.ktkcSUCo(ma);
        }
        public bool xoabbsc(BIENBANSUCO bbsc)
        {
            return bb.xoaBBSC(bbsc);
        }
        public bool suabbsc(BIENBANSUCO bbsc)
        {
            return bb.suaBB(bbsc);
        }
        public string layten(string ma)
        {
            return bb.Laytennv(ma);
        }
        public List<CHITIETHOADONBAN> loadct()
        {
            return bb.loadcthd();
        }
        public string laytensp(string ma)
        {
            return bb.laytensp(ma);
        }
    }
}
