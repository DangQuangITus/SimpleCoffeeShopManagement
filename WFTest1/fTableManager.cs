using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WFTest1.DAO;
using WFTest1.DTO;
using static WFTest1.fAccount;

namespace WFTest1
{
    public partial class fTableManager : Form
    {
        private Account loginAccount;

        public Account LoginAccount
        {
            get { return loginAccount; }
            set { loginAccount = value; ChangeAccount(loginAccount.Type); }
        }
        public fTableManager(Account acc)
        {
            InitializeComponent();

            this.LoginAccount = acc;

            LoadTable();// mới và load table lên => bill,, table xử lí
            loadCategory();
            LoadComboboxTable(cbSwitchTable);
        }

        #region Methods
        void ChangeAccount(int type)
        {
            adminToolStripMenuItem.Enabled = type == 1;
            thôngTinTàiKhoảnToolStripMenuItem.Text += " (" + LoginAccount.DisplayName + ")";//hien thi thong tin tai khoan (boss) trên menu
        }
        void loadCategory()
        {
            List<Category> listCate = CategoryDAO.Instance.GetListCategory();
            cbCategory.DataSource = listCate;
            cbCategory.DisplayMember = "name";
        }
        void LoadFoodListByCategoryID(int id)
        {
            List<Food> listFood = FoodDAO.Instance.GetListFoodByCateID(id);
            cbFoodName.DataSource = listFood;
            cbFoodName.DisplayMember = "name";
        }

        /// <summary>
        /// 
        /// </summary>
        /// 
        public void LoadTable()
        {
            fpTable.Controls.Clear();
            List<Table> tableList = TableDAO.Instance.loadTableList();//table DAO vào table DTO chỉnh sửa

            foreach (Table item in tableList)
            {
                Button btn = new Button() { Width = TableDAO.tbWidth, Height = TableDAO.tbHeight };

                btn.Text = item.Name + "\n" + item.Status;
                btn.Tag = item;// lưu table vào obj
                btn.Click += Btn_Click;//set event khi ấn vaof nó sẽ lm 1 cái chuyện gì đó(phía duwois xử lí)

                switch (item.Status)//set màu
                {
                    case "Trống":
                        btn.BackColor = Color.CadetBlue;
                        break;
                    default:
                        btn.BackColor = Color.Cyan;
                        break;
                }
                fpTable.Controls.Add(btn);//thêm button vào
            }
            loadCategory();
            cbSwitchTable.DataSource = tableList;
            cbSwitchTable.DisplayMember = "name";
        }

        void ShowBill(int id)//bài 9
        {
            lvBill.Items.Clear();
            float totalPrice = 0;
            List<DTO.Menu> ListBillInfo = MenuDAO.Instance.GetListMenuByTable(id);
            foreach (DTO.Menu item in ListBillInfo)
            {
                ListViewItem lvitem = new ListViewItem(item.FoodName);
                lvitem.SubItems.Add(item.Count.ToString());
                lvitem.SubItems.Add(item.Price.ToString());
                lvitem.SubItems.Add(item.TotalPrice.ToString());
                totalPrice += item.TotalPrice;
                lvBill.Items.Add(lvitem);
            }
            CultureInfo cultue = new CultureInfo("vi-VN");
            Thread.CurrentThread.CurrentCulture = cultue;

            txbTotalPrice.Text = totalPrice.ToString("c", cultue);
        }
        void LoadComboboxTable(ComboBox cb)
        {
            cb.DataSource = TableDAO.Instance.loadTableList();
            cb.DisplayMember = "Name";
        }
        #endregion



        #region Events


        private void Btn_Click(object sender, EventArgs e)
        {

            int tableID = ((sender as Button).Tag as Table).ID;

            lvBill.Tag = (sender as Button).Tag;
             
            ShowBill(tableID);
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void thôngTinTàiKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
        {

            fAccount ft = new fAccount(LoginAccount);//14
            ft.UpdateAccount += f_UpdateAccount;
            ft.ShowDialog();
        }
        void f_UpdateAccount(object sender, AccountEvent e) // update account
        {
            thôngTinTàiKhoảnToolStripMenuItem.Text = "Thông tin tài khoản (" + e.Acc.DisplayName + ")";//update lain name moi ()
        }


        private void adminToolStripMenuItem_Click(object sender, EventArgs e)//sua 17 load lai
        {
            fAdmin f = new fAdmin();
            f.acc = loginAccount;
            f.InsertFood += f_InsertFood;
            f.DeleteFood += f_DeleteFood;
            f.UpdateFood += f_UpdateFood;
            f.InsertTable += F_InsertTable;
            f.DeleteCategory += F_DeleteCategory;
            f.EditCategory += F_EditCategory;
            f.DeleteTable += F_DeleteTable;
            f.ShowDialog();
        }

        private void F_DeleteTable(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            LoadTable();
            LoadComboboxTable(cbSwitchTable);
        }

        private void F_EditCategory(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            loadCategory();
        }

        private void F_DeleteCategory(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            loadCategory();            
        }

        private void F_InsertTable(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            LoadTable();
        }

        void f_UpdateFood(object sender, EventArgs e)
        {
            LoadFoodListByCategoryID((cbCategory.SelectedItem as Category).Id);
            if (lvBill.Tag != null)
                ShowBill((lvBill.Tag as Table).ID);
        }

        void f_DeleteFood(object sender, EventArgs e)
        {
            LoadFoodListByCategoryID((cbCategory.SelectedItem as Category).Id);
            if (lvBill.Tag != null)
                ShowBill((lvBill.Tag as Table).ID);
            LoadTable();
        }

        void f_InsertFood(object sender, EventArgs e)
        {
            LoadFoodListByCategoryID((cbCategory.SelectedItem as Category).Id);
            if (lvBill.Tag != null)
                ShowBill((lvBill.Tag as Table).ID);
        }

        private void cbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = 0;
            ComboBox cb = sender as ComboBox;
            if (cb.SelectedItem == null)
                return;
            Category selected = cb.SelectedItem as Category;
            id = selected.Id;
            LoadFoodListByCategoryID(id);
        }

        private void btnAddFood_Click(object sender, EventArgs e)
        {
            Table table = lvBill.Tag as Table;
            //18 neu chua chon ban
            if (table == null)
            {
                MessageBox.Show("Hãy chọn bàn");
                return;
            }

            int idBill = BillDAO.Instance.GetUnCheckBillIDByTableID(table.ID);
            int idFood = (cbFoodName.SelectedItem as Food).Id;
            int count = (int)(nmAddfood).Value;
            if (idBill == -1)
            {
                if (count < 1)
                {
                    MessageBox.Show(null, "Nhập sai số lượng món ăn.", "??", MessageBoxButtons.OK);
                    return;
                }
                BillDAO.Instance.InsertBill(table.ID);
                BillInfoDAO.Instance.InsertBillInfo(BillDAO.Instance.GetMaxIDBill(), idFood, count);
            }
            else
            {
                BillInfoDAO.Instance.InsertBillInfo(idBill, idFood, count);

            }
            ShowBill(table.ID);
            LoadTable();
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            Table table = lvBill.Tag as Table;

            if (table == null)
            {
                MessageBox.Show("Hãy chọn bàn");
                return;
            }
            int idBill = BillDAO.Instance.GetUnCheckBillIDByTableID(table.ID);
            int discount = (int)nmDiscount.Value;
            if (idBill == -1)
                return;
            else
            {
                double tongtien = Convert.ToDouble(txbTotalPrice.Text.Split(',')[0]) ;
                double finalPrice = tongtien - (tongtien * discount / 100);
                if (MessageBox.Show("Xác nhận thanh toán bàn " + table.ID + "\nTổng Cộng (đã giảm giá) " + finalPrice.ToString("c"), "Confirm?", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    BillDAO.Instance.CheckOut(idBill, discount, (float)finalPrice);
                    ShowBill(table.ID);
                    LoadTable();
                }
            }
        }

        private void btnSwitchTable_Click(object sender, EventArgs e)
        {
            if(lvBill.Tag == null)
            {
                MessageBox.Show("Chưa chọn bàn cần chuyển.");
                return;
            }
            int id1 = (lvBill.Tag as Table).ID;
            int id2 = (cbSwitchTable.SelectedItem as Table).ID;
            if(MessageBox.Show("Xác nhận chuyển bàn!!","Comfirm!!",MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            {
                TableDAO.Instance.SwitchTable(id1, id2);
                LoadTable();
            }
          
        }
        #endregion

    }
}
