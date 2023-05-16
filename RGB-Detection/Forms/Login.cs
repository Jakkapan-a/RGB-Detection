using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RGB_Detection.Forms
{
    public partial class _Login : Form
    {
        private Main main;
        public _Login(Main main)
        {
            InitializeComponent();
            this.main = main;
        }

        private void Login_Load(object sender, EventArgs e)
        {
           
        }

        private void btLogin_Click(object sender, EventArgs e)
        {
            if(txtPassword.Text == "0987")
            {
                
                MessageBox.Show("Login Success", "Login", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.main.loginToolStripMenuItem.Text = "Logout";
                this.main.saveToolStripMenuItem.Visible = true;
                this.main.toolStripStatusLogin.Text = "Login";
                this.Close();
            }
            else
            {
                MessageBox.Show("Login Fail", "Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
