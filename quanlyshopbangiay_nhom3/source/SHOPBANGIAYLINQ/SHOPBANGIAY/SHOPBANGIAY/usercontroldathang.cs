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
    public partial class usercontroldathang : UserControl
    {
        BLL_PHIEUDATHANG dathang_bll = new BLL_PHIEUDATHANG();
        BLL_CTPHIEUDATHANG ctpdh_bll = new BLL_CTPHIEUDATHANG();
        BLL_NCC ncc_bll = new BLL_NCC();
        BLL_SANPHAM sp_bll = new BLL_SANPHAM();
        BLL_GIAY lg_bll = new BLL_GIAY();
        string strNhan;
        public usercontroldathang()
        {
            InitializeComponent();
        }
        public string Message
        {
            get { return strNhan; }
            set { strNhan = value; }
        }
        private void usercontrolnhaphang_Load(object sender, EventArgs e)
        {
            txt_nvlap.Text = strNhan;
            dgv_phieudathang.DataSource = dathang_bll.loadbang_phieudathang();
            dgv_ctphieudathang.DataSource = ctpdh_bll.loadbang_ctphieudathang();
            cb_ncc.DataSource = ncc_bll.loadbang_ncc();
            cb_ncc.DisplayMember = "TENNCC";
            cb_ncc.ValueMember = "MANCC";
            
            cb_tensanpham.DataSource = sp_bll.loadbang_sanpham();
            cb_tensanpham.DisplayMember = "TENSP";
            cb_tensanpham.ValueMember = "MASP";

            cb_loaigiay.DataSource = lg_bll.loadbang_loaigiay();
            cb_loaigiay.DisplayMember = "TENLOAI";
            cb_loaigiay.ValueMember = "MALOAI";
        }

        private void dgv_phieudathang_SelectionChanged(object sender, EventArgs e)
        {
            if (dgv_phieudathang.CurrentRow.Cells[0].Value != null)
            {
                dgv_ctphieudathang.DataSource = ctpdh_bll.loadbang_ctphieudathang_maphieudat(dgv_phieudathang.CurrentRow.Cells[0].Value.ToString());
                txt_madh.Text = dgv_phieudathang.CurrentRow.Cells[0].Value.ToString();
            }
            cb_ncc.SelectedValue = dgv_phieudathang.CurrentRow.Cells[1].Value.ToString();
            //txt_nvlap.Text = dgv_phieudathang.CurrentRow.Cells[2].Value.ToString();
            dateEdit_NgayLap.Text = dgv_phieudathang.CurrentRow.Cells[3].Value.ToString();
            txt_tinhtranghang.Text = dgv_phieudathang.CurrentRow.Cells[5].Value.ToString();
            txt_tongslnhap.Text = dgv_phieudathang.CurrentRow.Cells[4].Value.ToString();
            txt_msp.Clear();
            txt_sizegiay.Clear();
            txt_sldat.Clear();

        }

        private void btn_lammoiddh_Click(object sender, EventArgs e)
        {
            
        }

        private void btn_lammoictddh_Click(object sender, EventArgs e)
        {
            dgv_ctphieudathang.DataSource = ctpdh_bll.loadbang_ctphieudathang();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            PHIEUDATHANGNCC pdh = new PHIEUDATHANGNCC();
            int b = 0;
            for (int i = 1; i <= dgv_phieudathang.RowCount; i++)
            {
                b = i;
            }
            pdh.SODONHANG = "DH" + (b+1).ToString();
            pdh.MANCC = cb_ncc.SelectedValue.ToString();
            pdh.MANV = txt_nvlap.Text.ToString();
            pdh.NGAYLAP = Convert.ToDateTime(dateEdit_NgayLap.Text.ToString());
            pdh.TONGSOLUONGNHAP = Convert.ToInt32(txt_tongslnhap.Text.ToString());
            pdh.TINHTRANGHANG = "Chưa giao hàng";
            if (dathang_bll.ktkc(pdh) == true)
            {
                if (dathang_bll.thempdh(pdh) == true)
                {
                    MessageBox.Show("thêm thành công");
                    dgv_phieudathang.DataSource = dathang_bll.loadbang_phieudathang();
                }
                else
                {
                    MessageBox.Show("thất bại");

                }
            }
            else
            {
                MessageBox.Show("Đơn đặt hảng này đã tồn tại");
            }
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            try
            {
                PHIEUDATHANGNCC pdh = new PHIEUDATHANGNCC();
                pdh.SODONHANG = dgv_phieudathang.CurrentRow.Cells[0].Value.ToString();
                if (dathang_bll.ktkc(pdh) == true)
                {
                    MessageBox.Show("giá trị không tồn tại");
                    return;
                }
                if (dathang_bll.xoapdh(pdh) == true)
                {
                    MessageBox.Show("thành công");
                    dgv_phieudathang.DataSource = dathang_bll.loadbang_phieudathang();
                }
                else
                {
                    if (dathang_bll.xoapdh(pdh) == false)
                    {
                        DialogResult dr = MessageBox.Show("Hệ thống phát hiện thực hiện thao tác này sẽ xóa tất cả dữ liệu chi tiết đặt hàng?", "Xác nhận hủy", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (dr == DialogResult.Yes)
                        {
                            try
                            {
                                CTPHIEUDATHANGNCC ctpdh = new CTPHIEUDATHANGNCC();
                                ctpdh.SODONHANG = dgv_ctphieudathang.CurrentRow.Cells[1].Value.ToString();
                                if (ctpdh_bll.xoactpdh_maphieudathang(ctpdh) == true)
                                {                           
                                    if (dathang_bll.xoapdh(pdh) == true)
                                    {
                                        dgv_ctphieudathang.DataSource = ctpdh_bll.loadbang_ctphieudathang();
                                        dgv_phieudathang.DataSource = dathang_bll.loadbang_phieudathang();
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("xảy ra lỗi");
                                }
                            }
                            catch
                            {
                                MessageBox.Show("xảy ra lỗi");
                            }
                        }
                        else
                            return;
                    }
                }
            }
            catch
            {
                MessageBox.Show("xảy ra lỗi");
            }
        }

        private void btnsua_Click(object sender, EventArgs e)
        {

            try
            {
                PHIEUDATHANGNCC pdh = new PHIEUDATHANGNCC();
                pdh.SODONHANG = txt_madh.Text.ToString();
                pdh.MANCC = cb_ncc.SelectedValue.ToString();
                pdh.MANV = txt_nvlap.Text.ToString();
                pdh.NGAYLAP = Convert.ToDateTime(dateEdit_NgayLap.Text.ToString());
                pdh.TONGSOLUONGNHAP = Convert.ToInt32(txt_tongslnhap.Text.ToString());
                pdh.TINHTRANGHANG = txt_tinhtranghang.Text.ToString();
                if (dathang_bll.ktkc(pdh) == true)
                {
                    MessageBox.Show("giá trị không tồn tại");
                    return;
                }

                if (dathang_bll.suapdh(pdh) == true)
                {
                    MessageBox.Show("thành công");
                    dgv_phieudathang.DataSource = dathang_bll.loadbang_phieudathang();
                }
                else
                {
                    MessageBox.Show("xảy ra lỗi");
                }
            }
            catch
            {
                MessageBox.Show("xảy ra lỗi");
            }
        }

        private void dgv_ctphieudathang_SelectionChanged(object sender, EventArgs e)
        {
            if (dgv_ctphieudathang.CurrentRow != null)
            {
                txt_msp.Text = dgv_ctphieudathang.CurrentRow.Cells[2].Value.ToString();
                txt_sizegiay.Text = dgv_ctphieudathang.CurrentRow.Cells[3].Value.ToString();
                txt_sldat.Text = dgv_ctphieudathang.CurrentRow.Cells[4].Value.ToString();
            }
        }

        private void txt_msp_TextChanged(object sender, EventArgs e)
        {
            if (txt_msp.Text!= null)
            {
                try
                {
                    cb_tensanpham.SelectedValue = txt_msp.Text.ToString();
                }
                catch
                {
                    return;
                }
            }
            else
            {
               // MessageBox.Show("Sản phẩm không kinh doanh tại cửa hàng! vui lòng liên hệ với cấp trên để giải quyết");
                return;
            }
            
        }

        private void cb_tensanpham_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cb_tensanpham.SelectedValue!= null)
            {
                txt_msp.Text = cb_tensanpham.SelectedValue.ToString();
            }
        }

        private void cb_loaigiay_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cb_loaigiay.SelectedValue != null)
            {
                if (sp_bll.loadbang_sanpham_masp(cb_loaigiay.SelectedValue.ToString()) != null)
                {
                    cb_tensanpham.DataSource = sp_bll.loadbang_sanpham_masp(cb_loaigiay.SelectedValue.ToString());
                    cb_tensanpham.DisplayMember = "TENSP";
                    cb_tensanpham.ValueMember = "MASP";
                }
                else
                {
                    cb_tensanpham.Items.Clear();
                    cb_tensanpham.Text = null;
                    cb_tensanpham.DisplayMember = null;
                    cb_tensanpham.ValueMember = null;
                }
            }
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            CTPHIEUDATHANGNCC ctpdh = new CTPHIEUDATHANGNCC();
            ctpdh.SODONHANG = dgv_phieudathang.CurrentRow.Cells[0].Value.ToString();
            ctpdh.MASP = txt_msp.Text.ToString();
            ctpdh.COSIZE = Convert.ToInt32(txt_sizegiay.Text.ToString());
            ctpdh.SOLUONG = Convert.ToInt32(txt_sldat.Text.ToString());
            if (ctpdh_bll.ktkc(ctpdh) == true)
            {
                if (ctpdh_bll.themctpdh(ctpdh) == true)
                {
                    MessageBox.Show("thêm thảnh công");
                    dgv_ctphieudathang.DataSource = ctpdh_bll.loadbang_ctphieudathang_maphieudat(dgv_phieudathang.CurrentRow.Cells[0].Value.ToString());

                }
                else
                {
                    MessageBox.Show("thất bại");
                }
            }
            else
            {
                MessageBox.Show("Đơn đặt hảng này đã tồn tại");
            }
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            try
            {
                CTPHIEUDATHANGNCC ctpdh = new CTPHIEUDATHANGNCC();
                ctpdh.SODONHANG = dgv_ctphieudathang.CurrentRow.Cells[1].Value.ToString();
                ctpdh.MASP = dgv_ctphieudathang.CurrentRow.Cells[2].Value.ToString();
                ctpdh.COSIZE = Convert.ToInt32(txt_sizegiay.Text.ToString());
               
                if (ctpdh_bll.ktkc(ctpdh) == true)
                {
                    MessageBox.Show("giá trị không tồn tại");
                    return;
                }
                if (ctpdh_bll.xoactpdh(ctpdh) == true)
                {
                    MessageBox.Show("thành công");
                    dgv_ctphieudathang.DataSource = ctpdh_bll.loadbang_ctphieudathang();
                }
                else
                {
                    MessageBox.Show("xảy ra lỗi");
                }
            }
            catch
            {
                MessageBox.Show("xảy ra lỗi");
            }
        }

        private void buttonX4_Click(object sender, EventArgs e)
        {
            dgv_ctphieudathang.DataSource = ctpdh_bll.loadbang_ctphieudathang();
        }

        private void buttonX3_Click(object sender, EventArgs e)
        {
            try
            {
                CTPHIEUDATHANGNCC ctpdh = new CTPHIEUDATHANGNCC();
                ctpdh.SODONHANG = dgv_phieudathang.CurrentRow.Cells[0].Value.ToString();
                ctpdh.MASP = txt_msp.Text.ToString();
                ctpdh.COSIZE = Convert.ToInt32(txt_sizegiay.Text.ToString());
                ctpdh.SOLUONG = Convert.ToInt32(txt_sldat.Text.ToString());
                if (ctpdh_bll.ktkc(ctpdh) == true)
                {
                    MessageBox.Show("giá trị không tồn tại");
                    return;
                }

                if (ctpdh_bll.suactpdh(ctpdh) == true)
                {
                    MessageBox.Show("thành công");
                    dgv_ctphieudathang.DataSource = ctpdh_bll.loadbang_ctphieudathang_maphieudat(dgv_phieudathang.CurrentRow.Cells[0].Value.ToString());
                }
                else
                {
                    MessageBox.Show("xảy ra lỗi");
                }
            }
            catch
            {
                MessageBox.Show("xảy ra lỗi");
            }
        }

     
       
    }
}
