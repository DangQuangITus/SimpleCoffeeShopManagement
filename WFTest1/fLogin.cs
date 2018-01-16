using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WFTest1.DAO;
using WFTest1.DTO;

namespace WFTest1
{
    public partial class fLogin : Form
    {
        public fLogin()
        {
            InitializeComponent();
           // WindowState = FormWindowState.Normal;

        }


        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (cbShowPass.Checked)
                tbPass.UseSystemPasswordChar = true;
            else
                tbPass.UseSystemPasswordChar = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = tbName.Text;//lấy từ các text box nta nhập vào
            string pass = tbPass.Text;

            if (Login(username,pass))
            {
                Account loginAccount = AccountDAO.Instance.GetAccountByUserName(username);//14
                fTableManager f = new fTableManager(loginAccount);
                this.Hide(); //an cai login tam thoi di
                f.ShowDialog();
                this.Show();
            }
            else
            {
                MessageBox.Show("Tên hoặc mật khẩu chưa đúng.");
            }
        }

        bool Login(string username, string password)//load dl lên check ms cho log in
        {
            return AccountDAO.Instance.Login(username,password);//lớp Account xứ lí
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void fLogin_FormClosing(object sender, FormClosingEventArgs e)//event form closing
        {
            if (MessageBox.Show("Xác nhận thoát!!", "Xác Nhận!", MessageBoxButtons.YesNo) != System.Windows.Forms.DialogResult.Yes)
            {
                e.Cancel = true;//k cho thoát
            }
            else
            {
                e.Cancel = false;
            }
        }


    }
}
