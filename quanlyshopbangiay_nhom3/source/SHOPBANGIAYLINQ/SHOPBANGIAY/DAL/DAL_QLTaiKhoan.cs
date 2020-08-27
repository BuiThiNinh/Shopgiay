using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_QLTaiKhoan
    {
        DataClasses1DataContext data = new DataClasses1DataContext();

        public List<QLNHOMND> load_NhomND()
        {
            var dulieu = (from s in data.QLNHOMNDs select s);
            return dulieu.ToList<QLNHOMND>();
        }
        public List<QUANLYND> loadbangQUANLYND()
        {
            var dulieu = (from s in data.QUANLYNDs select s);
            return dulieu.ToList<QUANLYND>();
        }

        public List<GhepBang_NDnhomND> Load_NDnhomND()
        {
            var taikhoannhom = from s in data.QLNDNHOMNDs
                            join q in data.QLNHOMNDs on s.MANHOM equals (q.MANHOM)
                            select new
                            {
                                s.TENDN,
                                q.TENNHOMND,
                                s.GHICHU
                            };
            var kq = taikhoannhom.ToList().ConvertAll(t => new GhepBang_NDnhomND()
            {
                TENDN1 = t.TENDN,
                TENNHOMND1 = t.TENNHOMND,
                GHICHU1 = t.GHICHU
            });
            return kq.ToList<GhepBang_NDnhomND>();
        }
         public bool ktkc(QUANLYND ma)
        {
            int r = data.QUANLYNDs.Count(t => t.TENDN == ma.TENDN.ToString() );
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
        public bool them(QUANLYND pmh)
        {
            try
            {
                data.QUANLYNDs.InsertOnSubmit(pmh);
                data.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        
        public bool sua(QUANLYND pmh)
        {
            try
            {
                QUANLYND thanhvien = data.QUANLYNDs.Where(t => t.TENDN == pmh.TENDN.ToString()).FirstOrDefault();
                thanhvien.MK = pmh.MK;
                data.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool sua1(QUANLYND pmh)
        {
            try
            {
                QUANLYND thanhvien = data.QUANLYNDs.Where(t => t.TENDN == pmh.TENDN.ToString()).FirstOrDefault();
                thanhvien.HOATDONG = pmh.HOATDONG;
                data.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool xoa(QUANLYND pmh)
        {
            try
            {
                QUANLYND mh = data.QUANLYNDs.Where(t => t.TENDN == pmh.TENDN.ToString()).FirstOrDefault();
                data.QUANLYNDs.DeleteOnSubmit(mh);
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

