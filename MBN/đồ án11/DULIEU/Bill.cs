using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace đồ_án11.DULIEU
{
     class Bill
    {
        public Bill (int id , DateTime? dateCheckOut, int sl)
        {
            this.ID = id;
            this.DateCheckOut = dateCheckOut;
            this.SL = sl;
        }

        public Bill(DataRow row)
        {
            this.ID = (int)row["id"];
            this.DateCheckOut = (DateTime?)row["dateCheckOut"];
            this.SL = (int)row["sl"];
        }
        
        private int sL;
        public int SL
        {
            get { return sL; }
            set { sL = value; }
        }
        

        private DateTime? dateCheckOut;

        public DateTime? DateCheckOut
        {
            get { return dateCheckOut; }
            set { dateCheckOut = value; }
        }

        private int iD;
        public int ID
        {
            get { return iD; }
            set { iD = value; }
        }
    }
}
