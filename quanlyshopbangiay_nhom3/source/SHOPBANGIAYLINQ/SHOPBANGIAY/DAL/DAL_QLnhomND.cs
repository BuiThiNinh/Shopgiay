using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_QLnhomND
    {
        DataClasses1DataContext data = new DataClasses1DataContext();

        public List<QLNHOMND> loadbang_qlnhomND()
        {
            var dulieu = (from s in data.QLNHOMNDs select s);
            return dulieu.ToList<QLNHOMND>();
        }
        public bool ktkc(QLNHOMND ma)
        {
            int r = data.QLNHOMNDs.Count(t => t.MANHOM == ma.MANHOM.ToString());
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
        public bool them(QLNHOMND pmh)
        {
            try
            {
                data.QLNHOMNDs.InsertOnSubmit(pmh);
                data.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool sua(QLNHOMND pmh)
        {
            try
            {
                QLNHOMND thanhvien = data.QLNHOMNDs.Where(t => t.MANHOM == pmh.MANHOM.ToString()).FirstOrDefault();
                thanhvien.TENNHOMND = pmh.TENNHOMND;
                thanhvien.GHICHU = pmh.GHICHU;
                data.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool xoa(QLNHOMND pmh)
        {
            try
            {
                QLNHOMND mh = data.QLNHOMNDs.Where(t => t.MANHOM == pmh.MANHOM.ToString()).FirstOrDefault();
                data.QLNHOMNDs.DeleteOnSubmit(mh);
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
