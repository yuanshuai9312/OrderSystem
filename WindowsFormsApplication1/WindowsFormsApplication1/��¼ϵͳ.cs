using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsApplication1
{
    public partial class 登录系统 : Form
    {
        public 登录系统()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            注册系统 frm2 = new 注册系统();
            frm2.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text == "" || textBox2.Text == "")
                {
                    MessageBox.Show(" 请输入用户名和密码");
                    return;
                }
                else if (radioButton1.Checked == false && radioButton2.Checked == false)
                {
                    MessageBox.Show("请选择管理员和用户");
                    return;
                }
                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = "Data Source=(local);Initial Catalog=Restaurant;Integrated Security=true";
                conn.Open();
                int dj = radioButton1.Checked ? 1 : 0;
                string sql = "select count(*)from Users where username='" + textBox1.Text + "'and pwd='" + textBox2.Text + "'and userclass=" + dj;
                SqlCommand comm = new SqlCommand(sql, conn);
                int rows = (int)comm.ExecuteScalar();

                if (rows == 1)
                {
                    MessageBox.Show("成功登录");
                    Main_From frm3 = new Main_From();
                    frm3.Show();
                    this.Hide();
                }

                else
                {
                    MessageBox.Show("用户不存在或者密码错误" + "\r\n" + "请重新输入");

                }
            }
            catch (Exception)
            {
                MessageBox.Show("数据库未连接");
            }
        }

        private void 登录系统_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label3.Text = "当前时间为:" + DateTime.Now.ToString();
        }
    }
}


