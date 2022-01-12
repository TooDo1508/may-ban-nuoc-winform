using đồ_án11.AddTable;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace đồ_án11
{
    public partial class RutTien : Form
    {
        public RutTien()
        {
            InitializeComponent();
            Data();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            label1.Text = "bbbbbbbbbbbbbbbbbbbbbb";
            label4.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            label4.Text = "bbbbbbbbbbbbbbbbbbbbbb";
            label1.Text = "";
           
        }
        void Data()
        {
            dataGridView1.Visible = false;
            string querry = " select * from May";
            dataGridView1.DataSource = DataProvider.Instance.ExcuteQuery(querry);
            
            label3.Text = dataGridView1.Rows[0].Cells[2].Value.ToString();
            label5.Text = dataGridView1.Rows[1].Cells[2].Value.ToString();

            label1.Text = "bbbbbbbbbbbbbbbbbbbbbb";
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {        
            if (label1.Text != string.Empty)
            {
                if (MessageBox.Show("Bạn có muốn Rút Tiền Máy 1 không? ", "Thông Báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                { 
                    MessageBox.Show("Tổng doanh thu của Máy 1 là : " + label3.Text+"đ  VND");
                    label3.Text = 0.ToString();
                    DataProvider.Instance.ExcuteQuery("update May set DoanhThu = 0 where id =1");
                }
            }

            if (label4.Text != string.Empty)
            {
                if (MessageBox.Show("Bạn có muốn Rút Tiền Máy 2 không? ", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    MessageBox.Show("Tổng doanh thu của Máy 2 là : " + label5.Text+"đ  VND");
                    label5.Text = 0.ToString();
                    DataProvider.Instance.ExcuteQuery("update May set DoanhThu = 0 where id =2");
                }    

            }
                       
        }
    }
}
