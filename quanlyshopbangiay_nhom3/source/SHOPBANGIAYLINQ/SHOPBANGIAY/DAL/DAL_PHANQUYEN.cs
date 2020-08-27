using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_PHANQUYEN
    {
        DataClasses1DataContext data = new DataClasses1DataContext();
        public List<Ghepbangphanquyen_manhinh> Load_PHANQUYEN()
        {
            var taikhoannhom = from s in data.QLPHANQUYENs
                               join q in data.QLNHOMNDs on s.MANHOM equals (q.MANHOM)
                               join m in data.DMMANHINHs on s.MAMANHINH equals (m.MAMANHINH)
                               select new
                               {
                                   s.MANHOM,
                                   q.TENNHOMND,
                                   s.COQUYEN,
                                   m.MAMANHINH,
                                   m.TENMANHINHCHUCNANG
                               };
            var kq = taikhoannhom.ToList().ConvertAll(t => new Ghepbangphanquyen_manhinh()
            {
                MNHOM1 = t.MANHOM,
                TENNHOMND1 = t.TENNHOMND,
                COQUYEN1 = t.COQUYEN,
                MAMANHINH1=t.MAMANHINH,
                TENMANHINH1=t.TENMANHINHCHUCNANG
            });
            return kq.ToList<Ghepbangphanquyen_manhinh>();
        }
        public bool ktkc(QLPHANQUYEN ma)
        {
            int r = data.QLPHANQUYENs.Count(t => t.MANHOM == ma.MANHOM.ToString() && t.MAMANHINH==ma.MAMANHINH);
            try
            {
                if (r == 0)
                {
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }
        public bool them(QLPHANQUYEN pmh)
        {
            try
            {
                data.QLPHANQUYENs.InsertOnSubmit(pmh);
                data.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool sua(QLPHANQUYEN pmh)
        {
            try
            {
                QLPHANQUYEN thanhvien = data.QLPHANQUYENs.Where(t => t.MANHOM == pmh.MANHOM.ToString() && t.MAMANHINH == pmh.MAMANHINH).FirstOrDefault();
                thanhvien.MANHOM = pmh.MANHOM;
                thanhvien.MAMANHINH = pmh.MAMANHINH;
                data.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool xoa(QLPHANQUYEN pmh)
        {
            try
            {
                QLPHANQUYEN mh = data.QLPHANQUYENs.Where(t => t.MANHOM == pmh.MANHOM.ToString() && t.MAMANHINH == pmh.MAMANHINH).FirstOrDefault();
                data.QLPHANQUYENs.DeleteOnSubmit(mh);
                data.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
