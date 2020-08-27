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
    public partial class usercontrolquanlyphanquyen : UserControl
    {
        BLL_QLnhomND bll = new BLL_QLnhomND();
        BLL_PHANQUYEN bb_pq = new BLL_PHANQUYEN();
        BLL_DMMH mh = new BLL_DMMH();
        public usercontrolquanlyphanquyen()
        {
            InitializeComponent();
        }

        private void usercontrolquanlyphanquyen_Load(object sender, EventArgs e)
        {
            cb_danhmucmh.DataSource = mh.Load_dmmh();
            cb_danhmucmh.ValueMember = "MAMANHINH";
            cb_danhmucmh.DisplayMember = "TENMANHINHCHUCNANG";


            dgv_nhomnd.DataSource = bll.loadbang_qlnhomND();
            dgv_quyentruycap.DataSource = bb_pq.Load_phanquyen();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            QLPHANQUYEN pq = new QLPHANQUYEN();
           
            pq.MANHOM= dgv_nhomnd.CurrentRow.Cells[0].Value.ToString();
            pq.MAMANHINH = cb_danhmucmh.SelectedValue.ToString();
            if (radioButton1.Checked == true)
            {
                pq.COQUYEN = true;
            }
            else
            {
                pq.COQUYEN = false;
            }

            if (bb_pq.ktkc(pq) == true)
            {
                if (bb_pq.thempq(pq) == true)
                {
                    MessageBox.Show("thêm thành công");
                    dgv_quyentruycap.DataSource = bb_pq.Load_phanquyen();
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

        private void button2_Click(object sender, EventArgs e)
        {
            QLPHANQUYEN pq = new QLPHANQUYEN();

            pq.MANHOM = dgv_quyentruycap.CurrentRow.Cells[0].Value.ToString();
            pq.MAMANHINH = dgv_quyentruycap.CurrentRow.Cells[3].Value.ToString();

            if (bb_pq.ktkc(pq) == false)
            {
                if (bb_pq.xoapq(pq) == true)
                {
                    MessageBox.Show("xóa thành công");
                    dgv_quyentruycap.DataSource = bb_pq.Load_phanquyen();
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
    }
}
