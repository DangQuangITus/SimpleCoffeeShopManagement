using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WFTest1.DAO;
using WFTest1.DTO;

namespace WFTest1
{
    public partial class fAdmin : Form
    {
        BindingSource foodList = new BindingSource();//16
        BindingSource nvList = new BindingSource();//16 khac phuc loi sau nay khi them xoa sua no se ung vs dtgv
        BindingSource foodCategoryList = new BindingSource();//16
        BindingSource foodTableList = new BindingSource();//16
        BindingSource AccountList = new BindingSource();//16

        public fAdmin()
        {
            InitializeComponent();

            Load1();//load 1 lan ch0 nhanh 16
        }
        #region methods
        List<Food> SearchFoodByName(string name)
        {
            List<Food> listFood = FoodDAO.Instance.SearchFoodByName(name);

            return listFood;
        }

        void Load1()//load tat ca cac ham can load 1 lan
        {
            //load lên list lên khi chạy Doanh Thu
            LoadDateTimePickerBill();
            //sau khi an button nó sẽ k bị disable khi chọn
            dtgvFood.DataSource = foodList;
            dtgvNhanVien.DataSource = nvList;
            dtgvCategory.DataSource = foodCategoryList;
            dtgvTable.DataSource = foodTableList;
            dtgvAcc.DataSource = AccountList;

            // food
            LoadListBillByDate(dtpkFromDate.Value, dtpkToDate.Value);
            LoadListFood();
            LoadCategoryIntoCombobox(cbFoodCategory);//load len

            AddFoodBinding();
            //nhanvien
            LoadListNhanVien();
            LoadSexIntoComboBox(cbGioiTinh);
            AddNhanVienBinding();
            //FoodCategory
            LoadListFoodCategory();
            AddFoodCategoryBinding();

            //table
            LoadListFoodTable();
            AddFoodTableBinding();
            LoadTableStatusIntoCombobox(cbTableStatus);
            //account
            LoadListAccount();
            AddAccountBinding();
            LoadAccountTypeIntoComboBox(cbTypeAcc);
        }
        //load status vao table combo box
        void LoadTableStatusIntoCombobox(ComboBox cb)
        {
            cb.DataSource = TableStatusDAO.Instance.GetListTableStatus();//lay ra name  status
            cb.DisplayMember = "name";//de hien len
        }

        void LoadSexIntoComboBox(ComboBox cb)
        {
            cb.DataSource = SexDAO.Instance.GetListSex();
            cb.DisplayMember = "gioitinh";
            // cb.DisplayMember = "name";//de hien len
        }


        void LoadAccountTypeIntoComboBox(ComboBox cb)
        {
            cb.DataSource = AccountTypeDAO.Instance.GetListAccountType();//lay ra name  status
            cb.DisplayMember = "name";//de hien len
        }
        void LoadDateTimePickerBill()
        {
            DateTime today = DateTime.Now;
            dtpkFromDate.Value = new DateTime(today.Year, today.Month, 1);
            dtpkToDate.Value = dtpkFromDate.Value.AddMonths(1).AddDays(-1);
        }
        void LoadListBillByDateAndPage(DateTime checkIn, DateTime checkOut, int Page)
        {
            dtgvBill.DataSource = BillDAO.Instance.GetBillListByDateAndPage(checkIn, checkOut, Page); //cho data ra dgv
        }

        void LoadListBillByDate(DateTime checkIn, DateTime checkOut)
        {
            dtgvBill.DataSource = BillDAO.Instance.GetBillListByDateAndPage(checkIn, checkOut, 1); //cho data ra dgv
        }
        //them food vào txb
        void AddFoodBinding()//16 binding data them dl vao txb
        {
            txbFoodName.DataBindings.Add(new Binding("Text", dtgvFood.DataSource, "Name", true, DataSourceUpdateMode.Never));//17 sua them, true là tự động ép kiểu, k cho thay doi gtri Never
            txbFoodID.DataBindings.Add(new Binding("Text", dtgvFood.DataSource, "ID", true, DataSourceUpdateMode.Never));
            nmFoodPrice.DataBindings.Add(new Binding("Value", dtgvFood.DataSource, "Price", true, DataSourceUpdateMode.Never));
        }
        void LoadCategoryIntoCombobox(ComboBox cb)//load a combobox
        {
            cb.DataSource = CategoryDAO.Instance.GetListCategory();//lay ra name foodcategory
            cb.DisplayMember = "Name";//de hien len, sau đo cao categoryDAO thay doi
        }

        //xu li cho nhanvien
        void AddNhanVienBinding()//16 binding data them dl vao txb
        {
            txbTenNV.DataBindings.Add(new Binding("Text", dtgvNhanVien.DataSource, "Ten", true, DataSourceUpdateMode.Never));//17 sua them, true là tự động ép kiểu, k cho thay doi gtri Never
            txbID.DataBindings.Add(new Binding("Text", dtgvNhanVien.DataSource, "id", true, DataSourceUpdateMode.Never));
            txbSDT.DataBindings.Add(new Binding("Text", dtgvNhanVien.DataSource, "Sdt", true, DataSourceUpdateMode.Never));
            txbDiaChi.DataBindings.Add(new Binding("Text", dtgvNhanVien.DataSource, "DiaChi", true, DataSourceUpdateMode.Never));

            dtpkNgaySinh.DataBindings.Add(new Binding("value", dtgvNhanVien.DataSource, "NgaySinh", true, DataSourceUpdateMode.Never));
            nmLuong.DataBindings.Add(new Binding("Text", dtgvNhanVien.DataSource, "Luong", true, DataSourceUpdateMode.Never));
        }
        //xu li danh muc
        void AddFoodCategoryBinding()//16 binding data them dl vao txb
        {
            txbCategoryName.DataBindings.Add(new Binding("Text", dtgvCategory.DataSource, "Name", true, DataSourceUpdateMode.Never));//17 sua them, true là tự động ép kiểu, k cho thay doi gtri Never
            txbIDCategory.DataBindings.Add(new Binding("Text", dtgvCategory.DataSource, "ID", true, DataSourceUpdateMode.Never));
        }
        //xu li table
        void AddFoodTableBinding()//16 binding data them dl vao txb
        {
            txbNameTable.DataBindings.Add(new Binding("Text", dtgvTable.DataSource, "Name", true, DataSourceUpdateMode.Never));//17 sua them, true là tự động ép kiểu, k cho thay doi gtri Never
            txbIDTable.DataBindings.Add(new Binding("Text", dtgvTable.DataSource, "ID", true, DataSourceUpdateMode.Never));
        }
        //xu li account
        void AddAccountBinding()//16 binding data them dl vao txb
        {
            txbUserName.DataBindings.Add(new Binding("Text", dtgvAcc.DataSource, "UserName", true, DataSourceUpdateMode.Never));//17 sua them, true là tự động ép kiểu, k cho thay doi gtri Never
            txbDisplayName.DataBindings.Add(new Binding("Text", dtgvAcc.DataSource, "DisplayName", true, DataSourceUpdateMode.Never));

        }
        void LoadListFood()//15 load lên
        {
            // dtgvFood.DataSource = FoodDAO.Instance.GetListFood();
            //16
            foodList.DataSource = FoodDAO.Instance.GetListFood();

        }

        void LoadListNhanVien()//15 load lên
        {
            // dtgvNhanVien.DataSource = NhanVienDAO.Instance.GetListNhanVien();

            nvList.DataSource = NhanVienDAO.Instance.GetListNhanVien();
        }

        void LoadListFoodCategory()//15 load lên
        {
            foodCategoryList.DataSource = CategoryDAO.Instance.GetListFoodCategory();
        }
        void LoadListFoodTable()//15 load lên
        {
            foodTableList.DataSource = TableDAO.Instance.loadTableList();
        }
        void LoadListAccount()//15 load lên
        {
            AccountList.DataSource = AccountDAO.Instance.GetListAccount();
        }

        #endregion


        #region events
        private void btnViewBill_Click(object sender, EventArgs e)
        {
            LoadListBillByDate(dtpkFromDate.Value, dtpkToDate.Value);
        }
        private void btnViewFood_Click(object sender, EventArgs e)
        {
            LoadListFood();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadListNhanVien();
        }

        private void btnAddFood_Click(object sender, EventArgs e)
        {
            string name = txbFoodName.Text;
            if (cbFoodCategory.SelectedItem == null)
            {
                MessageBox.Show("không có danh mục yêu cầu");
                return;
            }
            int categoryID = (cbFoodCategory.SelectedItem as Category).Id;
            float price = (float)nmFoodPrice.Value;

            if (FoodDAO.Instance.InsertFood(name, categoryID, price))
            {
                MessageBox.Show("Thêm món thành công");
                LoadListFood();
                if (insertFood != null)
                    insertFood(this, new EventArgs());
            }
            else
            {
                MessageBox.Show("Có lỗi khi thêm thức ăn");
            }
        }

        private void btnEditFood_Click(object sender, EventArgs e)
        {
            string name = txbFoodName.Text;
            int categoryID = (cbFoodCategory.SelectedItem as Category).Id;
            float price = (float)nmFoodPrice.Value;
            int id = Convert.ToInt32(txbFoodID.Text);

            if (FoodDAO.Instance.UpdateFood(id, name, categoryID, price))
            {
                MessageBox.Show("Sửa món thành công");
                LoadListFood();
                if (updateFood != null)
                    updateFood(this, new EventArgs());
            }
            else
            {
                MessageBox.Show("Có lỗi khi sửa thức ăn");
            }
        }

        private void btnDeleteFood_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Xác nhận xóa: " + txbFoodName.Text + " ?", "Confirm?", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            {
                int id = Convert.ToInt32(txbFoodID.Text);

                if (FoodDAO.Instance.DeleteFood(id))
                {
                    MessageBox.Show("Xóa món thành công");
                    LoadListFood();
                    if (deleteFood != null)
                        deleteFood(this, new EventArgs());
                }
                else
                {
                    MessageBox.Show("Có lỗi khi xóa thức ăn");
                }

            }
            else
                return;
        }

        private event EventHandler insertFood;
        public event EventHandler InsertFood
        {
            add { insertFood += value; }
            remove { insertFood -= value; }
        }

        private event EventHandler insertTable;
        public event EventHandler InsertTable
        {
            add { insertTable += value; }
            remove { insertTable -= value; }
        }

        private event EventHandler deleteFood;
        public event EventHandler DeleteFood
        {
            add { deleteFood += value; }
            remove { deleteFood -= value; }
        }

        private event EventHandler updateFood;
        public event EventHandler UpdateFood
        {
            add { updateFood += value; }
            remove { updateFood -= value; }
        }

        private event EventHandler editCategory;
        public event EventHandler EditCategory
        {
            add { editCategory += value; }
            remove { editCategory -= value; }
        }

        private event EventHandler deleteTable;
        public event EventHandler DeleteTable
        {
            add { deleteTable += value; }
            remove { deleteTable -= value; }
        }


        private event EventHandler deleteCategory;
        public event EventHandler DeleteCategory
        {
            add { deleteCategory += value; }
            remove { deleteCategory -= value; }
        }

        private void txbTienLuong_TextChanged(object sender, EventArgs e)
        {

        }
        //xu li them xoa sua bang nv
        private void btnAddNV_Click(object sender, EventArgs e)
        {
            string Ten = txbTenNV.Text;
            string DiaChi = txbDiaChi.Text;
            string Sdt = txbSDT.Text;
            DateTime NgaySinh = dtpkNgaySinh.Value; //txbNgaySinh.Text;
            string GioiTinh = (cbGioiTinh.SelectedItem as Sex).Gioitinh;
            float Luong = (float)nmLuong.Value;

            if (NhanVienDAO.Instance.InsertNhanVien(Ten, NgaySinh, GioiTinh, DiaChi, Sdt, Luong))
            {
                MessageBox.Show("Thêm nhân viên thành công");
                LoadListNhanVien();

            }
            else
            {
                MessageBox.Show("Có lỗi khi thêm nhân viên");
            }
        }

        private void btnDeleteNV_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txbID.Text);

            if (NhanVienDAO.Instance.DeleteNhanVien(id))
            {
                MessageBox.Show("Xóa nhân viên thành công");
                LoadListNhanVien();
            }
            else
            {
                MessageBox.Show("Có lỗi khi xóa nhân viên");
            }

        }

        private void btnUpdateNV_Click(object sender, EventArgs e)
        {

            string Ten = txbTenNV.Text;
            string DiaChi = txbDiaChi.Text;
            string Sdt = txbSDT.Text;
            DateTime NgaySinh = dtpkNgaySinh.Value;
            string GioiTinh = (cbGioiTinh.SelectedItem as Sex).Gioitinh;
            float Luong = (float)nmLuong.Value;
            int id = Convert.ToInt32(txbID.Text);

            if (NhanVienDAO.Instance.UpdateNhanVien(id, Ten, NgaySinh, GioiTinh, DiaChi, Sdt, Luong))
            {
                MessageBox.Show("Cập nhật nhân viên thành công");
                LoadListNhanVien();
            }
            else
            {
                MessageBox.Show("Có lỗi khi cập nhật nhân viên");
            }
        }
        //category
        private void btnAddCategory_Click(object sender, EventArgs e)
        {
            string name = txbCategoryName.Text;

            if (CategoryDAO.Instance.InsertFoodCategory(name))
            {
                MessageBox.Show("Thêm loại món thành công");
                LoadListFoodCategory();
            }
            else
            {
                MessageBox.Show("Có lỗi khi thêm loại món ăn");
            }
        }

        private void btnDelCategogy_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Xác nhận xóa: " + txbCategoryName.Text + " ?", "Confirm?", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            {
                int id = Convert.ToInt32(txbIDCategory.Text);

                if (CategoryDAO.Instance.DeleteFoodCategory(id))
                {
                    MessageBox.Show("Xóa loại món ăn thành công");
                    LoadListFood();
                    LoadListFoodCategory();
                    LoadCategoryIntoCombobox(cbFoodCategory);//load len
                    if (deleteCategory != null)
                        deleteCategory(this, new EventArgs());
                }
                else
                {
                    MessageBox.Show("Có lỗi khi xóa loại món ăn");
                }
            }
            else
            {
                return;
            }
        }

        private void btnEditCategory_Click(object sender, EventArgs e)
        {
            string name = txbCategoryName.Text;
            int id = Convert.ToInt32(txbIDCategory.Text);

            if (CategoryDAO.Instance.UpdateFoodCategory(name, id))
            {
                MessageBox.Show("Sửa loại món ăn thành công");
                LoadListFood();
                LoadCategoryIntoCombobox(cbFoodCategory);
                LoadListFoodCategory();
                if (editCategory != null)
                {
                    editCategory(this, new EventArgs());
                }

            }
            else
            {
                MessageBox.Show("Có lỗi khi sửa loại món ăn");
            }
        }

        private void btnViewCategory_Click(object sender, EventArgs e)
        {
            LoadListFoodCategory();
        }
        //xu li ban
        private void btnAddTable_Click(object sender, EventArgs e)
        {
            if (TableDAO.Instance.InsertTable())
            {
                MessageBox.Show("Thêm bàn thành công");
                LoadListFoodTable();

                if (insertTable != null)
                    insertTable(this, new EventArgs());
            }
            else
            {
                MessageBox.Show("Có lỗi khi thêm bàn");
            }
        }

        private void btnDelTable_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Xác nhận xóa: " + txbNameTable.Text + " ?", "Confirm?", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            {
                if (cbTableStatus.Text.Equals("Có người"))
                {
                    if (MessageBox.Show(txbNameTable.Text + " đang có người, xác nhận xóa ?", "Confirm?", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.No)
                    {
                        return;
                    }

                }
                int id = Convert.ToInt32(txbIDTable.Text);

                if (TableDAO.Instance.DeleteTable(id))
                {
                    MessageBox.Show("Xóa bàn thành công");
                    LoadListFoodTable();
                    if (deleteTable != null)
                        deleteTable(this, new EventArgs());
                }
                else
                {
                    MessageBox.Show("Có lỗi khi xóa bàn");
                }

            }
            else
                return;
        }

        private void btnEditTable_Click(object sender, EventArgs e)
        {

        }

        private void btnViewTable_Click(object sender, EventArgs e)
        {
            LoadListFoodTable();
        }

        private void txbFoodID_TextChanged_1(object sender, EventArgs e)
        {
            if (dtgvFood.SelectedCells.Count > 0)
            {
                int id = (int)dtgvFood.SelectedCells[0].OwningRow.Cells["idCategory"].Value;//lay data tu dtgv, lay o dau dk chon, lay dong lay ô có  CategoryID

                Category cateogory = CategoryDAO.Instance.GetCategoryByID(id);

                //cbFoodCategory.SelectedItem = cateogory;

                int index = -1;
                int i = 0;
                foreach (Category item in cbFoodCategory.Items)
                {
                    if (item.Id == cateogory.Id)
                    {
                        index = i;
                        break;
                    }
                    i++;
                }

                cbFoodCategory.SelectedIndex = index;
            }
        }

        private void btnFindFood_Click(object sender, EventArgs e)
        {
            foodList.DataSource = SearchFoodByName(tbFindFood.Text);
        }

        private void txbIDTable_TextChanged(object sender, EventArgs e)
        {
            if (dtgvTable.SelectedCells.Count > 0)
            {
                int id = (int)dtgvTable.SelectedCells[0].OwningRow.Cells["ID"].Value;//lay data tu dtgv, lay o dau dk chon, lay dong lay ô có  CategoryID

                Table TS = TableDAO.Instance.GetTableStatusByID(id);

               
                int index = -1;
                int i = 0;
                foreach (TableStatus item in cbTableStatus.Items)
                {
                    if (item.Name == TS.Status)
                    {
                        index = i;
                        break;
                    }
                    i++;
                }

                cbTableStatus.SelectedIndex = index;
            }
        }

        public Account acc;
        private void txbUserName_TextChanged(object sender, EventArgs e)
        {
            if (dtgvAcc.SelectedCells.Count > 0)
            {
                try
                {
                    int type = (int)dtgvAcc.SelectedCells[0].OwningRow.Cells["Type"].Value;//lay data tu dtgv, lay o dau dk chon, lay dong lay ô có  CategoryID

                    AccountType AccType = AccountTypeDAO.Instance.GetAccTypeByType(type);

                    //cbTypeAcc.SelectedItem = AccType;
                    //cbTypeAcc.DisplayMember = "name";
                    int index = -1;
                    int i = 0;
                    foreach (AccountType item in cbTypeAcc.Items)
                    {
                        if (item.Type == AccType.Type)
                        {
                            index = i;
                            break;
                        }
                        i++;
                    }

                    cbTypeAcc.SelectedIndex = index;
                    cbTypeAcc.DisplayMember = "name";
                }
                catch
                {
                    return;
                }

            }
        }

        private void btnAddAccount_Click(object sender, EventArgs e)
        {
            CreateAccount f = new CreateAccount();
            f.ShowDialog();
            LoadListAccount();
        }

        private void btnDelAcc_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Xác nhận xóa tài khoản: " + txbUserName.Text + " ?", "Confirm?", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            {
                if (txbUserName.Text.Equals(acc.UserName.ToString()))
                {
                    MessageBox.Show("Tài khoản này đang đăng nhập!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;

                }
                string username = txbUserName.Text;

                if (AccountDAO.Instance.DeleteAcc(username))
                {
                    MessageBox.Show("Xóa tài khoản thành công");
                    LoadListAccount();
                    //if (deleteTable != null)
                    //    deleteTable(this, new EventArgs());
                }
                else
                {
                    MessageBox.Show("Có lỗi khi xóa tài khoản");
                }

            }
            else
                return;
        }

        #endregion

        private void btnEditAcc_Click(object sender, EventArgs e)
        {
            string username = txbUserName.Text;
            string displayname = txbDisplayName.Text;
            int type = (cbTypeAcc.SelectedItem as AccountType).Type;
            if (AccountDAO.Instance.UpdateAccount(username, displayname, type))
            {
                MessageBox.Show("Sửa tài khoản thành công");
                LoadListAccount();

            }
        }

        private void txbID_TextChanged(object sender, EventArgs e)
        {
            if (dtgvNhanVien.SelectedCells.Count > 0)
            {
                string gioitinh = (string)dtgvNhanVien.SelectedCells[0].OwningRow.Cells["GioiTinh"].Value;//lay data tu dtgv, lay o dau dk chon, lay dong lay ô có  CategoryID

                Sex gt = new Sex(gioitinh);
                //cbFoodCategory.SelectedItem = cateogory;
                //cbGioiTinh.SelectedItem = gt;
                //cbGioiTinh.DisplayMember = "gioitinh";
                int index = -1;
                int i = 0;
                foreach (Sex item in cbGioiTinh.Items)
                {
                    if (item.Gioitinh == gt.Gioitinh)
                    {
                        index = i;
                        break;
                    }
                    i++;
                }
                cbGioiTinh.SelectedIndex = index;
            }
        }



        private void btnResetPass_Click(object sender, EventArgs e)
        {
            string username = txbUserName.Text;
            if (AccountDAO.Instance.ResetPassword(username))
            {
                MessageBox.Show("reset password thành công.");
                LoadListAccount();
            }
            else
            {
                MessageBox.Show("Có lỗi trong quá trình reset password.");
            }
        }

        private void btn_FirstBillPage_Click(object sender, EventArgs e)
        {
            txbPageBill.Text = "1";
            //BillDAO.Instance.GetBillListByDateAndPage(dtpkFromDate.Value, dtpkToDate.Value, 1);
            LoadListBillByDateAndPage(dtpkFromDate.Value, dtpkToDate.Value, 1);
        }

        private void btn_PreviousBillPage_Click(object sender, EventArgs e)
        {
            int page = Convert.ToInt32(txbPageBill.Text);
            if (page > 1)
            {
                page--;
                txbPageBill.Text = page.ToString();
                LoadListBillByDateAndPage(dtpkFromDate.Value, dtpkToDate.Value, page);
            }

        }

        private void txbPageBill_TextChanged(object sender, EventArgs e)
        {
            dtgvBill.DataSource = BillDAO.Instance.GetBillListByDateAndPage(dtpkFromDate.Value, dtpkToDate.Value, Convert.ToInt32(txbPageBill.Text));
        }

        private void btn_NextBillPage_Click(object sender, EventArgs e)
        {
            int page = Convert.ToInt32(txbPageBill.Text);
            int sumRecord = BillDAO.Instance.GetNumBillListByDate(dtpkFromDate.Value, dtpkToDate.Value);
            int lastPage = sumRecord / 10;
            if (sumRecord % 10 != 0)
                lastPage++;
            if (page == lastPage)
                return;

            page++;
            txbPageBill.Text = page.ToString();
            LoadListBillByDateAndPage(dtpkFromDate.Value, dtpkToDate.Value, page);


        }

        private void btn_LastBillPage_Click(object sender, EventArgs e)
        {
            int sumRecord = BillDAO.Instance.GetNumBillListByDate(dtpkFromDate.Value, dtpkToDate.Value);

            int lastPage = sumRecord / 10;
            if (sumRecord % 10 != 0)
                lastPage++;
            txbPageBill.Text = lastPage.ToString();
            LoadListBillByDateAndPage(dtpkFromDate.Value, dtpkToDate.Value, lastPage);
        }
        
    }
}
