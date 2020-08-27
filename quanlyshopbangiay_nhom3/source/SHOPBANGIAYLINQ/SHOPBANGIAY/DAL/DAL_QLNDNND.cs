using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_QLNDNND
    {
        DataClasses1DataContext da=new DataClasses1DataContext();
        public bool ktkc(QLNDNHOMND ma)
        {
            int r = da.QLNDNHOMNDs.Count(t => t.TENDN == ma.TENDN.ToString() && t.MANHOM==ma.MANHOM.ToString());
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
        public bool them(QLNDNHOMND pmh)
        {
            try
            {
                da.QLNDNHOMNDs.InsertOnSubmit(pmh);
                da.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool sua(QLNDNHOMND pmh)
        {
            try
            {
                QLNDNHOMND thanhvien = da.QLNDNHOMNDs.Where(t => t.TENDN == pmh.TENDN.ToString() && t.MANHOM == pmh.MANHOM.ToString()).FirstOrDefault();
                thanhvien.MANHOM = pmh.MANHOM;
                thanhvien.GHICHU = pmh.GHICHU;
                da.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool xoa(QLNDNHOMND pmh)
        {
            try
            {
                QLNDNHOMND mh = da.QLNDNHOMNDs.Where(t => t.TENDN == pmh.TENDN.ToString() && t.MANHOM == pmh.MANHOM.ToString()).FirstOrDefault();
                da.QLNDNHOMNDs.DeleteOnSubmit(mh);
                da.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
