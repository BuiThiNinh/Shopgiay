using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using DAL;
using DevComponents.DotNetBar;
namespace SHOPBANGIAY
{
    public partial class userquanlynhanvien : UserControl
    {
        nhanvien_bll nv_bll = new nhanvien_bll();
        kiemtradangnhap k = new kiemtradangnhap();
        string strNhan;

        public userquanlynhanvien()
        {
            InitializeComponent();
        }
        public string Message
        {
            get { return strNhan; }
            set { strNhan = value; }
        }
        private void userquanlynhanvien_Load(object sender, EventArgs e)
        {
            txt_Manv.Enabled = false;
            dgv_nhanvien.DataSource = nv_bll.loadnhanvien();
            string[] gioitinh={"Nam","Nữ"};
            foreach (string x in gioitinh)
            {
                cbo_gioitinh.Items.Add(x);
            }
            string[] tinhtrang = { "Đang làm việc", "Nghỉ" };
            foreach (string x in tinhtrang)
            {
                cbo_tinhTrang.Items.Add(x);
            }
            xetquyen();
        }
        public void xetquyen()
        {
            foreach (Control c in groupBox1.Controls)
            {
                if (c is ButtonX)
                {
                    ((ButtonX)c).Visible = k.kiemtrathucquyen(strNhan, c.Tag.ToString());
                }
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                NHANVIEN nv = new NHANVIEN();
                int b = 0;
                for (int i = 1; i <= dgv_nhanvien.RowCount; i++)
                {
                    b = i;
                }
                nv.MANV = "NV0" + (b + 1).ToString();
                nv.TENNV = txt_TenNV.Text.ToString();
                nv.GIOITINH = cbo_gioitinh.Text.ToString();
                nv.SOCMND = txt_CMND.Text.ToString();
                nv.DIENTHOAINV = txt_DThoai.Text.ToString();
                nv.DIACHI = txt_DiaChi.Text.ToString();

                nv.TINHTRANG = cbo_tinhTrang.Text.ToString();
                nv.NGAYVAOLAM = Convert.ToDateTime(dateEdit_NgayVaoLam.Text.ToString());
                nv.MANQL = txt_MaNguoiQL.Text.ToString();
                nv.THUONG = Convert.ToDouble(txt_Thuong.Text.ToString());
                nv.TRU = Convert.ToDouble(txt_Phat.Text.ToString());
                nv.THUCLANH = Convert.ToDouble(txt_ThucLanh.Text.ToString());
                if (nv_bll.ktkc(nv) == true)
                {
                    if (nv_bll.themnhanvien(nv) == true)
                    {
                        MessageBox.Show("thêm thảnh công");
                        dgv_nhanvien.DataSource = nv_bll.loadnhanvien();
                    }
                    else
                    {
                        MessageBox.Show("thất bại");
                    }
                }
                else
                {
                    MessageBox.Show("trùng mã nhân viên");
                }
            }
            catch
            {
                return;
            }
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            try
            {
                NHANVIEN nv = new NHANVIEN();
                nv.MANV = dgv_nhanvien.CurrentRow.Cells[0].Value.ToString();
                if (nv_bll.ktkc(nv) == true)
                {
                    MessageBox.Show("giá trị không tồn tại");
                    return;
                }
                if (nv_bll.xoanhanvien(nv) == true)
                {
                    MessageBox.Show("thành công");
                    dgv_nhanvien.DataSource = nv_bll.loadnhanvien();
                }
                else
                {
                    MessageBox.Show("xảy ra lỗi");
                }
            }
            catch
            {
                MessageBox.Show("xảy ra lỗi");
            }
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            try
            {
                NHANVIEN nv = new NHANVIEN();
                nv.MANV = txt_Manv.Text.ToString();
                nv.TENNV = txt_TenNV.Text.ToString();
                nv.GIOITINH = cbo_gioitinh.Text.ToString();
                nv.SOCMND = txt_CMND.Text.ToString();
                nv.DIENTHOAINV = txt_DThoai.Text.ToString();
                nv.DIACHI = txt_DiaChi.Text.ToString();
                nv.TINHTRANG = cbo_tinhTrang.Text.ToString();
                nv.NGAYVAOLAM = Convert.ToDateTime(dateEdit_NgayVaoLam.Text.ToString());
                nv.MANQL = txt_MaNguoiQL.Text.ToString();
                nv.THUONG = Convert.ToDouble(txt_Thuong.Text.ToString());
                nv.TRU = Convert.ToDouble(txt_Phat.Text.ToString());
                nv.THUCLANH = Convert.ToDouble(txt_ThucLanh.Text.ToString());
                if (nv_bll.ktkc(nv) == true)
                {
                    MessageBox.Show("giá trị không tồn tại");
                    return;
                }
                
                if (nv_bll.suanhanvien(nv) == true)
                {
                    MessageBox.Show("thành công");
                    userquanlynhanvien_Load(sender, e);
                }
                else
                {
                    MessageBox.Show("xảy ra lỗi");
                }
            }
            catch
            {
                MessageBox.Show("xảy ra lỗi");
            }
        }

        private void dgv_nhanvien_SelectionChanged(object sender, EventArgs e)
        {

            if (dgv_nhanvien.CurrentRow != null)
            {
                txt_Manv.Text = dgv_nhanvien.CurrentRow.Cells["MANV"].Value.ToString();
                txt_TenNV.Text = dgv_nhanvien.CurrentRow.Cells["TENNV"].Value.ToString();
                cbo_gioitinh.Text = dgv_nhanvien.CurrentRow.Cells["GIOITINH"].Value.ToString();
                txt_CMND.Text = dgv_nhanvien.CurrentRow.Cells["SOCMND"].Value.ToString();
                txt_DThoai.Text = dgv_nhanvien.CurrentRow.Cells["DIENTHOIANV"].Value.ToString();
                txt_DiaChi.Text = dgv_nhanvien.CurrentRow.Cells["DIACHI"].Value.ToString();
                cbo_tinhTrang.Text = dgv_nhanvien.CurrentRow.Cells["TINHTRANG"].Value.ToString();
                dateEdit_NgayVaoLam.Text = dgv_nhanvien.CurrentRow.Cells["NGAYVAOLAM"].Value.ToString();
                if (dgv_nhanvien.CurrentRow.Cells["MANQL"].Value != null)
                {
                    txt_MaNguoiQL.Text = dgv_nhanvien.CurrentRow.Cells["MANQL"].Value.ToString();
                }
                txt_Thuong.Text = dgv_nhanvien.CurrentRow.Cells["THUONG"].Value.ToString();
                txt_Phat.Text = dgv_nhanvien.CurrentRow.Cells["TRU"].Value.ToString();
                txt_ThucLanh.Text = dgv_nhanvien.CurrentRow.Cells["THUCLANH"].Value.ToString();
            }
        }

        private void dgv_nhanvien_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
        }

        private void txttimkiem_TextChanged(object sender, EventArgs e)
        {
            if (txttimkiem.Text != null)
            {
                NHANVIEN nv=new NHANVIEN();
                nv.MANV=txttimkiem.Text.ToString();
                nv.TENNV = txttimkiem.Text.ToString();
                dgv_nhanvien.DataSource = nv_bll.loadnhanvien_tk(nv);
            }
        }
     
    }
}
