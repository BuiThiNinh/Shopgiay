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
    public partial class Frm_KhachHang : UserControl
    {
        BILL_KhachHang kh = new BILL_KhachHang();
        public Frm_KhachHang()
        {
            InitializeComponent();
        }
        
        private void Frm_KhachHang_Load(object sender, EventArgs e)
        {
            txt_ma.Text = "KH"+kh.sinhma();
            dataGridView1.DataSource = kh.loadkh();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                KHACHHANG k = new KHACHHANG();

                k.MAKH = txt_ma.Text;
                k.TENKH = txt_ten.Text;
                k.SDTKHACHHANG = Convert.ToInt32(txt_sdt.Text);
                k.DIACHIKH = txtdc.Text;
                k.MAIL = txtmail.Text;
                if (kh.ktkc(txt_ma.Text) == true)
                {
                    MessageBox.Show("trùng khóa chính");
                    txt_ma.Text = "KH" + kh.sinhma();
                    return;
                }
                if (kh.themkh(k) == true)
                {
                    dataGridView1.DataSource = kh.loadkh();
                    MessageBox.Show("thành công");
                    txt_ma.Text = "KH" + kh.sinhma();

                }
                else
                {
                    MessageBox.Show("thất bại");
                    txt_ma.Text = "KH" + kh.sinhma();

                }
            }
            catch
            {
                txt_ma.Text = "KH" + kh.sinhma();
                return;
            }
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            KHACHHANG k = new KHACHHANG();
            k.MAKH = txt_ma.Text;
            k.SDTKHACHHANG = Convert.ToInt32(txt_sdt.Text);
            k.DIACHIKH = txtdc.Text;
            k.MAIL = txtmail.Text;
            
            if (kh.suakh(k) == true)
            {
                dataGridView1.DataSource = kh.loadkh();
                MessageBox.Show("thành công");

            }
            else
            {
                MessageBox.Show("thất bại");

            }
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            txt_ma.Text = dataGridView1.CurrentRow.Cells["MA"].Value.ToString();
            txt_ten.Text = dataGridView1.CurrentRow.Cells["Tenkh"].Value.ToString();
            txt_sdt.Text = dataGridView1.CurrentRow.Cells["SDT"].Value.ToString();
            txtdc.Text = dataGridView1.CurrentRow.Cells["DIACHI"].Value.ToString();
            txtmail.Text = dataGridView1.CurrentRow.Cells["Mail"].Value.ToString();
        }
    }
}
