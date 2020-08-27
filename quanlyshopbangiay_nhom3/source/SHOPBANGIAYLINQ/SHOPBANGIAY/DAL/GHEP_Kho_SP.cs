using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
   public class GHEP_Kho_SP
    {
        string masp;
        string tensp;
        int sl;
        string trangthai;
        public String MASP
        {
            get { return masp; }
            set { masp = value; }
        }
        public String TENSP
        {
            get { return tensp; }
            set { tensp = value; }
        }
        public String TRANGTHAI
        {
            get { return trangthai; }
            set { trangthai = value; }
        }
        public int SOLUONG
        {
            get { return sl; }
            set { sl = value; }
        }
    }
}
