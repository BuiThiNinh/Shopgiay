using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DLL_CHUVU
    {
        DataClasses1DataContext data=new DataClasses1DataContext();
        public List<CHUCVU> loadbangchucvu()
        {
            var cv = (from s in data.CHUCVUs select s);
            return cv.ToList<CHUCVU>();
        }

        public bool ktkc(CHUCVU ma)
        {
            int r = data.CHUCVUs.Count(t => t.MACHUCVU == ma.MACHUCVU.ToString());
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
        public bool them(CHUCVU pmh)
        {
            try
            {
                data.CHUCVUs.InsertOnSubmit(pmh);
                data.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool sua(CHUCVU pmh)
        {
            try
            {
                CHUCVU thanhvien = data.CHUCVUs.Where(t => t.MACHUCVU == pmh.MACHUCVU.ToString()).FirstOrDefault();
                thanhvien.MACHUCVU = pmh.MACHUCVU;
                thanhvien.TENCV = pmh.TENCV;
                thanhvien.LUONG = pmh.LUONG;
                data.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool xoa(CHUCVU pmh)
        {
            try
            {
                CHUCVU mh = data.CHUCVUs.Where(t => t.MACHUCVU == pmh.MACHUCVU.ToString()).FirstOrDefault();
                data.CHUCVUs.DeleteOnSubmit(mh);
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
