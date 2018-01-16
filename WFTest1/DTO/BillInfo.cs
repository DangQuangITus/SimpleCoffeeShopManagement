using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFTest1.DTO
{
    public class BillInfo
    {
        private int id;
        private int billID;
        private int foodID;
        private int countFood;
        public int Id { get => id; set => id = value; }
        public int BillID { get => billID; set => billID = value; }
        public int FoodID { get => foodID; set => foodID = value; }
        public int CountFood { get => countFood; set => countFood = value; }

        public BillInfo(int id,int BillID,int foodID,int count)
        {
            this.id = id;
            this.billID = BillID;
            this.foodID = foodID;
            this.countFood = count;
        }

        public BillInfo(DataRow row)
        {
            this.Id = (int)row["id"];
            this.BillID = (int)row["idBill"];
            this.foodID = (int)row["idFood"];
            this.countFood = (int)row["count"];
        }
    }
}
