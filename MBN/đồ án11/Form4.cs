using đồ_án11.AddTable;
using System;
using System.Windows.Forms;

namespace đồ_án11
{
    public partial class Form4 : Form
    {
        static Form4 _obj;
        public static Form4 Instance
        {
            get
            {
                if (_obj == null)
                {
                    _obj = new Form4();
                }
                return _obj;
            }

        }

        public Panel PanelHome
        {
            get { return panel3; }
            set { panel3 = value; }

        }
        public Button ChangeButton
        {
            get { return button6; }
            set { button6 = value; }
        }
        public Form4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label1.Text = "                                                                                                                                                            ";
            label3.Text = "";
            label4.Text = "";
            label5.Text = "";
            label2.Text = "";
            if (!Form4.Instance.PanelHome.Controls.ContainsKey("DoUong"))
            {
                DoUong un = new DoUong();
                un.Dock = DockStyle.Fill;
                Form4.Instance.PanelHome.Controls.Add(un);

            }
            Form4.Instance.PanelHome.Controls["DoUong"].BringToFront();
          
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label2.Text = "                                                                                                                                                            ";
            label3.Text = "";
            label4.Text = "";
            label5.Text = "";
            label1.Text = "";
            if (!Form4.Instance.PanelHome.Controls.ContainsKey("LichSuGiaoDich"))
            {
                LichSuGiaoDich un = new LichSuGiaoDich();
                un.Dock = DockStyle.Fill;
                Form4.Instance.PanelHome.Controls.Add(un);

            }
            Form4.Instance.PanelHome.Controls["LichSuGiaoDich"].BringToFront();
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            label3.Text = "                                                                                                                                                            ";
            label2.Text = "";
            label4.Text = "";
            label5.Text = "";
            label1.Text = "";
            if (!Form4.Instance.PanelHome.Controls.ContainsKey("DoanhThu"))
            {
                DoanhThu un = new DoanhThu();
                un.Dock = DockStyle.Fill;
                Form4.Instance.PanelHome.Controls.Add(un);

            }
            Form4.Instance.PanelHome.Controls["DoanhThu"].BringToFront();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            label4.Text = "                                                                                                                                                            ";
            label3.Text = "";
            label2.Text = "";
            label5.Text = "";
            label1.Text = "";
            if (!Form4.Instance.PanelHome.Controls.ContainsKey("DoanhThuSP"))
            {
                DoanhThuSP un = new DoanhThuSP();
                un.Dock = DockStyle.Fill;
                Form4.Instance.PanelHome.Controls.Add(un);

            }
            Form4.Instance.PanelHome.Controls["DoanhThuSP"].BringToFront();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            label5.Text = "                                                                                                                                                            ";
            label3.Text = "";
            label4.Text = "";
            label2.Text = "";
            label1.Text = "";
            if (!Form4.Instance.PanelHome.Controls.ContainsKey("BaoCao"))
            {
                BaoCao un = new BaoCao();
                un.Dock = DockStyle.Fill;
                Form4.Instance.PanelHome.Controls.Add(un);

            }
            Form4.Instance.PanelHome.Controls["BaoCao"].BringToFront();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            
            _obj = this;

            Home uc = new Home();
            uc.Dock = DockStyle.Fill;
            panel3.Controls.Add(uc);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            label5.Text = "";
            label3.Text = "";
            label4.Text = "";
            label2.Text = "";
            label1.Text = "";
            panel3.Controls["Home"].BringToFront();
           

        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn Đăng Xuất không? ", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                fWelcome f = new fWelcome();
                this.Hide();
                f.ShowDialog();
                this.Close();              
            }    
        }

        private void button9_Click(object sender, EventArgs e)
        {
            RutTien f = new RutTien();            
            f.ShowDialog();
            this.Close();
        }
    }
}
