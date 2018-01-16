using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFTest1.DTO
{
    public class Sex
    {
        string gioitinh;

        public string Gioitinh { get => gioitinh; set => gioitinh = value; }

       public Sex(string name)
        {
            this.gioitinh = name;
        }
        public Sex(DataRow row)
        {
            this.gioitinh = row["gioitinh"].ToString();
        }
    }
}
