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
    public partial class Frm_Kho : UserControl
    {
        public Frm_Kho()
        {
            InitializeComponent();
        }
        BLL_Kho k = new BLL_Kho();
        private void Frm_Kho_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = k.loadKho();
        }
    }
}
