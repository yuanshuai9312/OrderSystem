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
    public partial class 修改页面 : Form
    {
        public 修改页面()
        {
            InitializeComponent();
        }
        public DataGridView dgv;

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
      private void 修改页面_Load(object sender, EventArgs e)
        {
            try
            {
                textBox1.Text = dgv.CurrentRow.Cells["FoodID"].Value.ToString();
                textBox2.Text = dgv.CurrentRow.Cells["StyleName"].Value.ToString();
                textBox3.Text = dgv.CurrentRow.Cells["FoodName"].Value.ToString();
                textBox4.Text = dgv.CurrentRow.Cells["Price"].Value.ToString();
                textBox5.Text = dgv.CurrentRow.Cells["ImagePath"].Value.ToString();
                textBox6.Text = dgv.CurrentRow.Cells["ClickCount"].Value.ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("选择信息为空");
                this.Close();
            }
      }
      private void button1_Click(object sender, EventArgs e)

      {
          try
          {
              
              SqlConnection conn = new SqlConnection();
              conn.ConnectionString = "Data Source=(local);Initial Catalog=Restaurant;Integrated Security=true";
              conn.Open();
              if (textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "")
              {
                  MessageBox.Show("请输入完整信息");
                  return;
              }
              else
              {
                  string sql = string.Format("update FoodItem set StyleName='{0}',FoodName='{1}',Price='{2}'where FoodID={3}", textBox2.Text, textBox3.Text, textBox4.Text,textBox1.Text);
                  SqlCommand comm = new SqlCommand(sql,conn);
                  comm.ExecuteNonQuery();
                  MessageBox.Show("修改成功");
                  conn.Close();
                  this.Close();
              }
          }
          catch (Exception)
          {
              MessageBox.Show("价格处请输入数字");
              return;
          }
      }

       

        }
    }

