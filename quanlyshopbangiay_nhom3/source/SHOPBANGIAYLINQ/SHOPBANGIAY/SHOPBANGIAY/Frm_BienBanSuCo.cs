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
    public partial class Frm_BienBanSuCo : UserControl
    {
        BLL_BBSUCO bb = new BLL_BBSUCO();
        string strNhan;
        public Frm_BienBanSuCo()
        {
            InitializeComponent();
        }
        public string Message
        {
            get { return strNhan; }
            set { strNhan = value; }
        }
        private void Frm_BienBanSuCo_Load(object sender, EventArgs e)
        {
            txtmanv.Text = strNhan;
            dgv_BBSC.DataSource = bb.loadBBSC();
           // dgv_BBSC.DataSource = bb.loadBienBangSuCo();
            date_ngaylap.Text = DateTime.Now.ToShortDateString();
            
        }

        private void dgv_BBSC_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            
            int b = 0;
            BIENBANSUCO bbsc = new BIENBANSUCO();
            for (int i = 1; i <= dgv_BBSC.RowCount; i++)
            {
                b = i;
            }
            bbsc.MABB= "BB" + (b + 1).ToString();
            bbsc.MANV = txtmanv.Text;
            bbsc.GHICHU = txtghichu.Text;
            bbsc.NGAYLAPBB =Convert.ToDateTime (date_ngaylap.Text);
            bbsc.SDT = txt_sdt.Text.ToString();
            bbsc.TENNGUOIBILAPBB = txtten.Text.ToString();
            bbsc.THU_CHI = Convert.ToDecimal(txt_thuchi.Text.ToString());
            if (radioButton1.Checked == true)
            {
                bbsc.nhanvien = true;
            }
            else
            {
                bbsc.nhanvien = false;
            }
            if (bb.ktkcbb(bbsc.MABB) == true)
            {
                MessageBox.Show("trùng khóa chính");
                return;
            }
            if (bb.ThemBBSC(bbsc) == true)
            {
                dgv_BBSC.DataSource = bb.loadBBSC();
                MessageBox.Show("Thành công");
            }
            else
            {
                MessageBox.Show("Thất bại");
            }
        }

        //private void btnsua_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        BIENBANSUCO bbsc = new BIENBANSUCO();
        //        bbsc.MABB = txtmabb.Text;
        //        bbsc.MANV = txtmanv.Text;
        //        bbsc.GHICHU = txtghichu.Text;
              
        //        bbsc.NGAYLAPBB = Convert.ToDateTime(date_ngaylap.Text);
        //        if (bb.suabbsc(bbsc) == true)
        //        {
        //            dgv_BBSC.DataSource = bb.loadBienBangSuCo();
        //            MessageBox.Show("Thành công");
        //        }
        //    }
        //    catch
        //    {
        //        MessageBox.Show("Thất bại");
        //    }
        //}

        private void btn_lammoi_Click(object sender, EventArgs e)
        {
            try
            {
                BIENBANSUCO bbsc = new BIENBANSUCO();
                bbsc.MABB = dgv_BBSC.CurrentRow.Cells[0].Value.ToString();
                if (bb.xoabbsc(bbsc) == true)
                {
                    dgv_BBSC.DataSource = bb.loadBBSC();
                    MessageBox.Show("Thành công");
                }
            }
            catch
            {
                MessageBox.Show("Thất bại");
            }
        }

        private void txtmanv_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtten.Clear();
                txtten.Text = bb.layten(txtmanv.Text);
            }
        }

        private void dgv_BBSC_SelectionChanged(object sender, EventArgs e)
        {
            if (dgv_BBSC.CurrentRow != null)
            {
                //txtmabb.Text = dgv_BBSC.CurrentRow.Cells[0].Value.ToString();
                //txtmanv.Text = dgv_BBSC.CurrentRow.Cells[1].Value.ToString();
                //txtten.Text = dgv_BBSC.CurrentRow.Cells[2].Value.ToString();

                //txt_thuchi.Text = dgv_BBSC.CurrentRow.Cells[6].Value.ToString();
                //if (txtghichu.Text != null)
                //{
                //    txtghichu.Text = dgv_BBSC.CurrentRow.Cells[3].Value.ToString();
                //    date_ngaylap.Text = dgv_BBSC.CurrentRow.Cells[4].Value.ToString();
                //}
                //else
                //{
                //    date_ngaylap.Text = dgv_BBSC.CurrentRow.Cells[4].Value.ToString();
                //}
            }
        }
    
    }
}
