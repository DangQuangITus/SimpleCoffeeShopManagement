using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFTest1.DTO
{
    public class Menu
    {
        public Menu(string food, int count, float price, float totalprice = 0)
        {
            this.m_foodName = food;
            this.m_count = count;
            this.m_price = price;
            this.m_totalPrice = totalprice;
        }

        public Menu(DataRow row)
        {
            this.m_foodName = row["name"].ToString();
            this.m_count = (int)row["countFood"];
            this.m_price = (float)Convert.ToDouble(row["price"].ToString());//vì float có f nên phải convert qua to double
            this.m_totalPrice = (float)Convert.ToDouble(row["Total Price"].ToString());
        }
        private string m_foodName;
        private int m_count;
        private float m_totalPrice;
        private float m_price;

        public string FoodName { get => m_foodName; set => m_foodName = value; }
        public int Count { get => m_count; set => m_count = value; }
        public float TotalPrice { get => m_totalPrice; set => m_totalPrice = value; }
        public float Price { get => m_price; set => m_price = value; }
    }
}
