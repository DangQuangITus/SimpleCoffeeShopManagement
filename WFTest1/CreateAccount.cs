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
    public partial class CreateAccount : Form
    {

        public CreateAccount()
        {
            InitializeComponent();
        }

        #region Methods

        #endregion

        #region Events
        private void btnCreateAcc_Click(object sender, EventArgs e)
        {
            string username = tbCreateNameLogin.Text.ToString();
            if (AccountDAO.Instance.ExistAccount(username))
            {
                MessageBox.Show("Tên đăng nhập này đã tồn tại", "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                return;
            }

            if(username == "")
            {
                MessageBox.Show("Chưa nhập username", "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                return;
            }

            string displayname = tbCreateDisplayName.Text;
            if (displayname == "")
            {
                MessageBox.Show("Chưa nhập display name", "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                return;
            }
            string pass = tbCreatePass.Text;
            if (pass == "")
            {
                MessageBox.Show("Chưa nhập password", "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                return;
            }
            string rePass = tbCreateReEnterNewPass.Text;
            int type = 0;
            if (ckbQuanLy.Checked) 
                type = 1;
            else if (ckbNhanVien.Checked)
                type = 0;
            else
            {
                MessageBox.Show("Chưa chọn loại tài khoản", "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                return;
            }
            //
            if (!pass.Equals(rePass))
            {
                MessageBox.Show("Mật khẩu nhập lại không khớp","Error",MessageBoxButtons.RetryCancel,MessageBoxIcon.Error);
                return;
            }
            else
            {
                if (AccountDAO.Instance.CreateNewAccount(username, displayname, pass, type))
                {
                    MessageBox.Show("Thêm thành công");
                    //if (createNewAccount != null)
                    //    createNewAccount(this, new EventArgs());
                    //this.Close();
                }
            }
        }

        //private event EventHandler createNewAccount;
        //public event EventHandler CreateNewAccount
        //{
        //    add { createNewAccount += value; }
        //    remove { createNewAccount -= value; }
        //}

        private void ckbQuanLy_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbQuanLy.Checked )
            {
                ckbNhanVien.Checked = false;
            }
        }

        private void ckbNhanVien_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbNhanVien.Checked )
            {
                ckbQuanLy.Checked = false;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

    }
}
