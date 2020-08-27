using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_LOAIGIAY
    {
        DataClasses1DataContext da = new DataClasses1DataContext();
        public List<LOAIGIAY> loadbangloaigiay()
        {
            var dulieu = (from s in da.LOAIGIAYs select s);
            return dulieu.ToList<LOAIGIAY>();
        }

        public bool ktkc(LOAIGIAY ma)
        {
            var kt = (from k in da.LOAIGIAYs where k.MALOAI == ma.MALOAI select k).Count();
            if (kt == 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        public bool them(LOAIGIAY pmh)
        {
            try
            {
                da.LOAIGIAYs.InsertOnSubmit(pmh);
                da.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }


        public bool sua(LOAIGIAY pmh)
        {
            try
            {
                LOAIGIAY thanhvien = da.LOAIGIAYs.Where(t => t.MALOAI == pmh.MALOAI.ToString()).FirstOrDefault();
                thanhvien.TENLOAI = pmh.TENLOAI;
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
