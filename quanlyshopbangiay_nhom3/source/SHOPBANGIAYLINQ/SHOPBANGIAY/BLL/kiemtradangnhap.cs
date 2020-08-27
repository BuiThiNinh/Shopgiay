using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class kiemtradangnhap
    {
        KTDN dll_KTDN = new KTDN();
        public bool dangnhap_cotontai(string tendn, string mk)
        {
            return dll_KTDN.kiemtrataikhoan(tendn,mk);
        }

        public bool kiemtrathucquyen(string tendn, string mamh)
        {
            return dll_KTDN.kiemtraquyentruycap(tendn, mamh);
        }
    }
}
