using đồ_án11.AddTable;
using đồ_án11.DULIEU;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace đồ_án11
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            LoadDrink();



            TextB();
        }

        private void btnLogin_Click_1(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string password = textBox2.Text;
            if (Login(username, password))
            {

                Form4 f = new Form4();
                this.Hide();
                f.ShowDialog();
                this.Show();
            }
            else
            {
                MessageBox.Show("Sai tài khoản hoặc mật khẩu!");
            }

        }
        bool Login(string username, string password)
        {
            return AddAccout.Intance.Login(username, password);
        }



        private void LoadDrink()
        {


            List<Drink> list = AddDrink.Instance.LoadDrink();
            

            foreach (Drink item in list)
            {
                if (Convert.ToInt32(item.IDM) == 1)
                {
                    ListViewItem Item = new ListViewItem();
                    
                    Item.Text = item.Name.ToString() + Environment.NewLine + " Số lượng còn: " + item.Soluong;
                    Item.ImageIndex = item.ID;
                    listView2.Parent = this;
                    
                    listView2.Items.Add(Item);
                    Item.Tag = item.ID;
                    Item.Name = item.Name;

                    switch (item.Soluong)
                    {
                        case 0:
                            Item.Text = "Hết hàng";
                            Item.ImageIndex = 0;
                            break;
                        default:
                            break;

                    }
                }
            }
        }


        private void button3_Click(object sender, EventArgs e)
        {

            if (textBox3.Text != string.Empty)
            {
                if (textBox7.Text != string.Empty)
                {
                    if (textBox6.Text != string.Empty)
                    {
                        int a = 0;
                        int b = 0;
                        b = Convert.ToInt32(textBox6.Text);
                        if (numericUpDown1.Value != 0)
                        {
                            if (numericUpDown1.Value <= Convert.ToInt32(textBox9.Text))
                            {
                                a = Convert.ToInt32(numericUpDown1.Value.ToString()) * b;
                                label8.Text = a.ToString();
                                int id = Convert.ToInt32(textBox7.Text);
                                int sl = Convert.ToInt32(numericUpDown1.Value.ToString());

                                if (MessageBox.Show("Bạn có chắc chắn thanh toán ko", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                                {
                                    if (Convert.ToInt32(textBox3.Text) >= Convert.ToInt32(label8.Text))
                                    {
                                        textBox3.Text = (Convert.ToInt32(textBox3.Text) - Convert.ToInt32(label8.Text)).ToString();
                                        sodu = Convert.ToInt32(textBox3.Text);
                                        AddBill.Instance.AdddBill(id, sl);
                                        AddDrink.Instance.UpdateDrink(id, sl);
                                        listView2.Items.Clear();
                                        LoadDrink();
                                        Clear();
                                        MessageBox.Show("Bạn đã mua " + sl + " "+ textBox8.Text );
                                    }
                                    else
                                    {
                                        MessageBox.Show("Số dư của bạn không đủ. Mời nạp thêm tiền!!!!!");
                                    }
                                }

                            }
                            else
                            {
                                MessageBox.Show("Số lượng ko đủ mời chọn lại số lượng !!!!!");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Vui lòng chọn số lượng !");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Bạn chưa chọn đồ uống !");

                    }
                }
                else
                {
                    MessageBox.Show("Bạn chưa chọn sản phẩm");
                }
            } else
            {
                MessageBox.Show("Bạn chưa nạp tiền !!!! Bơm tiền vô");
            }


        }






        int sodu = 0;
        int DT1 = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            int n = 0;
            if (int.TryParse(this.textBox4.Text, out n))
            {

                sodu = sodu + Convert.ToInt32(textBox4.Text);
                DT1 = Convert.ToInt32(textBox4.Text);
                textBox4.Text = string.Empty;
                AddMay.Instance.NapTien1(DT1);
            }
            else
            {
                MessageBox.Show("Số tiền không hợp lệ !!!!!");
                textBox4.Text = string.Empty;
            }
            textBox3.Text = sodu.ToString();

        }
       
        private void button5_Click(object sender, EventArgs e)
        {
            fWelcome f = new fWelcome();
            this.Hide();
            f.ShowDialog();
            this.Close();
            
        }

      

        private void listView2_Click(object sender, EventArgs e)
        {
            List<Drink> list = AddDrink.Instance.LoadDrink();
            string name = listView2.SelectedItems[0].Name;
            Drink drinkdc = list.Single(m => m.Name == name);
            textBox8.Text = drinkdc.Name;
            textBox6.Text = drinkdc.Price.ToString();
            textBox7.Text = drinkdc.ID.ToString();
            textBox9.Text = drinkdc.Soluong.ToString();
            label8.Text = drinkdc.Price.ToString();
            numericUpDown1.Value = 0;
        }

        void TextB()
        {
            textBox6.Visible = false;
            textBox7.Visible = false;
            textBox8.Visible = false;
            textBox9.Visible = false;
        }
        void Clear()
        {
            numericUpDown1.Value = 0;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Random rd = new Random();
            int r, g, b;
            r = rd.Next(0,255);
            g = rd.Next(0, 255);
            b = rd.Next(0, 255);

            label6.ForeColor = Color.FromArgb(r,g,b);
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

            int a = 0;
            int b = 0;

            if (textBox6.Text != string.Empty)
            {
                b = Convert.ToInt32(textBox6.Text);
                if (numericUpDown1.Value != 0)
                {
                    if (numericUpDown1.Value <= Convert.ToInt32(textBox9.Text))
                    {
                        a = Convert.ToInt32(numericUpDown1.Value.ToString()) * b;
                        label8.Text = a.ToString();
                    }
                    else
                    {
                        MessageBox.Show("Số lượng ko đủ mời chọn lại");
                    }
                }
                
            }
            else
            {
                MessageBox.Show("Bạn chưa chọn đồ uống !");
            }
        }

        
    }
    
}
