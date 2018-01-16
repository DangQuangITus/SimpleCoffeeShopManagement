using System.Collections.Generic;
using System.Data;
using WFTest1.DTO;

namespace WFTest1.DAO
{
    public class MenuDAO
    {
        private static MenuDAO instance;

        public static MenuDAO Instance
        {
            get
            {
                if (instance == null)
                    MenuDAO.instance = new MenuDAO();
                return MenuDAO.instance;
            }
            private set => instance = value;
        }

        public MenuDAO() { }
        public List<Menu> GetListMenuByTable(int id)
        {
            string query = "SELECT F.name,bi.countFood,F.price,F.price* bi.countFood AS N'Total Price'FROM dbo.Food AS F, dbo.Bill AS B, dbo.BillInfo AS BI WHERE b.idTable = " + id + " AND BI.idBill = b.id AND B.status = 0 AND bi.idFood = F.id";
            List<Menu> listMenu = new List<Menu>();
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            if(data.Rows.Count > 0)
            {
                foreach(DataRow item in data.Rows)
                {
                    Menu menu = new Menu(item);
                    listMenu.Add(menu);

                }
            }

            return listMenu;
        }
    }
}
