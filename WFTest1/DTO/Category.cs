using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFTest1.DTO
{
    public class Category
    {
        public Category(int id,string Name)
        {
            this.id = id;
            this.name = Name;
        }

        public Category(DataRow row)
        {
            this.id = (int)row["id"];
            this.name = row["name"].ToString();
        }

        int id;
        string name;

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
    }
}
