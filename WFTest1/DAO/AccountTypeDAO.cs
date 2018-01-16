using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WFTest1.DTO;

namespace WFTest1.DAO
{
    class AccountTypeDAO
    {
        private static AccountTypeDAO instance;

        public static AccountTypeDAO Instance
        {
            get
            {
                if (AccountTypeDAO.instance == null)
                    instance = new AccountTypeDAO();
                return AccountTypeDAO.instance;
            }
            private set => instance = value;
        }

        public AccountTypeDAO() { }

        public List<AccountType> GetListAccountType()
        {
            List<AccountType> list = new List<AccountType>();

            string query = "SELECT * FROM dbo.TypeAccount";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            if (data.Rows.Count > 0)
            {
                foreach (DataRow item in data.Rows)
                {
                    AccountType temp = new AccountType(item);
                    list.Add(temp);
                }
            }

            return list;

        }

        public AccountType GetAccTypeByType(int type)
        {
            AccountType acctype = null;
            string query = "SELECT * FROM dbo.TypeAccount WHERE type = " + type;
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            if (data.Rows.Count > 0)
            {
                foreach (DataRow item in data.Rows)
                {
                    acctype = new AccountType(item);
                    return acctype;
                 }
            }
            return acctype;

        }


    }
}
