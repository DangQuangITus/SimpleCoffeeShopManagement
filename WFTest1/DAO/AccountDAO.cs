using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using WFTest1.DTO;//14

namespace WFTest1.DAO
{
    public class AccountDAO
    {

        private static AccountDAO instance;

        public static AccountDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new AccountDAO();
                }
                return instance;
            }
            private set { instance = value; }
        }

        private AccountDAO() { }

        public bool Login(string username,string passWord)
        {
            DataTable result = null;
           if (passWord != "0") {
               
                string hasPass = EncodingPass(passWord);
               
                string query = "USP_Login @username, @passWord";
                result = DataProvider.Instance.ExecuteQuery(query, new object[] { username, hasPass });
            }
            else
            {
                string query = "USP_Login @username, @passWord";
                result = DataProvider.Instance.ExecuteQuery(query, new object[] { username, passWord });
            }
            
            return result.Rows.Count > 0;// vi executeNonQuery chỉ trả ra số vs delete uptate insert  
        }

        public string EncodingPass(string passWord)
        {
            byte[] temp = ASCIIEncoding.ASCII.GetBytes(passWord);
            byte[] hasData = new MD5CryptoServiceProvider().ComputeHash(temp);

            string hasPass = "";
            foreach (byte item in hasData)
            {
                hasPass += item;
            }
            return hasPass;
        }
        //14
        public bool UpdateAccount(string userName, string displayName, string pass, string newPass)
        {
            string hasPass = EncodingPass(newPass);
            int result = DataProvider.Instance.ExecuteNonQuery("exec USP_UpdateAccount @userName , @displayName , @password , @newPassword", new object[] { userName, displayName, pass, hasPass });
            // co update so dong > 0
            return result > 0;
        }


        public bool ResetPassword(string username)
        {
            string query = "UPDATE dbo.Account SET PassWord = 0 WHERE UserName = '" + username + "'";
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public Account GetAccountByUserName(string userName)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("Select * from account where userName = '" + userName + "'");//username la kieu chuoi

            foreach (DataRow item in data.Rows)
            {
                return new Account(item);
            }

            return null;
        }
        //xu li data
        public List<Account> GetListAccountByCateID(int id)
        {
            List<Account> list = new List<Account>();
            string query = "SELECT * FROM dbo.Account WHERE id = " + id;
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            if (data.Rows.Count > 0)
            {
                foreach (DataRow item in data.Rows)
                {
                    Account temp = new Account(item);
                    list.Add(temp);
                }
            }


            return list;
        }

        public DataTable GetListAccount()
        {
            return DataProvider.Instance.ExecuteQuery("SELECT UserName,DisplayName,Type FROM dbo.Account");
        }

        public bool ExistAccount(string username)
        {
            string query = string.Format("SELECT * FROM dbo.Account WHERE UserName = N'{0}' ", username);
           DataTable data = DataProvider.Instance.ExecuteQuery("Select * from account where UserName = '" + username + "'");

            return data.Rows.Count > 0;
        }

        public bool CreateNewAccount(string username, string displayname, string pass, int type)
        {
            string hasPass = EncodingPass(pass);
            int result = DataProvider.Instance.ExecuteNonQuery("exec USP_CreateNewAccount @username, @displayname, @pass, @type", new object[] { username, displayname, hasPass, type });
            return result > 0;
        }

        public bool UpdateAccount(string userName, string displayName, int type)
        {
            int result = DataProvider.Instance.ExecuteNonQuery("exec USP_UpdateAccount2 @userName , @displayName , @type", new object[] { userName, displayName, type });
            // co update so dong > 0
            return result > 0;
        }

        public bool DeleteAcc(string username)
        {
            string query = string.Format("DELETE dbo.Account WHERE UserName = N'" + username + "'");
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
    }
}
