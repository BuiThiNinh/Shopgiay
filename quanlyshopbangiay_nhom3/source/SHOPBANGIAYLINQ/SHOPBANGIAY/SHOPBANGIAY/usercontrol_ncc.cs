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
    public partial class usercontrol_ncc : UserControl
    {
        BLL_NCC ncc_bll = new BLL_NCC();
        public usercontrol_ncc()
        {
            InitializeComponent();
        }

        private void usercontrol_ncc_Load(object sender, EventArgs e)
        {
            dgv_ncc.DataSource = ncc_bll.loadbang_ncc();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            NHACC ncc = new NHACC();
            int b = 0;
            for (int i = 1; i <= dgv_ncc.RowCount; i++)
            {
                b = i;
            }
            txt_mancc.Text = ("NCC" + (b + 1).ToString()).ToString();
            ncc.MANCC = "NCC" + (b + 1).ToString();
            ncc.TENNCC = txt_tenncc.Text.ToString();
            ncc.EMAIL = txt_email.Text.ToString();
            ncc.SDTNHACC = txt_sdt.Text.ToString();
            ncc.DIACHINCC = txt_dc.Text.ToString();
            ncc.HOPTAC = true;
            if (ncc_bll.ktkc(ncc) == true)
            {
                if (ncc_bll.themncc(ncc) == true)
                {
                    MessageBox.Show("thêm thành công");
                    dgv_ncc.DataSource = ncc_bll.loadbang_ncc();
                }
                else
                {
                    MessageBox.Show("thất bại");

                }
            }
            else
            {
                MessageBox.Show("nhà cung cấp này đã tồn tại");
            }
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            Boolean t = false;
            NHACC ncc = new NHACC();
            ncc.MANCC = txt_mancc.Text.ToString();
            ncc.TENNCC = txt_tenncc.Text.ToString();
            ncc.EMAIL = txt_email.Text.ToString();
            ncc.SDTNHACC = txt_sdt.Text.ToString();
            ncc.DIACHINCC = txt_dc.Text.ToString();
            if (checkBox_ht.Checked)
            {
                t = true;
            }
            ncc.HOPTAC = t;
            if (ncc_bll.ktkc(ncc) == false)
            {
                if (ncc_bll.suancc(ncc) == true)
                {
                    MessageBox.Show("thành công");
                    dgv_ncc.DataSource = ncc_bll.loadbang_ncc();
                }
                else
                {
                    MessageBox.Show("thất bại");

                }
            }
            else
            {
                MessageBox.Show("nhà cung cấp này chưa tồn tại");
            }
        }

        private void dgv_ncc_SelectionChanged(object sender, EventArgs e)
        {
            if (dgv_ncc.CurrentRow != null)
            {
                txt_mancc.Text = dgv_ncc.CurrentRow.Cells[0].Value.ToString();
                txt_tenncc.Text = dgv_ncc.CurrentRow.Cells[1].Value.ToString();
                txt_email.Text = dgv_ncc.CurrentRow.Cells[3].Value.ToString();
                txt_sdt.Text = dgv_ncc.CurrentRow.Cells[2].Value.ToString();
                txt_dc.Text = dgv_ncc.CurrentRow.Cells[4].Value.ToString();
                checkBox_ht.Checked = Convert.ToBoolean(dgv_ncc.CurrentRow.Cells[5].Value.ToString());
            }
        }

        
    }
}
