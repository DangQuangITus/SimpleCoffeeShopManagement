using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WFTest1.DTO;

namespace WFTest1.DAO
{
    public class SexDAO
    {
        private static SexDAO instance;

        public static SexDAO Instance
        {
            get
            {
                if (SexDAO.instance == null)
                    instance = new SexDAO();
                return SexDAO.instance;
            }
           private set => instance = value;
        }

        public SexDAO() { }

        public List<Sex> GetListSex()
        {
            List<Sex> list = new List<Sex>();
            string query = "SELECT * FROM dbo.GioiTinh ";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            if(data.Rows.Count > 0)
            {
                foreach(DataRow item in data.Rows)
                {
                    Sex temp = new Sex(item);
                    list.Add(temp);
                }
            }
            return list;
        }

        //public Sex GetGioiTinh(string gioitinh)
        //{

        //}
    }
}
