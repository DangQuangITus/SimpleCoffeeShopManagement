using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFTest1.DTO
{
   public class Table//kieu dl trung gian để chuyển thành button xử lí các control
    {
       
        private string name;
        private string status;
        private int id;
        public int ID//mặc định in hoa lên
        {
            get
            {
                return this.id;
            }
            set
            {
                this.id = value;
            }
        }

        public string Name { get => name; set => name = value; }
        public string Status { get => status; set => status = value; }

        public Table(DataRow row)//TableDAO.Instance.ExecuteQuery("USP_... ");
        {
            this.id = (int)row["id"];
            this.name = row["name"].ToString();
            this.status = row["status"].ToString();
        }

        public Table(int id,string name,string status)
        {
            this.id = id;
            this.name = name;
            this.status = status;
        }
    }
}
