using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_MAHINHCHUCNANG
    {
        DataClasses1DataContext data = new DataClasses1DataContext();
        public List<DMMANHINH> loadbang_dmmanhinh()
        {
            var dulieu = (from s in data.DMMANHINHs select s);
            return dulieu.ToList<DMMANHINH>();
        }
    }
}
