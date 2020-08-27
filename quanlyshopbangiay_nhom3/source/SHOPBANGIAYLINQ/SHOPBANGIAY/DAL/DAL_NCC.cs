using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_NCC
    {
        DataClasses1DataContext data = new DataClasses1DataContext();
        public List<NHACC> loadbangnhacungcap()
        {
            var dulieu = (from s in data.NHACCs select s);
            return dulieu.ToList<NHACC>();
        }

        public List<NHACC> loadbangnhacungcap_mancc(String mancc)
        {
            var dulieu = (from s in data.NHACCs where s.MANCC==mancc select s);
            return dulieu.ToList<NHACC>();
        }

        public bool ktkc(NHACC ma)
        {
            int r = data.NHACCs.Count(t => t.MANCC == ma.MANCC.ToString());
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
        public bool them(NHACC pmh)
        {
            try
            {
                data.NHACCs.InsertOnSubmit(pmh);
                data.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }


        public bool sua(NHACC pmh)
        {
            try
            {
                NHACC thanhvien = data.NHACCs.Where(t => t.MANCC == pmh.MANCC.ToString()).FirstOrDefault();
                thanhvien.TENNCC = pmh.TENNCC;
                thanhvien.DIACHINCC = pmh.DIACHINCC;
                thanhvien.EMAIL = pmh.EMAIL;
                thanhvien.SDTNHACC = pmh.SDTNHACC;
                thanhvien.HOPTAC = pmh.HOPTAC;
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
