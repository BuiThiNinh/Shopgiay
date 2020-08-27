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
    public partial class frm_QLTaiKhoan : UserControl
    {
        BLL_QLTaiKhoan bll = new BLL_QLTaiKhoan();
        BLL_QLNDNND bll_ndnnd = new BLL_QLNDNND();
        public frm_QLTaiKhoan()
        {
            InitializeComponent();
        }

        private void frm_QLTaiKhoan_Load(object sender, EventArgs e)
        {
            cbo_NHomND.DataSource = bll.Load_NhomND();
            cbo_NHomND.ValueMember = "MANHOM";
            cbo_NHomND.DisplayMember = "TENNHOMND";

            dataGridView_QLND.DataSource = bll.LoadbangQUANLYND();
            dataGridView_NDNhomND.DataSource = bll.Load_NDnhomND();
        }

        private void btn_ThemND_Click(object sender, EventArgs e)
        {
            QLNDNHOMND ndnnd = new QLNDNHOMND();
            ndnnd.TENDN = dataGridView_QLND.CurrentRow.Cells[4].Value.ToString();
            ndnnd.MANHOM = cbo_NHomND.SelectedValue.ToString();
            ndnnd.GHICHU = textBox1.Text.ToString();
            if (bll_ndnnd.ktkc(ndnnd) == true)
            {
                if (bll_ndnnd.themndnnd(ndnnd) == true)
                {
                    MessageBox.Show("thêm thành công");
                    dataGridView_NDNhomND.DataSource = bll.Load_NDnhomND();
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

        private void button1_Click(object sender, EventArgs e)
        {
            QLNDNHOMND ndnnd = new QLNDNHOMND();
            ndnnd.TENDN = dataGridView_NDNhomND.CurrentRow.Cells[0].Value.ToString();
            ndnnd.MANHOM = cbo_NHomND.SelectedValue.ToString();
            if (bll_ndnnd.ktkc(ndnnd) == false)
            {
                if (bll_ndnnd.xoandnnd(ndnnd) == true)
                {
                    MessageBox.Show("thành công");
                    dataGridView_NDNhomND.DataSource = bll.Load_NDnhomND();
                }
                else
                {
                    MessageBox.Show("thất bại");

                }
            }
            else
            {
                MessageBox.Show("dữ liệu không tồn tại");
            }
        }

        private void dataGridView_QLND_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView_QLND_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                QUANLYND tk = new QUANLYND();
                tk.TENDN = dataGridView_QLND.CurrentRow.Cells[4].Value.ToString();
                if (bll.ktkc(tk) == false)
                {
                    if (bll.xoatk(tk) == true)
                    {
                        MessageBox.Show("xóa thành công");
                        dataGridView_QLND.DataSource = bll.LoadbangQUANLYND();
                    }
                    else
                    {
                        MessageBox.Show("bạn không có quyền xóa");

                    }
                }
                else
                {
                    MessageBox.Show("Tài khoản không tồn tại");
                }
            }
            else
            {
                if (e.ColumnIndex == 2)
                {
                    QUANLYND tk = new QUANLYND();
                    tk.TENDN = dataGridView_QLND.CurrentRow.Cells[4].Value.ToString();
                    tk.MK = "123456789";
                    if (bll.ktkc(tk) == false)
                    {
                        if (bll.suatk(tk) == true)
                        {
                            MessageBox.Show("reset thành công");
                            dataGridView_QLND.DataSource = bll.LoadbangQUANLYND();
                        }
                        else
                        {
                            MessageBox.Show("thất bại");

                        }
                    }
                    else
                    {
                        MessageBox.Show("Tài khoản không tồn tại");
                    }
                }
            }
            if (e.ColumnIndex == 3)
            {
                QUANLYND tk = new QUANLYND();
                tk.TENDN = dataGridView_QLND.CurrentRow.Cells[4].Value.ToString();

                tk.HOATDONG = true;
                if (bll.ktkc(tk) == false)
                {
                    if (bll.suatk1(tk) == true)
                    {
                        MessageBox.Show("tài khoản bắt đầu hoạt động");
                        dataGridView_QLND.DataSource = bll.LoadbangQUANLYND();
                    }
                    else
                    {
                        MessageBox.Show("thất bại");

                    }
                }
                else
                {
                    MessageBox.Show("Tài khoản không tồn tại");
                }
            }
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            TAOTAIKHOAN toatk = new TAOTAIKHOAN();
            toatk.Show();
            this.Hide();
        }
    }
}
