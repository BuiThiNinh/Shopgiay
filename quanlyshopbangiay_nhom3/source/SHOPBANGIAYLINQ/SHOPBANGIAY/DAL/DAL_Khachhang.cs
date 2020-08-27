using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
  public   class DAL_Khachhang
    {
      DataClasses1DataContext da = new DataClasses1DataContext();
      public List<KHACHHANG> loadsp()
      {
          return da.KHACHHANGs.Select(t => t).ToList<KHACHHANG>();
      }

      public String laymakh(string sdt)
      {
          try
          {
              var kt = (from k in da.KHACHHANGs where k.SDTKHACHHANG == Convert.ToInt32(sdt) select k.MAKH).FirstOrDefault();
              return kt.ToString();
          }
          catch
          {
              return null;
          }

      }
      public string sinhmakh()
      {
          return da.SINHMA();
      }
      public String laymakh1(string makh)
      {
          try
          {
              var kt = (from k in da.KHACHHANGs where k.MAKH == makh select k.SDTKHACHHANG).FirstOrDefault();
              return kt.ToString();
          }
          catch
          {
              return null;
          }

      }
      public bool ktkc_kh(string ma)
      {
          var kt = (from k in da.KHACHHANGs where k.MAKH == ma select k).Count();
          if (kt > 0)
          {
              return true;
          }
          else
          {
              return false;
          }
          
      }
      public bool them(KHACHHANG pmh)
        {
            try
            {
                da.KHACHHANGs.InsertOnSubmit(pmh);
                da.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }


        public bool sua(KHACHHANG pmh)
        {
            try
            {
                KHACHHANG thanhvien = da.KHACHHANGs.Where(t => t.MAKH == pmh.MAKH.ToString()).FirstOrDefault();
                thanhvien.SDTKHACHHANG = pmh.SDTKHACHHANG;
                thanhvien.MAIL = pmh.MAIL;
                thanhvien.DIACHIKH = pmh.DIACHIKH;
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
