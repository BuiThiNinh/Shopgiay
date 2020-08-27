using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class BLL_CTPN
    {
        DAL_CTPN hd = new DAL_CTPN();
        public List<bangghepctpn> loadbang_ctpn()
        {
            return hd.loadctpn_sanpham();
        }
        public List<bangghepctpn> loadbang_ctpn_sp(string msp)
        {
            return hd.loadctpn_sanpham_mpn(msp);
        }
        public bool ktkc_CTPN(CHITIETPHIEUNHAP n)
        {
            return hd.ktkc(n);
        }
        public bool themctpn(CHITIETPHIEUNHAP n)
        {
            return hd.them(n);
        }

        public bool suactpn(CHITIETPHIEUNHAP n)
        {
            return hd.sua(n);
        }
        public bool xoactpn(CHITIETPHIEUNHAP n)
        {
            return hd.xoa(n);
        }
    }
}
