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
    public partial class usercontril_baohanh : UserControl
    {
        BLL_BAOHANH bh_bll = new BLL_BAOHANH();
        BLL_GIAY bll_giay = new BLL_GIAY();
        BLL_SANPHAM bll_sp = new BLL_SANPHAM();
        private int b = 0;
        public usercontril_baohanh()
        {
            InitializeComponent();
        }

        private void usercontril_baohanh_Load(object sender, EventArgs e)
        {
            b = 1;
            cb_loaigiay.DataSource = bll_giay.loadbang_loaigiay();
            cb_loaigiay.DisplayMember = "TENLOAI";
            cb_loaigiay.ValueMember = "MALOAI";
            cb_sp.DataSource = bll_sp.loadbang_sanpham();
            cb_sp.DisplayMember = "TENSP";
            cb_sp.ValueMember = "MASP";
            dataGridView1.DataSource = bh_bll.loadbang_baohanh();
        }

        private void cb_sp_SelectedValueChanged(object sender, EventArgs e)
        {
            if (b == 1)
            {
                cb_sp.DataSource = bll_sp.loadbang_sanpham();
                cb_sp.DisplayMember = "TENSP";
                cb_sp.ValueMember = "MASP";
            }
            if (cb_sp.SelectedValue != null)
            {
                txt_msp.Text = cb_sp.SelectedValue.ToString();
            }
            b = 0;
        }
    }
}
