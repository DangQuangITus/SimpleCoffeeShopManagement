using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFTest1.DTO
{
    public class Food
    {
        public Food(int id, string name, int idCate, float price)
        {
            this.id = id;
            this.name = name;
            this.idCategory = idCate;
            this.price = price;
        }

        public Food(DataRow row)
        {
            this.id = (int)row["id"];
            this.name = row["name"].ToString();
            this.idCategory = (int)row["idCategory"];
            this.price = (float)Convert.ToDouble(row["price"].ToString());
        }
        int id;
        string name;
        int idCategory;
        float price;

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public int IdCategory { get => idCategory; set => idCategory = value; }
        public float Price { get => price; set => price = value; }
    }
}
