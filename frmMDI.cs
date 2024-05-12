using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tien_897
{
    public partial class frmMDI : Form
    {
        public frmMDI(bool Enabled)
        {
            InitializeComponent();
             mnuSolve.Enabled = Enabled;
            mnuDatabase.Enabled = Enabled; 
        }
        public frmMDI()
        {
            InitializeComponent();
            mnuSolve.Enabled = false;
            mnuDatabase.Enabled = false;
        }

        private void mnuLogin_Click(object sender, EventArgs e)
        {
            FrmLogin frmLogin = new FrmLogin();
            frmLogin.Show();
            
        }
    }
}
