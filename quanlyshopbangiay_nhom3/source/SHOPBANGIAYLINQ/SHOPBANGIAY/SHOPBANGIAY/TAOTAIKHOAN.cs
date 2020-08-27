using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL;
using BLL;

namespace SHOPBANGIAY
{
    public partial class TAOTAIKHOAN : Form
    {
        BLL_QLTaiKhoan bll = new BLL_QLTaiKhoan();
        public TAOTAIKHOAN()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            QUANLYND nd = new QUANLYND();
            nd.TENDN = textBox1.Text.ToString();
            nd.MK = textBox2.Text.ToString();
            if (radioButton1.Checked == true)
            {
                nd.HOATDONG = true;
            }
            else
            {
                nd.HOATDONG = false;
            }
            if (bll.ktkc(nd) == true)
            {
                if (bll.themtk(nd) == true)
                {
                    MessageBox.Show("thêm thành công");
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
    }
}
