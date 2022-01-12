using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace đồ_án11.AddTable
{
    class AddAccout
    {
        private static AddAccout instance;

        public static AddAccout Intance
        {
            get { if ( instance == null) instance = new AddAccout(); return instance;}
            private set { instance = value; }
        }
        private AddAccout(){}


        public bool Login(string username, string password)
        {
            string query = "SELECT * FROM dbo.Account WHERE Username = N'"+ username + "' and Password = N'"+ password + "' ";

            DataTable result = DataProvider.Instance.ExcuteQuery(query, new object[] {username, password });

            return result.Rows.Count > 0;
        }
    }
}
