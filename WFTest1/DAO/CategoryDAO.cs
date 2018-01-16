using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WFTest1.DTO;

namespace WFTest1.DAO
{
    public class CategoryDAO
    {
        private static CategoryDAO instance;

        public static CategoryDAO Instance
        {
            get
            {
                if (instance == null)
                    CategoryDAO.instance = new CategoryDAO();
                return CategoryDAO.instance;
            }
            private set => instance = value;
        }
        public CategoryDAO() { }

        public List<Category> GetListCategory()
        {
            List<Category> listCategory = new List<Category>();
            string query = "SELECT * FROM dbo.FoodCategory";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            if(data.Rows.Count > 0)
            {
                foreach(DataRow item in data.Rows)
                {
                    Category temp = new Category(item);
                    listCategory.Add(temp);
                }
            }

            return listCategory;
        }
        //lay ra theo id 16
        public Category GetCategoryByID(int id)
        {
            Category category = null;

            string query = "select * from FoodCategory where id = " + id;

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                category = new Category(item);
                return category;
            }

            return category;
        }

        //xu lí phan load data ra dtgv
        public List<Category> GetListCategoryByCateID(int id)
        {
            List<Category> list = new List<Category>();
            string query = "SELECT * FROM dbo.FoodCategory WHERE id = " + id;
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            if (data.Rows.Count > 0)
            {
                foreach (DataRow item in data.Rows)
                {
                    Category temp = new Category(item);
                    list.Add(temp);
                }
            }


            return list;
        }

        public List<Category> GetListFoodCategory()//15
        {
            List<Category> list = new List<Category>();//tra ve 1 danh sach

            string query = "select * from FoodCategory";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                Category food = new Category(item);
                list.Add(food);
            }

            return list;
        }
        //17 them, xoa sửa
        public bool InsertFoodCategory(string name)
        {
            string query = string.Format("INSERT dbo.FoodCategory ( name )VALUES  ( N'{0}')", name);//dung string format nhanh hơn
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        public bool UpdateFoodCategory(string name, int id)
        {
            string query = string.Format("UPDATE dbo.FoodCategory SET name = N'{0}' WHERE id = {1}", name, id);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        public bool DeleteFoodCategory(int idFoodCategory) //khi xoa phai xoa billinfo trk
        {
            int result = 0;
           
            if (MessageBox.Show("Xác nhận xóa danh mục này cùng với các món ăn của nó ? \n Chú ý: không thể hoàn tác!", "Confirm?", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            {
                // xóa Food có liên quan tới danh mục này trước
                result = DataProvider.Instance.ExecuteNonQuery("USP_DeleteFoodCategory @idCate", new object[] { idFoodCategory });
            }
              
            return result > 0;
        }
    }
}
