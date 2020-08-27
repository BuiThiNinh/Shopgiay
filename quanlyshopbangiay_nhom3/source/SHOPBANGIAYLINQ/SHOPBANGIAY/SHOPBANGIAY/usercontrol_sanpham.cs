using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using DAL;
using DevComponents.DotNetBar;
namespace SHOPBANGIAY
{
    public partial class usercontrol_sanpham : UserControl
    {
        BLL_SANPHAM sp = new BLL_SANPHAM();
        BLL_GIAY lg = new BLL_GIAY();
        BLL_NCC ncc = new BLL_NCC();
        BLL_Kho kh = new BLL_Kho();
        BLL_SIZEGIAY sg = new BLL_SIZEGIAY();
        BLL_KHUYENMAI km = new BLL_KHUYENMAI();
        kiemtradangnhap k = new kiemtradangnhap();
        string strNhan;
        public usercontrol_sanpham()
        {
            InitializeComponent();
        }
        public string Message
        {
            get { return strNhan; }
            set { strNhan = value; }
        }
        public void xetquyen()
        {
            foreach (Control c in groupBox1.Controls)
            {
                if (c is ButtonX)
                {
                    ((ButtonX)c).Visible = k.kiemtrathucquyen(strNhan, c.Tag.ToString());
                }
            }
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            SANPHAM sanp = new SANPHAM();
            sanp.MASP = txt_msp.Text.ToString();
            sanp.TENSP = cb_tensp.Text.ToString();
            sanp.MAU = txt_mau.Text.ToString();
            sanp.CHATLIEU = txt_chatlieu.Text.ToString();
            sanp.TINHTRANGSP = "Ngừng kinh doanh";
            sanp.MALOAI = cb_loaigiay.SelectedValue.ToString();
            sanp.MANCC = cb_ncc.SelectedValue.ToString();
            if (sp.ktkc_sp(sanp) == false)
            {
                if (sp.suasp(sanp) == true)
                {
                    MessageBox.Show("sửa thành công");
                    dgv_sp.DataSource = sp.loaddlsanpham();
                }
                else
                {
                    MessageBox.Show("thất bại");

                }
            }
            else
            {
                MessageBox.Show("sản phẩm này không tồn tại");
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            SANPHAM sanp = new SANPHAM();
            SIZEGIAY size = new SIZEGIAY();
            KHO k = new KHO();
            int b = 0;
            for (int i = 1; i <= dgv_sp.RowCount; i++)
            {
                b = i;
            }
            sanp.MASP = "SP" + (b+1).ToString();
            k.MASP = sanp.MASP;
            k.SOLUONG = 0;
            k.TRANGTHAI = cb_trangthaisp.Text.ToString();
            size.MASP = sanp.MASP;
            size.SIZE = 0;
            size.SOLUONGSIZE = 0;
            sanp.TENSP = cb_tensp.Text.ToString();
            sanp.MAU = txt_mau.Text.ToString();
            sanp.CHATLIEU = txt_chatlieu.Text.ToString();
            sanp.TINHTRANGSP = cb_trangthai.Text.ToString();
            sanp.MALOAI = cb_loaigiay.SelectedValue.ToString();
            sanp.MANCC = cb_ncc.SelectedValue.ToString();
            if (sp.ktkc_sp(sanp) == true)
            {
                if (sp.themsp(sanp) == true)
                { 
                    MessageBox.Show("thêm thành công");
                    usercontrol_sanpham_Load(sender, e);
                    if (sg.ktkc_sizegiay1(size) == true)
                    {
                        if (sg.themsizegiay(size) == true)
                        {
                            MessageBox.Show("thêm size giày thành công");
                        }
                    }
                    if (kh.ktkc_kho(k) == true)
                    {
                        if (kh.themkho(k) == true)
                        {
                            MessageBox.Show("thêm kho giày thành công");
                        }
                    }
                    usercontrol_sanpham_Load(sender, e);
                }
                else
                {
                    MessageBox.Show("thất bại");

                }
            }
            else
            {
                MessageBox.Show("sản phẩm này đã tồn tại");
            }
        }
        
        private void usercontrol_sanpham_Load(object sender, EventArgs e)
        {
            cb_loaigiay.DataSource = lg.loadbang_loaigiay();
            cb_loaigiay.DisplayMember = "TENLOAI";
            cb_loaigiay.ValueMember = "MALOAI";

            cb_tensp.DataSource = sp.loadbang_sanpham();
            cb_tensp.DisplayMember = "TENSP";
            cb_tensp.ValueMember = "MASP";

            cb_ncc.DataSource = ncc.loadbang_ncc();
            cb_ncc.DisplayMember = "TENNCC";
            cb_ncc.ValueMember = "MANCC";

            string[] tinhtranhsp = { "Đang kinh doanh", "Ngừng kinh doanh","Hàng sắp về" };
            foreach (string x in tinhtranhsp)
            {
                cb_trangthai.Items.Add(x);
            }

            string[] tinhtranghang = { "Còn hàng", "Hết hàng" };
            foreach (string x in tinhtranghang)
            {
                cb_trangthaisp.Items.Add(x);
            }

            dgv_sp.DataSource = sp.loaddlsanpham();
            xetquyen();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dgv_sp.CurrentRow != null)
            {
                txt_msp.Text = dgv_sp.CurrentRow.Cells[0].Value.ToString();
                cb_tensp.Text = dgv_sp.CurrentRow.Cells[1].Value.ToString();
                cb_loaigiay.Text = dgv_sp.CurrentRow.Cells[2].Value.ToString();
                txt_mau.Text = dgv_sp.CurrentRow.Cells[3].Value.ToString();
                txt_chatlieu.Text = dgv_sp.CurrentRow.Cells[4].Value.ToString();
                textBox3.Text = dgv_sp.CurrentRow.Cells[7].Value.ToString();
                txt_slsize.Text = dgv_sp.CurrentRow.Cells[8].Value.ToString();
                cb_trangthai.Text = dgv_sp.CurrentRow.Cells[5].Value.ToString();
                cb_ncc.Text = dgv_sp.CurrentRow.Cells[6].Value.ToString();
                dataGridView1.DataSource = km.loadbang_km_ctkm(dgv_sp.CurrentRow.Cells[0].Value.ToString());
            }
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            SANPHAM sanp = new SANPHAM();
            sanp.MASP = txt_msp.Text.ToString();
            sanp.TENSP = cb_tensp.Text.ToString();
            sanp.MAU = txt_mau.Text.ToString();
            sanp.CHATLIEU = txt_chatlieu.Text.ToString();
            sanp.TINHTRANGSP = cb_trangthai.Text.ToString();
            sanp.MALOAI = cb_loaigiay.SelectedValue.ToString();
            sanp.MANCC = cb_ncc.SelectedValue.ToString();
            if (sp.ktkc_sp(sanp) == false)
            {
                if (sp.suasp(sanp) == true)
                {
                    MessageBox.Show("sửa thành công");
                    dgv_sp.DataSource = sp.loaddlsanpham();
                }
                else
                {
                    MessageBox.Show("thất bại");

                }
            }
            else
            {
                MessageBox.Show("sản phẩm này không tồn tại");
            }
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            txt_msp.Clear();
            txt_mau.Clear();
            txt_chatlieu.Clear();
        }

        private void buttonX3_Click(object sender, EventArgs e)
        {
            Frm_ssizegiay s = new Frm_ssizegiay();
            s.Show();
        }


    }
}
