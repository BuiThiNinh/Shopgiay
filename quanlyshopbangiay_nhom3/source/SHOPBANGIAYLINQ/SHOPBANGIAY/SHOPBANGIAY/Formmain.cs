using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
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
    public partial class Formmain : Form
    {
        userquanlynhanvien nhanvien = new userquanlynhanvien();
        BLL_QLTaiKhoan bll = new BLL_QLTaiKhoan();
        kiemtradangnhap k = new kiemtradangnhap();
        string strNhan;
        public Formmain()
        {
            InitializeComponent();
        }
        public string Message
        {
            get { return strNhan; }
            set { strNhan = value; }
        }
        private void Formmain_Load(object sender, EventArgs e)
        {
            tendn.EditValue = strNhan;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
            this.WindowState = FormWindowState.Maximized;
            FindMenuPhanQuyen(this.ribbonPage1.Groups);
            FindMenuPhanQuyen(this.ribbonPage2.Groups);
            FindMenuPhanQuyen(this.ribbonPage3.Groups);
        }
        private void FindMenuPhanQuyen(RibbonPageGroupCollection mnuItems)
        {
            
            foreach (RibbonPageGroup menu in mnuItems)
            {
                if (menu.Tag.ToString().Equals("MHTQ"))
                {
                    menu.Visible = true;
                }
                else
                {
                    menu.Visible = k.kiemtrathucquyen(strNhan, menu.Tag.ToString());
                }
            }
        }
      
        private void quanlynhanvien_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            userquanlynhanvien nv=new userquanlynhanvien();
            nv.Width = panel1.Width;
            nv.Height = panel1.Height;
            nv.Message = tendn.EditValue.ToString();
            panel1.Controls.Clear();
            panel1.Controls.Add(nv);
        }

        private void quanlytk_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frm_QLTaiKhoan tk = new frm_QLTaiKhoan();
            tk.Width = panel1.Width;
            tk.Height = panel1.Height;
            panel1.Controls.Clear();
            panel1.Controls.Add(tk);
           
        }

        private void quanlynhomnguoidung_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frm_QLnhomND nd = new frm_QLnhomND();
            nd.Width = panel1.Width;
            nd.Height = panel1.Height;
            panel1.Controls.Clear();
            panel1.Controls.Add(nd);
        }

        private void quanlyquyentruycap_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            usercontrolquanlyphanquyen pq = new usercontrolquanlyphanquyen();
            pq.Width = panel1.Width;
            pq.Height = panel1.Height;
            panel1.Controls.Clear();
            panel1.Controls.Add(pq);
        }

        private void barButtonItem14_ItemClick(object sender, ItemClickEventArgs e)
        {
            usercontrol_nhaphang NH = new usercontrol_nhaphang();
            NH.Width = panel1.Width;
            NH.Height = panel1.Height;
            NH.Message = tendn.EditValue.ToString();
            panel1.Controls.Clear();
            panel1.Controls.Add(NH);
        }

        private void barButtonItem15_ItemClick(object sender, ItemClickEventArgs e)
        {
            usercontroldathang dh = new usercontroldathang();
            dh.Width = panel1.Width;
            dh.Height = panel1.Height;
            dh.Message = tendn.EditValue.ToString();
            panel1.Controls.Clear();
            panel1.Controls.Add(dh);
        }

        private void barButtonItem10_ItemClick(object sender, ItemClickEventArgs e)
        {
            usercontrol_lichsugia lsg = new usercontrol_lichsugia();
            lsg.Width = panel1.Width;
            lsg.Height = panel1.Height;
            lsg.Message = tendn.EditValue.ToString();
            panel1.Controls.Clear();
            panel1.Controls.Add(lsg);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void barButtonItem28_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.Close();
            Form1 dn = new Form1();
            dn.Show();
        }

        private void barButtonItem29_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (mk.EditValue != null)
            {
                QUANLYND tk = new QUANLYND();
                tk.TENDN = tendn.EditValue.ToString();
                tk.MK = mk.EditValue.ToString();
                if (bll.ktkc(tk) == false)
                {
                    if (bll.suatk(tk) == true)
                    {
                        MessageBox.Show("Đồi mật khẩu thành công");
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
            else
            {
                MessageBox.Show("vui lòng nhập mật khẩu mới");
            }
        }

        private void barButtonItem_sanpham_ItemClick(object sender, ItemClickEventArgs e)
        {
            usercontrol_sanpham pq = new usercontrol_sanpham();
            pq.Message = tendn.EditValue.ToString();
            pq.Width = panel1.Width;
            pq.Height = panel1.Height;
            panel1.Controls.Clear();
            panel1.Controls.Add(pq);
        }

        private void barButtonItem24_ItemClick(object sender, ItemClickEventArgs e)
        {
            usercontrol_ncc pq = new usercontrol_ncc();
            pq.Width = panel1.Width;
            pq.Height = panel1.Height;
            panel1.Controls.Clear();
            panel1.Controls.Add(pq);
        }

        private void barButtonItem17_ItemClick(object sender, ItemClickEventArgs e)
        {
            usercontril_baohanh pq = new usercontril_baohanh();
            pq.Width = panel1.Width;
            pq.Height = panel1.Height;
            panel1.Controls.Clear();
            panel1.Controls.Add(pq);
  
        }

        private void barButtonItem8_ItemClick(object sender, ItemClickEventArgs e)
        {
            Frm_KhachHang pq = new Frm_KhachHang();
            pq.Width = panel1.Width;
            pq.Height = panel1.Height;
            panel1.Controls.Clear();
            panel1.Controls.Add(pq);
        }

        private void barButtonItem9_ItemClick(object sender, ItemClickEventArgs e)
        {
            Frm_Kho pq = new Frm_Kho();
            pq.Width = panel1.Width;
            pq.Height = panel1.Height;
            panel1.Controls.Clear();
            panel1.Controls.Add(pq);
        }

        private void barButtonItem31_ItemClick(object sender, ItemClickEventArgs e)
        {
            usercontrol_loaigiay pq = new usercontrol_loaigiay();
            pq.Width = panel1.Width;
            pq.Height = panel1.Height;
            panel1.Controls.Clear();
            panel1.Controls.Add(pq);
        }

        private void barButtonItem16_ItemClick(object sender, ItemClickEventArgs e)
        {
            usercontrol_banhang pq = new usercontrol_banhang();
            pq.Width = panel1.Width;
            pq.Height = panel1.Height;
            pq.Message = tendn.EditValue.ToString();
            panel1.Controls.Clear();
            panel1.Controls.Add(pq); 
        }

        private void barButtonItem34_ItemClick(object sender, ItemClickEventArgs e)
        {
            usercontrol_km pq = new usercontrol_km();
            pq.Message = tendn.EditValue.ToString();
            pq.Width = panel1.Width;
            pq.Height = panel1.Height;
            panel1.Controls.Clear();
            panel1.Controls.Add(pq); 
        }

        private void barButtonItem35_ItemClick(object sender, ItemClickEventArgs e)
        {
            Frm_BienBanSuCo pq = new Frm_BienBanSuCo();
            pq.Width = panel1.Width;
            pq.Height = panel1.Height;
            pq.Message = tendn.EditValue.ToString();
            panel1.Controls.Clear();
            panel1.Controls.Add(pq); 
        }

        private void barButtonItem36_ItemClick(object sender, ItemClickEventArgs e)
        {
            Frm_thongke pq = new Frm_thongke();
            pq.Width = panel1.Width;
            pq.Height = panel1.Height;
            panel1.Controls.Clear();
            panel1.Controls.Add(pq); 
        }

    }
}
