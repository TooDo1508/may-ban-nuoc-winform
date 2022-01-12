using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using đồ_án11.AddTable;

namespace đồ_án11
{
    public partial class DoUong : UserControl
    {
        public DoUong()
        {
            InitializeComponent();
            LoadDrink();
            DrinkClick();
        }
        void LoadDrink()
        {
            string query = "select idD,name as TênĐồUống, price as Giá,soluong as SốLượng, idM from Drink";
            dataGridView1.DataSource = DataProvider.Instance.ExcuteQuery(query);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = textBox3.Text;
            int idM = (int)numericUpDown3.Value;
            int price = (int)numericUpDown1.Value;
            int soluong = (int)numericUpDown2.Value;
            if (AddDrink.Instance.InsertDrink(name, price, soluong, idM))
            {
                MessageBox.Show("Thêm đồ uông thành công !");
                
            }
        }
        void DrinkClick()
        {
            textBox1.DataBindings.Add(new Binding("Text", dataGridView1.DataSource, "idD"));
            textBox3.DataBindings.Add(new Binding("Text", dataGridView1.DataSource, "TênĐồUống"));
            numericUpDown1.DataBindings.Add(new Binding("Value", dataGridView1.DataSource, "Giá"));
            numericUpDown2.DataBindings.Add(new Binding("Value", dataGridView1.DataSource, "SốLượng"));
            numericUpDown3.DataBindings.Add(new Binding("Text", dataGridView1.DataSource, "idM"));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string name = textBox3.Text;
            int idM = (int)numericUpDown3.Value;
            int price = (int)numericUpDown1.Value;
            int soluong = (int)numericUpDown2.Value;
            int idD = Convert.ToInt32(textBox1.Text);
            if (AddDrink.Instance.UpdateDrink2(name, price, soluong, idM, idD))
            {
                MessageBox.Show("Sửa đồ uống thành công");

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int idD = Convert.ToInt32(textBox1.Text);
            if (AddDrink.Instance.DeleteDrink(idD))
            {
                MessageBox.Show("Xóa đồ uống thành công");
                
            }
        }
    }
}
