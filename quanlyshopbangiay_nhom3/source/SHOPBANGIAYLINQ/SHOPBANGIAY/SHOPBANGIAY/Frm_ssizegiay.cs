using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using DAL;

namespace SHOPBANGIAY
{
    public partial class Frm_ssizegiay : Form
    {
        BLL_SANPHAM sp = new BLL_SANPHAM();
        BLL_SIZEGIAY sg = new BLL_SIZEGIAY();
        public Frm_ssizegiay()
        {
            InitializeComponent();
        }

        private void Frm_ssizegiay_Load(object sender, EventArgs e)
        {
            comboBox1.DataSource = sp.loadbang_sanpham();
            comboBox1.DisplayMember = "TENSP";
            comboBox1.ValueMember = "MASP";
            dataGridView1.DataSource = sg.loadsizeg();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                SIZEGIAY size = new SIZEGIAY();
                size.MASP = comboBox1.SelectedValue.ToString();
                size.SIZE = Convert.ToInt32(txt_size.Text.ToString());
                size.SOLUONGSIZE = Convert.ToInt32(txt_slsize.Text.ToString());
                if (sg.ktkc_sizegiay(size) == true)
                {
                    if (sg.themsizegiay(size) == true)
                    {
                        MessageBox.Show("thêm thành công");
                        dataGridView1.DataSource = sg.loadsizeg();
                    }
                    else
                    {
                        MessageBox.Show("thất bại");

                    }
                }
                else
                {
                    MessageBox.Show("đã tồn tại");
                }
            }
            catch
            {
                return;
            }
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            SIZEGIAY size = new SIZEGIAY();
            size.MASP = comboBox1.SelectedValue.ToString();
            size.SIZE = Convert.ToInt32(txt_size.Text.ToString());
            size.SOLUONGSIZE = Convert.ToInt32(txt_slsize.Text.ToString());
            if (sg.ktkc_sizegiay(size) == false)
            {
                if (sg.suasizegiay(size) == true)
                {
                    MessageBox.Show("Sửa thành công");
                    dataGridView1.DataSource = sg.loadsizeg();
                }
                else
                {
                    MessageBox.Show("thất bại");

                }
            }
            else
            {
                MessageBox.Show("chưa tồn tại");
            }
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            SIZEGIAY size = new SIZEGIAY();
            size.MASP = comboBox1.SelectedValue.ToString();
            if (sg.ktkc_sizegiay(size) == false)
            {
                if (sg.xoasizegiay(size) == true)
                {
                    MessageBox.Show("xóa thành công");
                    dataGridView1.DataSource = sg.loadsizeg();
                }
                else
                {
                    MessageBox.Show("thất bại");

                }
            }
            else
            {
                MessageBox.Show("đã tồn tại");
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                comboBox1.SelectedValue = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                txt_size.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                txt_slsize.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            }
        }
    }
}
