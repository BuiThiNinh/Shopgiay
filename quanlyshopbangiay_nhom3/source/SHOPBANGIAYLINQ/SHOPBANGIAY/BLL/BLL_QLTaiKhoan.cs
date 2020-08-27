using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
namespace BLL
{
    public class BLL_QLTaiKhoan
    {
        DAL_QLTaiKhoan data = new DAL_QLTaiKhoan();

        public List<QLNHOMND> Load_NhomND()
        {
            
            return data.load_NhomND();
        }
        public List<QUANLYND> LoadbangQUANLYND()
        {

            return data.loadbangQUANLYND();
        }
        public List<GhepBang_NDnhomND> Load_NDnhomND()
        {
           
            return data.Load_NDnhomND();
        }

        public bool ktkc(QUANLYND n)
        {
            return data.ktkc(n);
        }
        public bool themtk(QUANLYND n)
        {
            return data.them(n);
        }
        public bool xoatk(QUANLYND n)
        {
            return data.xoa(n);
        }
        public bool suatk(QUANLYND n)
        {
            return data.sua(n);
        }
        public bool suatk1(QUANLYND n)
        {
            return data.sua1(n);
        }
    }
}
