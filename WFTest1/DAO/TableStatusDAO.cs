using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WFTest1.DTO;

namespace WFTest1.DAO
{
    public class TableStatusDAO
    {
        private static TableStatusDAO instance;

        public static TableStatusDAO Instance
        {
            get
            {
                if (instance == null)
                    TableStatusDAO.instance = new TableStatusDAO();
                return TableStatusDAO.instance;
            }
            private set { instance = value; }
        }

        public TableStatusDAO() { }

        public List<TableStatus> GetListTableStatus()
        {
            List<TableStatus> listTS = new List<TableStatus>();
            string query = "SELECT * FROM dbo.TableStatus ";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            if (data.Rows.Count > 0)
            {
                foreach (DataRow item in data.Rows)
                {
                    TableStatus temp = new TableStatus(item);
                    listTS.Add(temp);
                }
            }
            return listTS;
        }

        
    }
}
