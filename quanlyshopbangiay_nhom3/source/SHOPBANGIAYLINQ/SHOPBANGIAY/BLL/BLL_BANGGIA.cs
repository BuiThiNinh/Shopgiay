using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class BLL_BANGGIA
    {
        DAL_BANGGIA data = new DAL_BANGGIA();

        public List<bangghepbanggia_sanpham> Load_lichsugia()
        {

            return data.Load_bangghepgia_sp();
        }
        public bool ktkc(LICHSUGIA n)
        {
            return data.ktkc(n);
        }
        public bool themgia(LICHSUGIA n)
        {
            return data.them(n);
        }
        
        public bool suagia(LICHSUGIA n)
        {
            return data.sua(n);
        }

        public Double giabansp(string ma)
        {
            return data.giaban(ma);
        }
    }
}
