using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_CTHD
    {
        DataClasses1DataContext data = new DataClasses1DataContext();
        public List<CHITIETHOADONBAN> loadbangcthd()
        {
            var dulieu = (from s in data.CHITIETHOADONBANs select s);
            return dulieu.ToList<CHITIETHOADONBAN>();
        }

        public List<tensanpham> loadbangghepcthd_sp(string mahd)
        {
            var dulieu = (from s in data.CHITIETHOADONBANs 
                          join sp in data.SANPHAMs on s.MASP equals(sp.MASP)
                          where s.MAHD==mahd
                          select new 
                          {
                            s.MACTHDB,
                            s.MAHD,
                            s.MASP,
                            sp.TENSP,
                            s.MABH,
                            s.MAKM,                    
                            s.SOLUONGBAN,
                            s.DONGIABAN,
                            s.SIZEGIAY
                          });
            var kq = dulieu.ToList().ConvertAll(t => new tensanpham()
            {
                MACTHDB1=t.MACTHDB,
                MAHD1=t.MAHD,
                MASP1=t.MASP,
                TENSANPHAM1 = t.MASP,
                MABH1=t.MABH,
                MAKM1=t.MAKM,
                SLB1=Convert.ToInt32(t.SOLUONGBAN),
                DGB1 = Convert.ToDouble(t.DONGIABAN),
                SIZE1=Convert.ToInt32(t.SIZEGIAY)
            });
            return kq.ToList<tensanpham>();
        }
        public List<tensanpham> loadbangghepcthd()
        {
            var dulieu = (from s in data.CHITIETHOADONBANs
                          join sp in data.SANPHAMs on s.MASP equals (sp.MASP)
                          select new
                          {
                              s.MACTHDB,
                              s.MAHD,
                              s.MASP,
                              sp.TENSP,
                              s.MABH,
                              s.MAKM,
                              s.SOLUONGBAN,
                              s.DONGIABAN,
                              s.SIZEGIAY
                          });
            var kq = dulieu.ToList().ConvertAll(t => new tensanpham()
            {

                MACTHDB1 = t.MACTHDB,
                MAHD1 = t.MAHD,
                MASP1 = t.MASP,
                TENSANPHAM1 = t.MASP,
                MABH1 = t.MABH,
                MAKM1 = t.MAKM,
                SLB1 = Convert.ToInt32(t.SOLUONGBAN),
                DGB1 = Convert.ToDouble(t.DONGIABAN),
                SIZE1 = Convert.ToInt32(t.SIZEGIAY)
            });
            return kq.ToList<tensanpham>();
        }

        public List<CHITIETHOADONBAN> loadbangcthd_masp(string mahd)
        {
            var dulieu = (from s in data.CHITIETHOADONBANs where s.MAHD == mahd select s);
            return dulieu.ToList<CHITIETHOADONBAN>();
        }
        public bool ktkc(CHITIETHOADONBAN ma)
        {
            int r = data.CHITIETHOADONBANs.Count(t => t.MACTHDB == ma.MACTHDB.ToString());
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
        public bool them(CHITIETHOADONBAN pmh)
        {
            try
            {
                data.CHITIETHOADONBANs.InsertOnSubmit(pmh);
                data.SubmitChanges();
                return true;
            }
            catch(Exception e)
            {
                return false;
            }
        }
        public bool xoa(CHITIETHOADONBAN pmh)
        {
            try
            {
                CHITIETHOADONBAN mh = data.CHITIETHOADONBANs.Where(t => t.MACTHDB == pmh.MACTHDB.ToString()).FirstOrDefault();
                data.CHITIETHOADONBANs.DeleteOnSubmit(mh);
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
