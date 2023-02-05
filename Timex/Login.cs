using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Timex
{
    public partial class Login : MetroFramework.Forms.MetroForm
    {
        public int UserID { get; set; }
        public bool loginflag { get; set; }
        public Login()
        {
            InitializeComponent();
            loginflag = false;

        }

        private void Login_Load(object sender, EventArgs e)
        {
            
        }

        private void metroTextBox1_Click(object sender, EventArgs e)
        {
            
        }

        private void metroTile1_Click(object sender, EventArgs e)
        {
            try
            {
                DataSet1TableAdapters.UsersTableAdapter usersADA = new DataSet1TableAdapters.UsersTableAdapter();
                DataTable dt = usersADA.GetDataByUserAndPass(comboBox1.Text, metroTextBox2.Text);
                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show("logged in sucessfully");
                    UserID = int.Parse(dt.Rows[0]["ID"].ToString());
                    loginflag = true;
                }
                else
                {
                    loginflag = false;
                    MessageBox.Show("something wrong");
                }
                Close();
            }
            catch
            {
                MessageBox.Show("login failed");
            }
        }
    }
}
