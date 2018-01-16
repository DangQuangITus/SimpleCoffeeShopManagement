using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFTest1.DTO
{
    public class TableStatus
    {
        public TableStatus(string name)
        {
            this.name = name;
        }
        public TableStatus(DataRow row)
        {

            this.name = row["name"].ToString();
        }
        private string name;

        public string Name { get => name; set => name = value; }
    }
}
