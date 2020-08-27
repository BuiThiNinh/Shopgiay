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
    public partial class frm_QLnhomND : UserControl
    {
        BLL_QLnhomND bll = new BLL_QLnhomND();
        public frm_QLnhomND()
        {
            InitializeComponent();
        }

        private void frm_QLnhomND_Load(object sender, EventArgs e)
        {
            dataGridView_nhomND.DataSource = bll.loadbang_qlnhomND();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btn_Them_Click(object sender, EventArgs e)
        {
            QLNHOMND nhomnd = new QLNHOMND();
            int b = 0;
            for (int i = 1; i <= dataGridView_nhomND.RowCount; i++)
            {
                b = i;
            }
            nhomnd.MANHOM = "N0" + (b + 1).ToString();
            nhomnd.TENNHOMND = txt_MaNhom.Text.ToString();
            if (bll.ktkc(nhomnd) == true)
            {
                if (bll.themnhomnd(nhomnd) == true)
                {
                    MessageBox.Show("thêm thành công");
                    dataGridView_nhomND.DataSource = bll.loadbang_qlnhomND();
                }
                else
                {
                    MessageBox.Show("thất bại");

                }
            }
            else
            {
                MessageBox.Show("nhóm đã tồn tại");
            }
        }

        private void btn_Sua_Click(object sender, EventArgs e)
        {
            QLNHOMND nhomnd = new QLNHOMND();
            nhomnd.MANHOM = txt_MaNhom.Text.ToString();
            nhomnd.TENNHOMND = txt_TenNhom.Text.ToString();
            if (bll.ktkc(nhomnd) == false)
            {
                if (bll.suanhomnd(nhomnd) == true)
                {
                    MessageBox.Show("sửa thành công");
                    dataGridView_nhomND.DataSource = bll.loadbang_qlnhomND();
                }
                else
                {
                    MessageBox.Show("thất bại");

                }
            }
            else
            {
                MessageBox.Show("nhóm không tồn tại");
            }
        }

        private void dataGridView_nhomND_SelectionChanged(object sender, EventArgs e)
        {
            txt_MaNhom.Text = dataGridView_nhomND.CurrentRow.Cells[0].Value.ToString();
            txt_TenNhom.Text = dataGridView_nhomND.CurrentRow.Cells[1].Value.ToString();
            if (dataGridView_nhomND.CurrentRow.Cells[2].Value != null)
            {
                txt_ghichu.Text = dataGridView_nhomND.CurrentRow.Cells[2].Value.ToString();
            }
        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            QLNHOMND nhomnd = new QLNHOMND();
            nhomnd.MANHOM = txt_MaNhom.Text.ToString();
            if (bll.ktkc(nhomnd) == false)
            {
                if (bll.xoanhomnd(nhomnd) == true)
                {
                    MessageBox.Show("xóa thành công");
                    dataGridView_nhomND.DataSource = bll.loadbang_qlnhomND();
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
    }
}
