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
    public partial class 注册系统 : Form
    {
        public 注册系统()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string username = textBox1.Text;
                string pwd = textBox2.Text;
                string userclass = "";
                if (radioButton1.Checked) userclass = "1";
                if (radioButton2.Checked) userclass = "0";
                if (textBox1.Text == "" || textBox2.Text == "")
                {
                    MessageBox.Show("请输入用户名和密码");
                    return;
                }

                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = "Data Source=(local);Initial Catalog=Restaurant;Integrated Security=true";
                conn.Open();
                string sql = string.Format("Insert into Users(username,pwd,userclass)values('{0}','{1}','{2}')", username, pwd, userclass);
                SqlCommand comm = new SqlCommand(sql, conn);
                comm.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("成功注册");
                this.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("用户已存在");
            }
        }
        

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
