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
    public partial class usercontrol_nhaphang : UserControl
    {
        
        BLL_PN bll_pn = new BLL_PN();
        BLL_CTPN bll_ctpn = new BLL_CTPN();
        BLL_PHIEUDATHANG pdh = new BLL_PHIEUDATHANG();
        BLL_Kho kho_bll = new BLL_Kho();
        BLL_HDB bll_hdb = new BLL_HDB();
        BLL_SANPHAM sp = new BLL_SANPHAM();
        string strNhan;
        public usercontrol_nhaphang()
        {
            InitializeComponent();
        }
        public string Message
        {
            get { return strNhan; }
            set { strNhan = value; }
        }
        private void usercontrol_nhaphang_Load(object sender, EventArgs e)
        {
            txt_nvlap.Text = strNhan;
            dateEdit_NgayLap.Text = DateTime.Now.ToString();
            comboBox1.DataSource = sp.loadbang_sanpham();
            comboBox1.DisplayMember = "TENSP";
            comboBox1.ValueMember = "MASP";
            dgv_pn.DataSource = bll_pn.loadbang_PN();
            dgv_ctpn.DataSource = bll_ctpn.loadbang_ctpn();
            
        }

        private void dateEdit_ngaydat_EditValueChanged(object sender, EventArgs e)
        {
           
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            PHIEUNHAP hdb = new PHIEUNHAP();
            
            int b = 0;
            for (int i = 1; i <= dgv_pn.RowCount; i++)
            {
                b = i;
            }
            hdb.MAPN = "PN" + (b + 1).ToString();
            hdb.MANV = txt_nvlap.Text.ToString();
            hdb.NGAYNHAP = Convert.ToDateTime(dateEdit_NgayLap.Text.ToString());
            hdb.SODONHANG = txt_sdh.Text.ToString();
            hdb.TONGTIENNHAP = 0;
            
            if (bll_pn.ktkc(hdb) == true)
            {
                if (bll_pn.thempn(hdb) == true)
                {
                    MessageBox.Show("thêm thành công");
                    dgv_pn.DataSource = bll_pn.loadbang_PN();
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

        private void btnxoa_Click(object sender, EventArgs e)
        {
            PHIEUNHAP nhomnd = new PHIEUNHAP();
            nhomnd.MAPN = txt_mpn.Text.ToString();
            if (bll_pn.ktkc(nhomnd) == false)
            {
                if (bll_pn.xoapn(nhomnd) == true)
                {
                    MessageBox.Show("xóa thành công");
                    dgv_pn.DataSource = bll_pn.loadbang_PN();
                }
                else
                {
                    MessageBox.Show("bạn không có quyền xóa");

                }
            }
            else
            {
                MessageBox.Show(" không tồn tại");
            }
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            PHIEUNHAP hdb = new PHIEUNHAP();
            hdb.MAPN = dgv_pn.CurrentRow.Cells[0].Value.ToString();
            hdb.MANV = txt_nvlap.Text.ToString();
            hdb.NGAYNHAP = Convert.ToDateTime(dgv_pn.CurrentRow.Cells[3].Value.ToString());
            hdb.SODONHANG = dgv_pn.CurrentRow.Cells[2].Value.ToString();
            hdb.TONGTIENNHAP = Convert.ToDouble(dgv_pn.CurrentRow.Cells[4].Value.ToString());
            if (bll_pn.ktkc(hdb) == false)
            {
                if (bll_pn.suapn(hdb) == true)
                {
                    MessageBox.Show("sửa thành công");
                    dgv_pn.DataSource = bll_pn.loadbang_PN();
                }
                else
                {
                    MessageBox.Show("thất bại");

                }
            }
            else
            {
                MessageBox.Show("không tồn tại");
            }
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            CHITIETPHIEUNHAP hdb = new CHITIETPHIEUNHAP();
            PHIEUNHAP PN = new PHIEUNHAP();
            KHO kh = new KHO();
            int b = 0;
            Double money=0;
            for (int i = 1; i <= dgv_ctpn.RowCount; i++)
            {
                b = i;
            }
            hdb.MACTPN = "CTPN" + (b + 1).ToString()+DateTime.Now.Second.ToString();
            hdb.MAPN = dgv_pn.CurrentRow.Cells[0].Value.ToString();
            PN.MAPN=hdb.MAPN;
            PN.MANV=txt_nvlap.Text.ToString();
            PN.SODONHANG=dgv_pn.CurrentRow.Cells[2].Value.ToString();
            PN.NGAYNHAP=Convert.ToDateTime(dgv_pn.CurrentRow.Cells[3].Value.ToString());
            hdb.MASP = txt_msp.Text.ToString();
            kh.MASP = hdb.MASP;
            hdb.SOLUONGSP = Convert.ToInt32(txt_slsp.Text.ToString());

            int ktkho = bll_hdb.capnhatkho1(txt_msp.Text.ToString(), Convert.ToInt32(txt_slsp.Text.ToString()));

            kh.SOLUONG = ktkho;
            hdb.GIATIEN = Convert.ToDouble(txt_gia.Text.ToString());
            money=Convert.ToDouble(dgv_pn.CurrentRow.Cells[4].Value.ToString())+(Convert.ToDouble(txt_slsp.Text.ToString())* Convert.ToDouble(txt_gia.Text.ToString()));
            PN.TONGTIENNHAP=money;

            if (bll_ctpn.ktkc_CTPN(hdb) == true)
            {
                if (bll_ctpn.themctpn(hdb) == true)
                {
                    MessageBox.Show("thêm thành công");
                    dgv_ctpn.DataSource = bll_ctpn.loadbang_ctpn();
                    if (kho_bll.ktkc_kho(kh) == false)
                    {
                        if (kho_bll.suakho(kh) == true)
                        {
                            MessageBox.Show("cập nhật kho thành công");
                        }
                    }
                    if (bll_pn.ktkc(PN) == false)
                    {
                        if (bll_pn.suapn(PN) == true)
                        {
                            MessageBox.Show("sửa thành công");
                            dgv_pn.DataSource = bll_pn.loadbang_PN();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("thất bại");

                }
            }
            else
            {
                MessageBox.Show("hóa đơn này đã tồn tại");
            }
        }

        private void dgv_pn_SelectionChanged(object sender, EventArgs e)
        {
            dgv_ctpn.DataSource = bll_ctpn.loadbang_ctpn_sp(dgv_pn.CurrentRow.Cells[0].Value.ToString());
        }

        private void groupBox5_Enter(object sender, EventArgs e)
        {

        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            PHIEUNHAP PN = new PHIEUNHAP();
            KHO kh = new KHO();
            CHITIETPHIEUNHAP nhomnd = new CHITIETPHIEUNHAP();
            Double money = 0;
            nhomnd.MACTPN = dgv_ctpn.CurrentRow.Cells[0].Value.ToString();
            PN.MAPN = dgv_pn.CurrentRow.Cells[0].Value.ToString();
            kh.MASP = dgv_ctpn.CurrentRow.Cells[2].Value.ToString();
            PN.MANV = txt_nvlap.Text.ToString();
            PN.SODONHANG = dgv_pn.CurrentRow.Cells[2].Value.ToString();
            PN.NGAYNHAP = Convert.ToDateTime(dgv_pn.CurrentRow.Cells[3].Value.ToString());
            int ktkho = bll_hdb.capnhatkho1(dgv_ctpn.CurrentRow.Cells[2].Value.ToString(), Convert.ToInt32(dgv_ctpn.CurrentRow.Cells[4].Value.ToString()));

            kh.SOLUONG = ktkho;
            money = Convert.ToDouble(dgv_pn.CurrentRow.Cells[4].Value.ToString()) - (Convert.ToDouble(dgv_ctpn.CurrentRow.Cells[5].Value.ToString()) * Convert.ToDouble(dgv_ctpn.CurrentRow.Cells[4].Value.ToString()));
            PN.TONGTIENNHAP = money;
            if (bll_ctpn.ktkc_CTPN(nhomnd) == false)
            {
                if (bll_ctpn.xoactpn(nhomnd) == true)
                {
                    MessageBox.Show("xóa thành công");
                    dgv_ctpn.DataSource = bll_ctpn.loadbang_ctpn();
                    if (kho_bll.ktkc_kho(kh) == false)
                    {
                        if (kho_bll.suakho(kh) == true)
                        {
                            MessageBox.Show("cập nhật kho thành công");
                        }
                    }
                    if (bll_pn.ktkc(PN) == false)
                    {
                        if (bll_pn.suapn(PN) == true)
                        {
                            MessageBox.Show("sửa thành công");
                            dgv_pn.DataSource = bll_pn.loadbang_PN();
                        }
                    }
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

        private void dateEdit_ngaydat_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (dateEdit_ngaydat.Text != null)
                {
                    txt_sdh.Text = pdh.laymapd_ngaydat(Convert.ToDateTime(dateEdit_ngaydat.Text.ToString()));
                }
            }
            catch
            {
                return;
            }
        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text != null && comboBox1.SelectedValue!=null)
            {
                try
                {
                    txt_msp.Text = comboBox1.SelectedValue.ToString();
                }
                catch
                {
                    return;
                }

            }
        }

        private void buttonX3_Click(object sender, EventArgs e)
        {
            frm_sizeg s = new frm_sizeg();
            s.Show();
        }
    }
}
