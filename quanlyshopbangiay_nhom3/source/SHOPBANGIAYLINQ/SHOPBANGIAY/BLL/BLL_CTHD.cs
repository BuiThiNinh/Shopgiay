using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class BLL_CTHD
    {
        DAL_CTHD hd = new DAL_CTHD();
        public List<CHITIETHOADONBAN> loadbang_cthd()
        {
            return hd.loadbangcthd();
        }
        public List<CHITIETHOADONBAN> loadbang_cthd_mhd(string mahd)
        {
            return hd.loadbangcthd_masp(mahd);
        }

        public List<tensanpham> loadbangghep_cthd_mhd(string mahd)
        {
            return hd.loadbangghepcthd_sp(mahd);
        }

        public List<tensanpham> loadbangghep_cthd()
        {
            return hd.loadbangghepcthd();
        }
        public bool themcthd(CHITIETHOADONBAN n)
        {
            return hd.them(n);
        }
        public bool xoacthdb(CHITIETHOADONBAN n)
        {
            return hd.xoa(n);
        }

        
    }
}
