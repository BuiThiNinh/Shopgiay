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

namespace SHOPBANGIAY
{
    public partial class Form1 : Form
    {
       
        public Form1()
        {
            InitializeComponent();
            txt_user.ForeColor = Color.Gray;
            txt_user.Text = "USER NAME";

            this.txt_user.Leave += new System.EventHandler(this.txt_user_Leave);
            this.txt_user.Enter += new System.EventHandler(this.txt_user_Enter);
            txt_pass.ForeColor = Color.Gray;
            txt_pass.Text = "PASSWORD";
            this.txt_pass.Leave += new System.EventHandler(this.txt_pass_Leave);
            this.txt_pass.Enter += new System.EventHandler(this.txt_pass_Enter);
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void txt_pass_Enter(object sender, EventArgs e)
        {
            if (txt_pass.Text == "PASSWORD")
            {
                txt_pass.Text = "";
                txt_pass.ForeColor = Color.Gray;
            }

        }

        private void txt_pass_Leave(object sender, EventArgs e)
        {
            if (txt_pass.Text == "")
            {
                txt_pass.Text = "PASSWORD";
                txt_pass.ForeColor = Color.Gray;
            }

        }

        private void txt_user_Enter(object sender, EventArgs e)
        {
            if (txt_user.Text == "USER NAME")
            {
                txt_user.Text = "";
                txt_user.ForeColor = Color.Gray;
            }
        }

        void txt_user_Leave(object sender, EventArgs e)
        {
            if (txt_user.Text == "")
            {
                txt_user.Text = "USER NAME";
                txt_user.ForeColor = Color.Gray;
            }
        }
        int newLocationX, newLocationY;
        private void frm_dangnhap_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;
            newLocationX = e.X;
            newLocationY = e.Y;
        }

        private void frm_dangnhap_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
            {
                return;
            }
            Left = Left + (e.X - newLocationX);
            Top = Top + (e.Y - newLocationY);
        }

        private void bunifuCustomLabel1_MouseDown(object sender, MouseEventArgs e)
        {
            frm_dangnhap_MouseDown(sender, e);
        }

        private void bunifuCustomLabel1_MouseMove(object sender, MouseEventArgs e)
        {
            frm_dangnhap_MouseMove(sender, e);
        }

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            frm_dangnhap_MouseDown(sender, e);
        }

        private void panel2_MouseMove(object sender, MouseEventArgs e)
        {
            frm_dangnhap_MouseMove(sender, e);
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            frm_dangnhap_MouseDown(sender, e);
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            frm_dangnhap_MouseMove(sender, e);
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            fromketnoi kn = new fromketnoi();
            kn.Show();
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            kiemtradangnhap bll_ktdn=new kiemtradangnhap();
            String b = "vui lòng không để trống";
            if (txt_user.Text.Length > 0 && txt_pass.Text.Length > 0)
            {
                if (bll_ktdn.dangnhap_cotontai(txt_user.Text.ToString(), txt_pass.Text.ToString()) == true)
                {
                    MessageBox.Show("thành công");
                    Formmain m = new Formmain();
                    m.Message = txt_user.Text.ToString();
                    m.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Tài khoản không tồn tại");
                }
            }
            else
            {
                if (txt_pass.Text.Length == 0)
                {
                    b += " mật khẩu";
                }
                else
                    if (txt_user.Text.Length == 0)
                    {
                        b += " tên đăng nhập";
                    }
                MessageBox.Show(b);
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            //Application.Exit();
        }

        private void groupPanel1_Click(object sender, EventArgs e)
        {

        }
    }
}
