using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WFTest1.DTO;

namespace WFTest1.DAO
{
    public class FoodDAO
    {
        private static FoodDAO instance;

        public static FoodDAO Instance
        {
            get
            {
                if (FoodDAO.instance == null)
                    instance = new FoodDAO();
                return FoodDAO.instance;

            }
            private set => instance = value;
        }

        public FoodDAO() { }
        public List<Food> GetListFoodByCateID(int id)
        {
            List<Food> list = new List<Food>();
            string query = "SELECT * FROM dbo.Food WHERE idCategory = "+ id;
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            if(data.Rows.Count > 0)
            {
                foreach(DataRow item in data.Rows)
                {
                    Food temp = new Food(item);
                    list.Add(temp);
                }
            }


            return list;
        }
        public List<Food> SearchFoodByName(String name)
        {
            List<Food> list = new List<Food>();//tra ve 1 danh sach

            string query = string.Format("select * from Food where dbo.fuConvertToUnsign1(name) LIKE N'%' + dbo.fuConvertToUnsign1(N'{0}') + '%'", name);

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                Food food = new Food(item);
                list.Add(food);
            }

            return list;
        }

        public List<Food> GetListFood()//15
        {
            List<Food> list = new List<Food>();//tra ve 1 danh sach

            string query = "SELECT * FROM dbo.Food";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                Food food = new Food(item);
                list.Add(food);
            }

            return list;
        }
        //17 them, xoa sửa
        public bool InsertFood(string name, int id, float price)
        {
         
            string query = string.Format("INSERT dbo.Food ( name, idCategory, price )VALUES  ( N'{0}', {1}, {2})", name, id, price);//dung string format nhanh hơn
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        public bool UpdateFood(int idFood, string name, int id, float price)
        {
            string query = string.Format("UPDATE dbo.Food SET name = N'{0}', idCategory = {1}, price = {2} WHERE id = {3}", name, id, price, idFood);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        public bool DeleteFood(int idFood) //khi xoa phai xoa billinfo trk
        {
            BillInfoDAO.Instance.DeleteBillInfoByFoodID(idFood);

            string query = string.Format("Delete Food where id = {0}", idFood);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
        
    }
}
