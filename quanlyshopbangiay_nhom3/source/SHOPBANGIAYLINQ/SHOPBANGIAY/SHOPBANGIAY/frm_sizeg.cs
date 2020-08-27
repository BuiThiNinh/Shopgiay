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
    public partial class frm_sizeg : Form
    {
        BLL_SANPHAM sp = new BLL_SANPHAM();
        BLL_SIZEGIAY sg = new BLL_SIZEGIAY();
        public frm_sizeg()
        {
            InitializeComponent();
        }

        private void frm_sizeg_Load(object sender, EventArgs e)
        {
            comboBox1.DataSource = sp.loadbang_sanpham();
            comboBox1.DisplayMember = "TENSP";
            comboBox1.ValueMember = "MASP";
            dataGridView1.DataSource = sg.loadsizeg();
        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                comboBox1.DataSource = sp.loadbang_sanpham();
                comboBox1.DisplayMember = "TENSP";
                comboBox1.ValueMember = "MASP";
                if (comboBox1.SelectedValue != null)
                {
                    comboBox2.DataSource = sg.loadsizegiay(comboBox1.SelectedValue.ToString());
                }
            }
            catch
            {
                return;
            }
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            SIZEGIAY size = new SIZEGIAY();
            size.MASP = comboBox1.SelectedValue.ToString();
            size.SIZE = Convert.ToInt32(comboBox2.Text.ToString());
            size.SOLUONGSIZE = Convert.ToInt32(dataGridView1.CurrentRow.Cells[2].Value.ToString()) + Convert.ToInt32(txt_slsize.Text.ToString());
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
    }
}
