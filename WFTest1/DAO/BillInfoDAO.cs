using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WFTest1.DTO;

namespace WFTest1.DAO
{
   public class BillInfoDAO
    {
        private static BillInfoDAO instance;

        public static BillInfoDAO Instance
        {
            get { if (instance == null) instance = new BillInfoDAO(); return BillInfoDAO.instance; }
            private set { BillInfoDAO.instance = value; }
        }
        public BillInfoDAO() { }
        public void DeleteBillInfoByFoodID(int id) // xóa 17
        {
            string query = "DELETE dbo.BillInfo WHERE idFood = ";
            DataProvider.Instance.ExecuteQuery(query + id);
        }
        public List<BillInfo> GetListBillInfo(int id)
        {
            string query = "SELECT * FROM dbo.BillInfo WHERE idBill = ";
            List<BillInfo> listBillInfo = new List<BillInfo>();
            DataTable data = DataProvider.Instance.ExecuteQuery(query + id);
            if(data.Rows.Count > 0)
            {
                foreach(DataRow item in data.Rows)
                {
                    BillInfo temp = new BillInfo(item);
                    listBillInfo.Add(temp);
                }
            }
            return listBillInfo;
        }


        public void InsertBillInfo(int BillID,int FoodID,int Count)
        {
            DataProvider.Instance.ExecuteNonQuery("exec USP_insertBillInfo @BillID, @FoodID, @Count", new object[] { BillID, FoodID, Count });
        }
    }
}
