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
    public partial class Frm_thongke : UserControl
    {
        BLL_TKBH tk = new BLL_TKBH();
        nhanvien_bll nv = new nhanvien_bll();
        BLL_TKNHAPHANG nh = new BLL_TKNHAPHANG();
        public Frm_thongke()
        {
            InitializeComponent();
        }

        private void Frm_thongke_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = nh.loadphieunhap();
            cbo_manv.DataSource = nv.loadnhanvien();
            cbo_manv.DisplayMember = "TENNV";
            cbo_manv.ValueMember = "MANV";

            da_tkbanhang.DataSource = tk.loadhd();
            cbo_nv1.DataSource = nv.loadnhanvien();
            cbo_nv1.DisplayMember = "TENNV";
            cbo_nv1.ValueMember = "MANV";
        }
        private void btn__Click(object sender, EventArgs e)
        {
            try
            {
                if (date_ngay.Text != string.Empty && cbo_manv.Text != string.Empty)
                {
                    dataGridView1.DataSource = nh.loadphieunhapNgay(Convert.ToDateTime(date_ngay.Text), Convert.ToDateTime(date_ngaykt.Text));
                }
                else
                {

                    if (date_ngay.Text == string.Empty && cbo_manv.Text != string.Empty)
                    {
                        dataGridView1.DataSource = nh.loaddl_nv(cbo_manv.SelectedValue.ToString());
                    }
                    else
                    {
                        dataGridView1.DataSource = nh.loadnv_ngay(cbo_manv.SelectedValue.ToString(), Convert.ToDateTime(date_ngay.Text));
                    }
                }

            }
            catch
            {
                MessageBox.Show("lỗi!!!");
            }
        }

        private void btn_tkbh_Click(object sender, EventArgs e)
        {
             try
            {
                if (dateNgay1.Text != string.Empty && cbo_nv1.SelectedValue.ToString() == string.Empty)
                {
                    da_tkbanhang.DataSource = tk.loadhdcodh(Convert.ToDateTime(dateNgay1.Text));
                }
                else
                {

                    if (dateNgay1.Text == string.Empty && cbo_nv1.SelectedValue.ToString() != string.Empty)
                    {
                        da_tkbanhang.DataSource = tk.Loadhoadon_nv(cbo_nv1.SelectedValue.ToString());
                    }
                    else
                    {
                        da_tkbanhang.DataSource = tk.loadnv_ngay(cbo_nv1.SelectedValue.ToString(), Convert.ToDateTime(dateNgay1.Text));
                    }
                }
            }
            catch
            {
                MessageBox.Show("Lỗi!!!");
            }
        }
    }
}
