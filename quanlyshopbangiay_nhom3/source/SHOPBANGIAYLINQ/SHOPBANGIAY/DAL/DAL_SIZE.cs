using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_SIZE
    {
        DataClasses1DataContext da = new DataClasses1DataContext();
        public List<Int32> loadbangsize_masp(String masp)
        {
            var dulieu = (from s in da.SIZEGIAYs where s.MASP == masp select s.SIZE);
            return dulieu.ToList<Int32>();
        }
        public List<SIZEGIAY> loadbangsize()
        {
            var dulieu = (from s in da.SIZEGIAYs select s);
            return dulieu.ToList<SIZEGIAY>();
        }
        public bool ktkc(SIZEGIAY pmh)
        {
            int r = da.SIZEGIAYs.Count(t => t.MASP == pmh.MASP.ToString() && t.SIZE == Convert.ToInt32(pmh.SIZE.ToString()));
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

        public bool ktkc1(SIZEGIAY pmh)
        {
            int r = da.SIZEGIAYs.Count(t => t.MASP == pmh.MASP.ToString());
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
        public bool them(SIZEGIAY pmh)
        {
            try
            {
                da.SIZEGIAYs.InsertOnSubmit(pmh);
                da.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool sua(SIZEGIAY pmh)
        {
            try
            {
                SIZEGIAY thanhvien = da.SIZEGIAYs.Where(t => t.MASP == pmh.MASP.ToString() && t.SIZE == Convert.ToInt32(pmh.SIZE.ToString())).FirstOrDefault();
                thanhvien.SOLUONGSIZE = pmh.SOLUONGSIZE;
                da.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool xoa(SIZEGIAY pmh)
        {
            try
            {
                SIZEGIAY mh = da.SIZEGIAYs.Where(t => t.MASP == pmh.MASP.ToString() && t.SIZE == Convert.ToInt32(pmh.SIZE.ToString())).FirstOrDefault();
                da.SIZEGIAYs.DeleteOnSubmit(mh);
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
