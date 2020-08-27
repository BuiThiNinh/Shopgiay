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
    public partial class frm_ChucVu : UserControl
    {
        BLL_CV cv = new BLL_CV();
        public frm_ChucVu()
        {
            InitializeComponent();
        }

        private void frm_ChucVu_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = cv.loadchucvu();
        }

        private void btn_Them_Click(object sender, EventArgs e)
        {

        }
    }
}
