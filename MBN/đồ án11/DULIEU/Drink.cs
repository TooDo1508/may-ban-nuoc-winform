using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace đồ_án11.DULIEU
{
    public class Drink
    {
        public Drink(  int id, int idm,int price, int soluong, string name)
        {
            this.ID = id;
            this.IDM = idm;
            this.Price = price;
            this.soluong = soluong;
            this.Name = name;

        }
        public Drink(DataRow row)
        {
            this.ID = (int)row["idD"];
            this.IDM = (int)row["idM"];
            this.Price = (int)row["price"];
            this.soluong = (int)row["soluong"];
            this.Name = row["name"].ToString();

        }


        private int iD;
        public int ID
        {
            get { return iD; }
            set { iD = value; }
        }

        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private int idm;
        public int IDM
        {
            get { return idm; }
            set { idm = value; }
        }

        private int price;
        public int Price
        {
            get { return price; }
            set { price = value; }
        }

        private int soluong;
        public int Soluong
        {
            get { return soluong; }
            set { soluong = value; }
        }
    }
}
