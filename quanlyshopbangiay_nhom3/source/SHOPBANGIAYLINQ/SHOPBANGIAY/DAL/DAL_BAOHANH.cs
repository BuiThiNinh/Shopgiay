using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_BAOHANH
    {
        DataClasses1DataContext data = new DataClasses1DataContext();
        public List<PHIEUBAOHANH> loadbangbaohanh()
        {
            var dulieu = (from s in data.PHIEUBAOHANHs select s);
            return dulieu.ToList<PHIEUBAOHANH>();
        }

        public bool them(PHIEUBAOHANH pmh)
        {
            try
            {
                data.PHIEUBAOHANHs.InsertOnSubmit(pmh);
                data.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool xoa(PHIEUBAOHANH pmh)
        {
            try
            {
                PHIEUBAOHANH mh = data.PHIEUBAOHANHs.Where(t => t.MABH == pmh.MABH.ToString()).FirstOrDefault();
                data.PHIEUBAOHANHs.DeleteOnSubmit(mh);
                data.SubmitChanges();
                return true;
            }
            catch(Exception e)
            {
                return false;
            }
        }
    }
}
