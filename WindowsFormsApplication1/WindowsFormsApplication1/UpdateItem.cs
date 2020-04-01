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
    public partial class UpdateItem : Form
    {
        public UpdateItem()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string StyleName = textBox1.Text;
                string FoodName = textBox2.Text;
                string Price = textBox3.Text;

                if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "")
                {
                    MessageBox.Show("请输入完整的菜品信息");
                    return;
                }
                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = "Data Source=(local);Initial Catalog=Restaurant;Integrated Security=true";
                conn.Open();
                string sql = string.Format("Insert into FoodItem(StyleName,FoodName,Price)values('{0}','{1}','{2}')", StyleName, FoodName, Price);
                SqlCommand comm = new SqlCommand(sql, conn);
                comm.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("成功录入");
            }
            catch (Exception)
            {
                MessageBox.Show("请输入数字类型");
            }
        }

        private void UpdateItem_Load(object sender, EventArgs e)
        {

        }
    }
}
