using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFTest1.DTO
{
    public class AccountType
    {
        private int type;
        private string name;

        public string Name { get => name; set => name = value; }
        public int Type { get => type; set => type = value; }

        public AccountType(int type, string name)
        {
            this.type = type;
            this.name = name;
        }

        public AccountType(DataRow row)
        {
            this.type = (int)row["type"];
            this.name = row["name"].ToString();
        }
    }
}
