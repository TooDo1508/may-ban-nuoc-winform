using đồ_án11.DULIEU;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace đồ_án11.AddTable
{
    public class AddDrink
    {
        private static AddDrink instance;


        public static AddDrink Instance
        {
            get { if (instance == null) instance = new AddDrink(); return AddDrink.instance; }
            private set { AddDrink.instance = value; }

        }
        private AddDrink() { }

        public List<Drink> LoadDrink()

        {
            List<Drink> list = new List<Drink>();
            string query = " SELECT * from dbo.Drink";
            DataTable data = DataProvider.Instance.ExcuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                Drink drink = new Drink(item);
                list.Add(drink);
            }

            return list;
        }
         public bool UpdateDrink(int id, int sl)
        {
            string query = string.Format("update dbo.Drink set soluong = soluong -" + sl +" where idD =" + id);
            int result = DataProvider.Instance.ExcuteNonQuery(query);
            return result > 0;
        }
        public bool InsertDrink( string name,int price,int soluong,int idM)
        {
            string query = string.Format("insert into dbo.Drink(name,price,soluong,idM)values (N'{0}',{1},{2},{3})",name,price,soluong,idM);
            int result = DataProvider.Instance.ExcuteNonQuery(query);
            return result > 0;
        }

        public bool UpdateDrink2(string name, int price, int soluong, int idM, int idD)
        {
            string query = string.Format("update dbo.Drink set price = {0}, soluong = {1}, idM = {2}, name = N'{3}' where idD ={4}",price,soluong,idM,name,idD);
            int result = DataProvider.Instance.ExcuteNonQuery(query);
            return result > 0;
        }
        public bool DeleteDrink(int idD)
        {
            string query = string.Format("Delete from Drink where idD = {0}", idD);
            int result = DataProvider.Instance.ExcuteNonQuery(query);
            return result > 0;
        }
  
    }
      
}
