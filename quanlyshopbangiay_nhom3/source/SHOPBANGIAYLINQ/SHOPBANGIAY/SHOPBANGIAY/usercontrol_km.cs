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
    public partial class usercontrol_km : UserControl
    {
        BLL_CTKM ctkm_bll = new BLL_CTKM();
        BLL_KHUYENMAI km_bll = new BLL_KHUYENMAI();
        BLL_GIAY LG_BLL = new BLL_GIAY();
        BLL_SANPHAM sp_bll = new BLL_SANPHAM();
        kiemtradangnhap k = new kiemtradangnhap();
        string strNhan;
        public usercontrol_km()
        {
            InitializeComponent();
        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }
        public string Message
        {
            get { return strNhan; }
            set { strNhan = value; }
        }
        private void usercontrol_km_Load(object sender, EventArgs e)
        {
            cb_lg.DataSource = LG_BLL.loadbang_loaigiay();
            cb_lg.DisplayMember = "TENLOAI";
            cb_lg.ValueMember = "MALOAI";
            cb_sp.DataSource = sp_bll.loadbang_sanpham();
            cb_sp.DisplayMember = "TENSP";
            cb_sp.ValueMember = "MASP";
            dateTimeInput_ndb.Text = DateTime.Now.ToString();
            dataGridView1.DataSource = km_bll.loaddlkm();
            dataGridView2.DataSource = ctkm_bll.loadbang_ct_sp();
            xetquyen();
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

        private void cb_lg_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                cb_sp.DataSource = sp_bll.loadbang_sanpham_masp(cb_lg.SelectedValue.ToString());
                cb_sp.DisplayMember = "TENSP";
                cb_sp.ValueMember = "MASP";
                if (cb_sp.SelectedValue == null)
                {
                    cb_sp.DisplayMember = null;
                }
            }
            catch
            {
                return;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            KHUYENMAI km = new KHUYENMAI();
            int b = 0;
            for (int i = 1; i <= dataGridView1.ColumnCount; i++)
            {
                b = i;
            }
            km.MAKM = "KM"+(b+1).ToString();
            km.TENKM = txt_tkm.Text.ToString();
            km.MUCGIAM = Convert.ToDouble(txt_mg.Text.ToString());
            if (radioButton1.Checked == true)
            {
                km.APDUNG = true;
            }
            else
            {
                km.APDUNG = false;
            }
            if (km_bll.ktkc_km(km) == true)
            {
                if (km_bll.themkm(km) == true)
                {
                    MessageBox.Show("thêm thành công");
                    dataGridView1.DataSource = km_bll.loaddlkm();
                }
                else
                {
                    MessageBox.Show("thất bại");

                }

            }
            else
            {
                MessageBox.Show("dữ liệu đã tồn tại");
            }
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            KHUYENMAI km = new KHUYENMAI();
            km.MAKM = txt_mkm.Text.ToString();
            km.TENKM = txt_tkm.Text.ToString();
            km.MUCGIAM = Convert.ToDouble(txt_mg.Text.ToString());
            km.APDUNG = false;
            if (km_bll.ktkc_km(km) == false)
            {
                if (km_bll.suakm(km) == true)
                {
                    MessageBox.Show("thành công");
                    dataGridView1.DataSource = km_bll.loaddlkm();
                }
                else
                {
                    MessageBox.Show("thất bại");

                }
            }
            else
            {
                MessageBox.Show("dữ liệu chưa tồn tại");
            }
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            KHUYENMAI km = new KHUYENMAI();
            km.MAKM = txt_mkm.Text.ToString();
            km.TENKM = txt_tkm.Text.ToString();
            km.MUCGIAM = Convert.ToDouble(txt_mg.Text.ToString());
            if (radioButton1.Checked == true)
            {
                km.APDUNG = true;
            }
            else
            {
                km.APDUNG = false;
            }
            if (km_bll.ktkc_km(km) == false)
            {
                if (km_bll.suakm(km) == true)
                {
                    MessageBox.Show("thành công");
                    dataGridView1.DataSource = km_bll.loaddlkm();
                }
                else
                {
                    MessageBox.Show("thất bại");

                }
            }
            else
            {
                MessageBox.Show("dữ liệu chưa tồn tại");
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                txt_mkm.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                txt_tkm.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                txt_mg.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                radioButton1.Checked = Convert.ToBoolean(dataGridView1.CurrentRow.Cells[3].Value.ToString());
                dataGridView2.DataSource = ctkm_bll.loadbang_ct_sp_makm(txt_mkm.Text.ToString());
            }
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            KHUYENMAI nhomnd = new KHUYENMAI();
            nhomnd.MAKM = txt_mkm.Text.ToString();
            if (km_bll.ktkc_km(nhomnd) == false)
            {
                if (km_bll.xoakm(nhomnd) == true)
                {
                    MessageBox.Show("xóa thành công");
                    dataGridView1.DataSource = km_bll.loaddlkm();
                }
                else
                {
                    MessageBox.Show("bạn không có quyền xóa");

                }
            }
        }

        private void buttonX5_Click(object sender, EventArgs e)
        {
            CT_KHUYENMAI ctkm = new CT_KHUYENMAI();
            ctkm.MAKM = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            ctkm.MASP = cb_sp.SelectedValue.ToString();
            ctkm.NBD = Convert.ToDateTime(dateTimeInput_ndb.Text.ToString());
            ctkm.NKT = Convert.ToDateTime(dateTimeInput_nkt.Text.ToString());
            if (ctkm_bll.ktkc_ctkm(ctkm) == true)
            {
                if (ctkm_bll.themctkm(ctkm) == true)
                {
                    MessageBox.Show("thêm thành công");
                    dataGridView2.DataSource = ctkm_bll.loadbang_ct_sp_makm(txt_mkm.Text.ToString());
                }
                else
                {
                    MessageBox.Show("thất bại");

                }

            }
            else
            {
                MessageBox.Show("dữ liệu đã tồn tại");
            }
        }

        private void buttonX6_Click(object sender, EventArgs e)
        {
            CT_KHUYENMAI ctkm = new CT_KHUYENMAI();
            ctkm.MAKM = dataGridView2.CurrentRow.Cells[0].Value.ToString();
            ctkm.MASP = cb_sp.SelectedValue.ToString();
            ctkm.NBD = Convert.ToDateTime(dateTimeInput_ndb.Text.ToString());
            ctkm.NKT = Convert.ToDateTime(dateTimeInput_nkt.Text.ToString());

            if (ctkm_bll.ktkc_ctkm(ctkm) == false)
            {
                if (ctkm_bll.suactkm(ctkm) == true)
                {
                    MessageBox.Show("sửa thành công");
                    dataGridView2.DataSource = ctkm_bll.loadbang_ct_sp_makm(txt_mkm.Text.ToString());
                }
                else
                {
                    MessageBox.Show("thất bại");

                }

            }
            else
            {
                MessageBox.Show("dữ liệu chưa tồn tại");
            }
        }

        private void buttonX3_Click(object sender, EventArgs e)
        {
            CT_KHUYENMAI ctkm = new CT_KHUYENMAI();
            ctkm.MAKM = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            ctkm.MASP = cb_sp.SelectedValue.ToString();
            ctkm.NBD = Convert.ToDateTime(dateTimeInput_ndb.Text.ToString());
            if (ctkm_bll.ktkc_ctkm(ctkm) == false)
            {
                if (ctkm_bll.xoactkm(ctkm) == true)
                {
                    MessageBox.Show("xóa thành công");
                    dataGridView2.DataSource = ctkm_bll.loadbang_ct_sp_makm(txt_mkm.Text.ToString());
                }
                else
                {
                    MessageBox.Show("bạn không có quyền xóa");

                }
            }
        }

        private void dataGridView2_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView2.CurrentRow != null)
            {
                cb_sp.SelectedValue = dataGridView2.CurrentRow.Cells[1].Value.ToString();
                dateTimeInput_ndb.Text = dataGridView2.CurrentRow.Cells[4].Value.ToString();
                dateTimeInput_nkt.Text = dataGridView2.CurrentRow.Cells[5].Value.ToString();
            }
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }
    }
}
