using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL;
using BLL;

namespace SHOPBANGIAY
{
    public partial class usercontrol_banhang : UserControl
    {
        BLL_HDB bll_hdb = new BLL_HDB();
        BLL_CTHD bll_cthd = new BLL_CTHD();
        BLL_GIAY bll_lg = new BLL_GIAY();
        BLL_SANPHAM bll_sp = new BLL_SANPHAM();
        BLL_SIZEGIAY sg_bll = new BLL_SIZEGIAY();
        BILL_KhachHang kh_bll = new BILL_KhachHang();
        BLL_KHUYENMAI km_bll = new BLL_KHUYENMAI();
        BLL_BAOHANH bh_bll = new BLL_BAOHANH();
        BLL_Kho kho_bll = new BLL_Kho();
        BLL_BANGGIA bll_bangia = new BLL_BANGGIA();
        string strNhan;
        public usercontrol_banhang()
        {
            InitializeComponent();
        }
        public string Message
        {
            get { return strNhan; }
            set { strNhan = value; }
        }
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                groupBox5.Enabled = true;
                label10.Enabled = txt_kvl.Enabled = false;
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                groupBox5.Enabled = false;
                label10.Enabled = txt_kvl.Enabled = true;

                txt_kvl.Text = "KHVL" + sinhmakhvl();
            }
        }

        private String sinhmakhvl()
        {
            int b = 0;
            for (int i = 1; i <= dgv_hdb.RowCount; i++)
            {
                b = i;
            }
            return (b + 1).ToString();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            Double t=0;
            HOADONBAN hdb = new HOADONBAN();
            int b = 0;
            for (int i = 1; i <= dgv_hdb.RowCount; i++)
            {
                b = i;
            }
            hdb.MAHD = "HDB" + (b + 1).ToString();
            hdb.NGAYLAP = Convert.ToDateTime(dateEdit_NgayLap.Text.ToString());
            hdb.MANV = txt_nvlap.Text.ToString();
            hdb.TONGTIEN = 0;
            if(radioButton1.Checked==true)
            {
                hdb.MAKHTT=txt_khtt.Text.ToString();
                t=Convert.ToDouble(txt_chietkhau.Text.ToString());
            }
            else
            {
                t = 0;
                hdb.KHVANGLAI =txt_kvl.Text.ToString();
            }
            hdb.CHIECKHAU = t;
            if (bll_hdb.ktkc_hdb(hdb) == true)
            {
                if (bll_hdb.themhdb(hdb) == true)
                {
                    MessageBox.Show("thêm thành công");
                    dgv_hdb.DataSource = bll_hdb.loadbang_hdb();
                }
                else
                {
                    MessageBox.Show("thất bại");

                }
            }
            else
            {
                MessageBox.Show("hóa đơn hảng này đã tồn tại");
            }
        }

        private void txt_chietkhau_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToDouble(txt_chietkhau.Text.ToString()) > 1)
                {
                    MessageBox.Show("giá trị nhâp từ 0->1");
                    return;
                }
            }
            catch
            {
                return;
            }
        }

        private void usercontrol_banhang_Load(object sender, EventArgs e)
        {
            txt_nvlap.Text = strNhan;
            cb_loaigiay.DataSource = bll_lg.loadbang_loaigiay();
            cb_loaigiay.DisplayMember = "TENLOAI";
            cb_loaigiay.ValueMember = "MALOAI";

            cb_tensanpham.DataSource = bll_sp.loadbang_sanpham();
            cb_tensanpham.DisplayMember = "TENSP";
            cb_tensanpham.ValueMember = "MASP";

            dateEdit_NgayLap.Text = DateTime.Now.ToString();

            dgv_hdb.DataSource = bll_hdb.loadbang_hdb();
            dgv_cthdb.DataSource = bll_cthd.loadbangghep_cthd();
            txt_kvl.Text = "KHVL" + sinhmakhvl();
        }

        private void cb_tensanpham_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cb_tensanpham.SelectedValue != null)
            {
                txt_msp.Text = cb_tensanpham.SelectedValue.ToString();
                try
                {
                    if (txt_msp.Text.Length > 0)
                    {
                        cb_sizegiay.DataSource = sg_bll.loadsizegiay(txt_msp.Text.ToString()); 
                        txt_gia.Text = bll_bangia.giabansp(cb_tensanpham.SelectedValue.ToString()).ToString();
                        cb_sizegiay.DisplayMember = "SIZE";
                       

                    }
                    else
                    {
                        cb_sizegiay.DisplayMember = null;
                        cb_sizegiay.ValueMember = null;
                    }
                }
                catch
                {
                    cb_sizegiay.DisplayMember = null;
                    cb_sizegiay.ValueMember = null;
                    return;
                }

            }
        }

        private void cb_loaigiay_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                cb_tensanpham.DataSource = bll_sp.loadbang_sanpham_masp(cb_loaigiay.SelectedValue.ToString());
                cb_tensanpham.DisplayMember = "TENSP";
                cb_tensanpham.ValueMember = "MASP";
                if (cb_tensanpham.SelectedValue == null)
                {
                    cb_tensanpham.DisplayMember = null;
                    txt_msp.Text = null;
                }
            }
            catch
            {
                txt_msp.Text = null;
                return;
            }
        }

        private void buttonX4_Click(object sender, EventArgs e)
        {
            dgv_cthdb.DataSource = bll_cthd.loadbangghep_cthd();
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            try
            {
            Double t = 0;
            CHITIETHOADONBAN hdb = new CHITIETHOADONBAN();
            
            int b = 0;
            for (int i = 1; i <= dgv_cthdb.RowCount; i++)
            {
                b = i;
            }
            hdb.MACTHDB = "CTHD" + (b + 1).ToString() + DateTime.Now.Second.ToString();
            hdb.MAHD = dgv_hdb.CurrentRow.Cells[0].Value.ToString();
            hdb.MASP = txt_msp.Text.ToString();
            PHIEUBAOHANH pbh = new PHIEUBAOHANH();
            String tem = DateTime.Now.ToString();
            pbh.MABH = tem;
            pbh.MASP = txt_msp.Text.ToString();
            pbh.NGAYHETHANDOITRA = DateTime.Now.AddDays(7);
            hdb.MAKM = null;
            hdb.SOLUONGBAN = Convert.ToInt32(txt_sldat.Text.ToString());
            hdb.DONGIABAN = bll_hdb.laygiasp(txt_msp.Text.ToString());
            Double money = Convert.ToDouble(txt_sldat.Text.ToString()) * Convert.ToDouble(txt_gia.Text.ToString());
            hdb.SIZEGIAY = Convert.ToInt32(cb_sizegiay.Text.ToString());
            KHO kh = new KHO();
            kh.MASP = txt_msp.Text.ToString();
            int ktkho = bll_hdb.capnhatkho(txt_msp.Text.ToString(), Convert.ToInt32(txt_sldat.Text.ToString()));
            if (ktkho >= 0)
            {
                kh.SOLUONG = ktkho;
            }
            else
            {
                MessageBox.Show("số lượng không đủ");
                return;
            }
            if (bh_bll.thempbh(pbh) == true)
            {
                MessageBox.Show("thêm phiếu bảo hành thành công");
                hdb.MABH = tem;
            }
            else
            {
                hdb.MABH = null;
            }
                if (bll_cthd.themcthd(hdb) == true)
                {
                    MessageBox.Show("thêm thành công");
                    dgv_cthdb.DataSource = bll_cthd.loadbangghep_cthd();
                     if (kho_bll.ktkc_kho(kh) == false)
                     {
                         if (kho_bll.suakho(kh) == true)
                         {
                             MessageBox.Show("cập nhật kho thành công");
                         }
                     }
                     Double tt = 0;
                     HOADONBAN hdb1 = new HOADONBAN();
                     hdb1.MAHD = txt_mahd.Text.ToString();
                     hdb1.NGAYLAP = Convert.ToDateTime(dateEdit_NgayLap.Text.ToString());
                     hdb1.MANV = txt_nvlap.Text.ToString();
                     
                     if (radioButton1.Checked == true)
                     {
                         hdb1.MAKHTT = txt_khtt.Text.ToString();
                         tt = Convert.ToDouble(txt_chietkhau.Text.ToString());
                         hdb1.TONGTIEN = (Convert.ToDouble(txt_tinhtranghang.Text.ToString()) + (money - (money * Convert.ToDouble(txt_mucgiam.Text.ToString()))))-(Convert.ToDouble(txt_tinhtranghang.Text.ToString()) + (money - (money * Convert.ToDouble(txt_mucgiam.Text.ToString())))) * tt;
                     }
                     else
                     {
                         tt = 0;
                         hdb1.TONGTIEN = Convert.ToDouble(txt_tinhtranghang.Text.ToString()) + (money-(money*Convert.ToDouble(txt_mucgiam.Text.ToString())));
                         hdb1.KHVANGLAI = txt_kvl.Text.ToString();
                     }
                     hdb1.CHIECKHAU = tt;
                     if (bll_hdb.ktkc_hdb(hdb1) == false)
                     {
                         if (bll_hdb.suahdb(hdb1) == true)
                         {
                             MessageBox.Show("sửa thành công");
                             dgv_hdb.DataSource = bll_hdb.loadbang_hdb();
                         }
                         else
                         {
                             MessageBox.Show("thất bại");

                         }
                     }
                     else
                     {
                         MessageBox.Show("hóa đơn này chưa tồn tại");
                     }
                }
                else
                {
                    MessageBox.Show("thất bại");

                }
            }
            catch
            {
                return;
            }
        }

        private void txt_khtt_TextChanged(object sender, EventArgs e)
        {
            if (txt_khtt.Text.Length > 0 && txt_khtt.Text.Length <= 10)
            {
                txt_sdt.Text = kh_bll.makh1(txt_khtt.Text.ToString());
            }
        }

        private void txt_sdt_TextChanged(object sender, EventArgs e)
        {
            if (txt_sdt.Text.Length > 0 && txt_sdt.Text.Length <= 10)
            {
                txt_khtt.Text = kh_bll.makh(txt_sdt.Text.ToString());
            }

        }

        private void txt_msp_TextChanged(object sender, EventArgs e)
        {
            if (txt_msp.Text.Length > 0)
            {
                try
                {
                    cb_khuyenmai.DataSource = km_bll.loadbang_km(txt_msp.Text.ToString());
                    cb_khuyenmai.DisplayMember = "TENKM";
                    cb_khuyenmai.ValueMember = "MAKM";
                    cb_sizegiay.DataSource = sg_bll.loadsizegiay(txt_msp.Text.ToString());
                    cb_sizegiay.DisplayMember = "SIZE";
                    cb_sizegiay.ValueMember = "MASP";
                    txt_gia.Text = bll_hdb.laygiasp(txt_msp.Text.ToString()).ToString();
                }
                catch
                {
                    cb_khuyenmai.DisplayMember = null;
                    cb_khuyenmai.ValueMember = null;
                    return;
                }
            }
            else
            {
                cb_khuyenmai.DisplayMember = null;
                cb_khuyenmai.ValueMember = null;
                cb_sizegiay.DisplayMember =null;
                cb_sizegiay.ValueMember = null;
            }
        }

        private void cb_khuyenmai_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                cb_khuyenmai.DataSource = km_bll.loadbang_km(txt_msp.Text.ToString());
                cb_khuyenmai.DisplayMember = "TENKM";
                cb_khuyenmai.ValueMember = "MAKM";
                if (cb_khuyenmai.SelectedValue != null)
                {
                    txt_mucgiam.Text = (km_bll.loadbang_km1(cb_khuyenmai.SelectedValue.ToString())).ToString();
                }
                else
                {
                    txt_mucgiam.Text = "0";
                }
            }
            catch
            {
                return;
            }
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            Double t = 0;
            HOADONBAN hdb = new HOADONBAN();
            hdb.MAHD = txt_mahd.Text.ToString();
            hdb.NGAYLAP = Convert.ToDateTime(dateEdit_NgayLap.Text.ToString());
            hdb.MANV = txt_nvlap.Text.ToString();
            hdb.TONGTIEN = 0;
            if (radioButton1.Checked == true)
            {
                hdb.MAKHTT = txt_khtt.Text.ToString();
                t = Convert.ToDouble(txt_chietkhau.Text.ToString());
            }
            else
            {
                t = 0;
                hdb.KHVANGLAI = txt_kvl.Text.ToString();
            }
            hdb.CHIECKHAU = t;
            if (bll_hdb.ktkc_hdb(hdb) == false)
            {
                if (bll_hdb.suahdb(hdb) == true)
                {
                    MessageBox.Show("sửa thành công");
                    dgv_hdb.DataSource = bll_hdb.loadbang_hdb();
                }
                else
                {
                    MessageBox.Show("thất bại");

                }
            }
            else
            {
                MessageBox.Show("hóa đơn hảng này chưa tồn tại");
            }
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            HOADONBAN nhomnd = new HOADONBAN();
            nhomnd.MAHD = txt_mahd.Text.ToString();
            if (bll_hdb.ktkc_hdb(nhomnd) == false)
            {
                if (bll_hdb.xoahdb(nhomnd) == true)
                {
                    MessageBox.Show("xóa thành công");
                    dgv_hdb.DataSource = bll_hdb.loadbang_hdb();
                }
                else
                {
                    MessageBox.Show("bạn không có quyền xóa");

                }
            }
            else
            {
                MessageBox.Show("nhóm không tồn tại");
            }
        }

        private void dgv_hdb_SelectionChanged(object sender, EventArgs e)
        {
            if (dgv_hdb.CurrentRow != null)
            {
                txt_sdt.Clear();
                txt_mahd.Text = dgv_hdb.CurrentRow.Cells[0].Value.ToString();
                dateEdit_NgayLap.Text = dgv_hdb.CurrentRow.Cells[1].Value.ToString();
                //txt_nvlap.Text = dgv_hdb.CurrentRow.Cells[2].Value.ToString();
                txt_tinhtranghang.Text = dgv_hdb.CurrentRow.Cells[3].Value.ToString();
                if (dgv_hdb.CurrentRow.Cells[4].Value!=null)
                {
                    txt_khtt.Text = dgv_hdb.CurrentRow.Cells[4].Value.ToString();
                    txt_chietkhau.Text = dgv_hdb.CurrentRow.Cells[6].Value.ToString();
                    txt_kvl.Text = null;
                }
                else
                {
                    txt_kvl.Text = dgv_hdb.CurrentRow.Cells[5].Value.ToString();
                    txt_khtt.Text = null;
                    txt_chietkhau.Text = null;
                }
                dgv_cthdb.DataSource = bll_cthd.loadbangghep_cthd_mhd(dgv_hdb.CurrentRow.Cells[0].Value.ToString());
            }
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            try
            {
                Double t = 0;
                CHITIETHOADONBAN hdb = new CHITIETHOADONBAN();


                hdb.MACTHDB = dgv_cthdb.CurrentRow.Cells[0].Value.ToString();
                hdb.MAHD = dgv_cthdb.CurrentRow.Cells[1].Value.ToString();
                hdb.MASP = dgv_cthdb.CurrentRow.Cells[2].Value.ToString();
                PHIEUBAOHANH pbh = new PHIEUBAOHANH();
               
                pbh.MABH = dgv_cthdb.CurrentRow.Cells[4].Value.ToString();
                Double money = Convert.ToDouble(dgv_cthdb.CurrentRow.Cells[6].Value.ToString()) * Convert.ToDouble(dgv_cthdb.CurrentRow.Cells[7].Value.ToString());
                
                KHO kh = new KHO();
                kh.MASP = dgv_cthdb.CurrentRow.Cells[2].Value.ToString();
                int ktkho = bll_hdb.capnhatkho1(dgv_cthdb.CurrentRow.Cells[2].Value.ToString(), Convert.ToInt32(dgv_cthdb.CurrentRow.Cells[6].Value.ToString()));
                
                kh.SOLUONG = ktkho;
                
                
                
                if (bll_cthd.xoacthdb(hdb) == true)
                {
                    MessageBox.Show("xóa thành công");
                    dgv_cthdb.DataSource = bll_cthd.loadbangghep_cthd();
                    if (bh_bll.xoapbh(pbh) == true)
                    {
                        MessageBox.Show("xóa phiếu bảo hành thành công");

                    }
                    else
                    {
                        MessageBox.Show("xóa phiếu bảo hành thất bại");

                    }
                    if (kho_bll.ktkc_kho(kh) == false)
                    {
                        if (kho_bll.suakho(kh) == true)
                        {
                            MessageBox.Show("cập nhật kho thành công");
                        }
                    }
                    Double tt = 0;
                    HOADONBAN hdb1 = new HOADONBAN();
                    hdb1.MAHD = txt_mahd.Text.ToString();
                    hdb1.NGAYLAP = Convert.ToDateTime(dateEdit_NgayLap.Text.ToString());
                    hdb1.MANV = txt_nvlap.Text.ToString();

                    if (radioButton1.Checked == true)
                    {
                        hdb1.MAKHTT = txt_khtt.Text.ToString();
                        tt = Convert.ToDouble(txt_chietkhau.Text.ToString());
                        Double gtbd = (1 - Convert.ToDouble(txt_mucgiam.Text.ToString())) / Convert.ToDouble(txt_tinhtranghang.Text.ToString());

                        hdb1.TONGTIEN = (gtbd - (money - (money * Convert.ToDouble(txt_mucgiam.Text.ToString())))) - (gtbd + (money - (money * Convert.ToDouble(txt_mucgiam.Text.ToString())))) * tt;
                    }
                    else
                    {
                        tt = 0;
                        hdb1.TONGTIEN = Convert.ToDouble(txt_tinhtranghang.Text.ToString()) - (money - (money * Convert.ToDouble(txt_mucgiam.Text.ToString())));
                        hdb1.KHVANGLAI = txt_kvl.Text.ToString();
                    }
                    hdb1.CHIECKHAU = tt;
                    if (bll_hdb.ktkc_hdb(hdb1) == false)
                    {
                        if (bll_hdb.suahdb(hdb1) == true)
                        {
                            MessageBox.Show("sửa thành công");
                            dgv_hdb.DataSource = bll_hdb.loadbang_hdb();
                        }
                        else
                        {
                            MessageBox.Show("thất bại");

                        }
                    }
                    else
                    {
                        MessageBox.Show("hóa đơn này chưa tồn tại");
                    }
                }
                else
                {
                    MessageBox.Show("thất bại");

                }
            }
            catch
            {
                return;
            }
        }
        }
  }
