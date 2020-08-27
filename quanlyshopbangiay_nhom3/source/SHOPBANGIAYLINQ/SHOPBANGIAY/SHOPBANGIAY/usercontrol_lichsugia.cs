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
using DevComponents.DotNetBar;

namespace SHOPBANGIAY
{
    public partial class usercontrol_lichsugia : UserControl
    {
        BLL_BANGGIA bg = new BLL_BANGGIA();
        BLL_GIAY lg = new BLL_GIAY();
        BLL_SANPHAM sp_bll = new BLL_SANPHAM();
        private int b = 0;
        kiemtradangnhap k = new kiemtradangnhap();
        string strNhan;
        public usercontrol_lichsugia()
        {
            InitializeComponent();
        }
        public string Message
        {
            get { return strNhan; }
            set { strNhan = value; }
        }
        private void usercontrol_lichsugia_Load(object sender, EventArgs e)
        { 
            b = 1;
            cb_loaigiay.DataSource = lg.loadbang_loaigiay();
            cb_loaigiay.DisplayMember = "TENLOAI";
            cb_loaigiay.ValueMember = "MALOAI";

            cb_tenasp.DataSource = sp_bll.loadbang_sanpham();
            cb_tenasp.DisplayMember = "TENSP";
            cb_tenasp.ValueMember = "MASP";
            dateTimeInput_ngayapdung.Text = DateTime.Now.ToString();
            dgv_gia.DataSource = bg.Load_lichsugia();
            xetquyen();
        }

        public void xetquyen()
        {
            foreach (Control c in groupBox1.Controls)
            {
                if (c is ButtonX)
                {
                    ((ButtonX) c).Visible = k.kiemtrathucquyen(strNhan, c.Tag.ToString());
                }
            }
        }
        private void cb_tenasp_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cb_tenasp_SelectedValueChanged(object sender, EventArgs e)
        {
            txt_msp.Text = cb_tenasp.SelectedValue.ToString();
        }

        private void cb_loaigiay_SelectedValueChanged(object sender, EventArgs e)
        {
            if (b == 1)
            {
                cb_loaigiay.DataSource = lg.loadbang_loaigiay();
                cb_loaigiay.DisplayMember = "TENLOAI";
                cb_loaigiay.ValueMember = "MALOAI";
            }
                if (cb_loaigiay.SelectedValue != null)
                {
                    cb_tenasp.DataSource = sp_bll.loadbang_sanpham_masp(cb_loaigiay.SelectedValue.ToString());
                    cb_tenasp.DisplayMember = "TENSP";
                    cb_tenasp.ValueMember = "MASP";
                }
            
            b = 0;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txt_msp.Text.Length > 0 && dateTimeInput_ngayapdung.Text.Length > 0 && txt_mucgia.Text.Length > 0)
            {
                LICHSUGIA lsg = new LICHSUGIA();
                lsg.MASP = txt_msp.Text.ToString();
                lsg.NGAYAPDUNG = Convert.ToDateTime(dateTimeInput_ngayapdung.Text.ToString());
                lsg.NGAYKETTHUC = null;
                lsg.MUCGIA = Convert.ToInt32(txt_mucgia.Text.ToString());

                if (bg.ktkc(lsg) == true)
                {
                    if (bg.themgia(lsg) == true)
                    {
                        MessageBox.Show("thêm thành công");
                        dgv_gia.DataSource = bg.Load_lichsugia();
                    }
                    else
                    {
                        MessageBox.Show("thất bại");

                    }
                }
                else
                {
                    MessageBox.Show("Mức giá này đã tồn tại");
                }
            }
            else
            {
                MessageBox.Show("Dữ liệu thiếu");
            }
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            if (txt_msp.Text.Length > 0 && dateTimeInput_ngayapdung.Text.Length > 0 && txt_mucgia.Text.Length > 0)
            {
                LICHSUGIA lsg = new LICHSUGIA();
                lsg.MASP = txt_msp.Text.ToString();
                lsg.NGAYAPDUNG = Convert.ToDateTime(dateTimeInput_ngayapdung.Text.ToString());
                lsg.NGAYKETTHUC = null;
                lsg.MUCGIA = Convert.ToInt32(txt_mucgia.Text.ToString());

                if (bg.ktkc(lsg) == false)
                {
                    if (bg.suagia(lsg) == true)
                    {
                        MessageBox.Show("sửa thành công");
                        dgv_gia.DataSource = bg.Load_lichsugia();
                    }
                    else
                    {
                        MessageBox.Show("thất bại");

                    }
                }
                else
                {
                    MessageBox.Show("Mức giá này chưa tồn tại");
                }
            }
            else
            {
                MessageBox.Show("Dữ liệu thiếu");
            }
        }

        private void dateTimeInput_ngayapdung_TextChanged(object sender, EventArgs e)
        {
            DateTime newTime = Convert.ToDateTime(dateTimeInput_ngayapdung.Text.ToString()).AddMonths(1);
            
        }

        private void dgv_gia_SelectionChanged(object sender, EventArgs e)
        {
            if (dgv_gia.CurrentRow != null)
            {
                txt_msp.Text = dgv_gia.CurrentRow.Cells[0].Value.ToString();
                dateTimeInput_ngayapdung.Text = dgv_gia.CurrentRow.Cells[3].Value.ToString();
                txt_mucgia.Text = dgv_gia.CurrentRow.Cells[2].Value.ToString();
            }
        }

        private void txt_msp_TextChanged(object sender, EventArgs e)
        {
            if (txt_msp.Text.Length > 0 && txt_msp.Text != null)
            {
                try
                {
                    cb_tenasp.SelectedValue = txt_msp.Text.ToString();
                }
                catch
                {
                    return;
                }
            }
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            txt_msp.Clear();
            txt_mucgia.Clear();
            dateTimeInput_ngayapdung.Text = DateTime.Now.ToString();
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            if (txt_msp.Text.Length > 0 && dateTimeInput_ngayapdung.Text.Length > 0 && txt_mucgia.Text.Length > 0)
            {
                LICHSUGIA lsg = new LICHSUGIA();
                lsg.MASP = txt_msp.Text.ToString();
                lsg.NGAYAPDUNG = Convert.ToDateTime(dateTimeInput_ngayapdung.Text.ToString());
                lsg.NGAYKETTHUC = DateTime.Now;
                lsg.MUCGIA = Convert.ToInt32(txt_mucgia.Text.ToString());

                if (bg.ktkc(lsg) == false)
                {
                    if (bg.suagia(lsg) == true)
                    {
                        MessageBox.Show("Gía dừng áp dụng");
                        dgv_gia.DataSource = bg.Load_lichsugia();
                    }
                    else
                    {
                        MessageBox.Show("thất bại");

                    }
                }
                else
                {
                    MessageBox.Show("Mức giá này chưa tồn tại");
                }
            }
            else
            {
                MessageBox.Show("Dữ liệu thiếu");
            }
        }
    }
}
