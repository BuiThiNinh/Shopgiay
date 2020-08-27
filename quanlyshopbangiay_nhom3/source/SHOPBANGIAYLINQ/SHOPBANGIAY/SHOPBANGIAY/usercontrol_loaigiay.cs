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
    public partial class usercontrol_loaigiay : UserControl
    {
        BLL_GIAY g = new BLL_GIAY();
        kiemtradangnhap k = new kiemtradangnhap();
        String strNhan;
        public usercontrol_loaigiay()
        {
            InitializeComponent();
        }

        private void usercontrol_loaigiay_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = g.loadbang_loaigiay();
            xetquyen();
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
        private void btnThem_Click(object sender, EventArgs e)
        {
            LOAIGIAY LG = new LOAIGIAY();
            int b = 0;
            for (int i = 1; i <= dataGridView1.RowCount; i++)
            {
                b += i;
            }
            txt_ml.Text = "L0" + (b+1).ToString();
            LG.MALOAI = "L0" + (b+1).ToString();
            LG.TENLOAI = txt_tenloai.Text.ToString();
            if (g.ktkc_lg(LG) == true)
            {
                if (g.themlg(LG) == true)
                {
                    MessageBox.Show("thêm thành công");
                    dataGridView1.DataSource = g.loadbang_loaigiay();
                }
                else
                {
                    MessageBox.Show("thất bại");

                }
            }
            else
            {
                MessageBox.Show("trùng mã");
            }
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            LOAIGIAY LG = new LOAIGIAY();
            LG.MALOAI = txt_ml.Text.ToString();
            LG.TENLOAI = txt_tenloai.Text.ToString();
            if (g.ktkc_lg(LG) == false)
            {
                if (g.sualg(LG) == true)
                {
                    MessageBox.Show("sửa thành công");
                    dataGridView1.DataSource = g.loadbang_loaigiay();
                }
                else
                {
                    MessageBox.Show("thất bại");

                }
            }
            else
            {
                MessageBox.Show("không tôn tại");
            }
        }
    }
}
