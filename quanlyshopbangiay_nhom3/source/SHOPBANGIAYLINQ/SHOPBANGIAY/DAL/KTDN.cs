using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class KTDN
    {
        DataClasses1DataContext data = new DataClasses1DataContext();
        public bool kiemtrataikhoan(String tendn, String mk)
        {
            int kttk = (from nd in data.QUANLYNDs
                        where nd.TENDN == tendn && nd.MK == mk && nd.HOATDONG == true
                        select new { nd }).Count();
            if (kttk == 1)
                return true;
            else
                return false;
        }
        public bool kiemtraquyentruycap(String tendn, String mamh)
        {
            int ktquyen = (from s in data.QLNDNHOMNDs
                           join c in data.QLPHANQUYENs on s.MANHOM equals c.MANHOM
                           where c.MAMANHINH == mamh && s.TENDN == tendn
                           select new
                           {
                               c
                           }).Count();
            if (ktquyen != 0)
            {
                return true;
            }
            else
                return false;
        }
    }
}
