using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

namespace WindowsFormsApplication1
{
    public partial class Main_From : Form
    {
        public Main_From()
        {
            InitializeComponent();
        }
        void InitGridView()
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();

            //建表
            dataGridView1.Columns.Add("Pos", "序号");
            dataGridView1.Columns.Add("ClickCount", "销量");
            dataGridView1.Columns.Add("StyleName", "菜系名称");
            dataGridView1.Columns.Add("FoodID", "菜品ID");
            dataGridView1.Columns.Add("FoodName", "菜品名称");
            dataGridView1.Columns.Add("Price", "价格");
            dataGridView1.Columns.Add("ImagePath", "图片位置");
            dataGridView1.Columns.Add("IsHot", "是否热门");
            //设置列宽
            dataGridView1.Columns[0].Width = 60;
            dataGridView1.Columns[1].Width = 60;
            dataGridView1.Columns[2].Width = 60;
            dataGridView1.Columns[3].Width = 80;
            dataGridView1.Columns[4].Width = 100;
            dataGridView1.Columns[5].Width = 80;
            dataGridView1.Columns[6].Width = 160;
            dataGridView1.Columns[7].Width = 50;
            //属性设置
            dataGridView1.ReadOnly = true;
            dataGridView1.AllowUserToAddRows = true;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.MultiSelect = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }
        void FillGrid(FoodItem Food)
        {
            int count = dataGridView1.Rows.Count;
            dataGridView1.Rows.Add();

            dataGridView1.Rows[count - 1].Cells["pos"].Value = count ;
            dataGridView1.Rows[count - 1].Cells["FoodID"].Value = Food.FoodID;
            dataGridView1.Rows[count - 1].Cells["FoodName"].Value = Food.FoodName;
            dataGridView1.Rows[count - 1].Cells["ClickCount"].Value = Food.ClickCount;
            dataGridView1.Rows[count - 1].Cells["StyleName"].Value = Food.StyleName;
            dataGridView1.Rows[count - 1].Cells["Price"].Value = Food.Price;
            dataGridView1.Rows[count - 1].Cells["ImagePath"].Value = Food.ImagePath;
            dataGridView1.Rows[count - 1].Cells["IsHot"].Value = Food.IsHot;
        }
        void GetFood()
        {
            string connString = "Server=(local);DataBase=Restaurant;Integrated Security=true";
            SqlConnection conn = new SqlConnection(connString);
            conn.Open();

            string sql = "select * from FoodItem";
            SqlCommand comm = new SqlCommand(sql, conn);
            SqlDataReader dr = comm.ExecuteReader();
            FoodItem Food = new FoodItem();
            while (dr.Read())
            {
                //读取并保存数据
                Food.FoodID = int.Parse(dr["FoodID"].ToString());
                Food.FoodName = dr["FoodName"].ToString();
                Food.ClickCount = int.Parse(dr["ClickCount"].ToString());
                Food.StyleName = dr["StyleName"].ToString();
                Food.Price = float.Parse(dr["Price"].ToString());
                Food.ImagePath = dr["imagePath"].ToString();
                Food.IsHot = dr["IsHot"].ToString();
                FillGrid(Food);
            }
            dr.Close(); conn.Close();
        }
        private void Main_From_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;


        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label2.Text = "当前时间为：" + DateTime.Now.ToString();
        }

        private void 关于ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            个人信息 frm = new 个人信息();
            frm.Show();
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void 显示菜单ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InitGridView();
            GetFood();
            if (dataGridView1.Visible == false)
            {
                dataGridView1.Visible = true;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentRow == null) return;

            string selectInfo = "";
            selectInfo += dataGridView1.CurrentRow.Cells["pos"].Value + "";
            selectInfo += dataGridView1.CurrentRow.Cells["FoodID"].Value + "";
            selectInfo += dataGridView1.CurrentRow.Cells["FoodName"].Value + "";
            selectInfo += dataGridView1.CurrentRow.Cells["ClickCount"].Value + "";
            selectInfo += dataGridView1.CurrentRow.Cells["StyleName"].Value + "";
            selectInfo += dataGridView1.CurrentRow.Cells["Price"].Value + "";
            selectInfo += dataGridView1.CurrentRow.Cells["ImagePath"].Value;
            selectInfo += dataGridView1.CurrentRow.Cells["IsHot"].Value + "";
            this.Text = selectInfo;
            string selectInfo1 = "";
            selectInfo1 += dataGridView1.CurrentRow.Cells["FoodName"].Value + ",";
            selectInfo1 += dataGridView1.CurrentRow.Cells["Price"].Value + ",";
            listBox1.Items.Add(selectInfo1);
            string selectInfo2 = "";
            selectInfo2 += dataGridView1.CurrentRow.Cells["FoodName"].Value + ",";
            label4.Text = selectInfo2;



            try
            {
                SqlConnection conn = new SqlConnection();
                SqlConnectionStringBuilder scsb = new SqlConnectionStringBuilder();
                scsb.DataSource = "(local)";
                scsb.InitialCatalog = "Restaurant";
                scsb.IntegratedSecurity = true;
                conn.ConnectionString = scsb.ConnectionString;
                conn.Open();
                string s = dataGridView1.CurrentRow.Cells["imagepath"].Value.ToString();
                string name = dataGridView1.CurrentRow.Cells["foodname"].Value.ToString();
                pictureBox1.Image = Image.FromFile("pic\\" + s);
                conn.Close();
            }
            catch (Exception)
            {
                Exception ex = new Exception();
                label6.Text = "抱歉，没有这一张照片";

            }
            


        }

        private void 关闭显示ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView1.Visible = false;
            
        }

       

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        //打开UpdateItem窗口
        private void button1_Click(object sender, EventArgs e)
        {
            UpdateItem frm = new UpdateItem();
            frm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            修改页面 frm1 = new 修改页面();
            if (dataGridView1.Visible == false)
            {
                MessageBox.Show("当前数据为空，无法修改");
                frm1.Hide();
            }
            else
            {
                frm1.dgv = dataGridView1;
                frm1.Show();
            }


        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.CurrentRow == null) return;
                int FoodID = int.Parse(dataGridView1.CurrentRow.Cells["FoodID"].Value.ToString());
                SqlConnection conn = new SqlConnection(DB.ConnString);
                conn.Open();

                string sql = "Delete From FoodItem Where FoodID=" + FoodID;
                SqlCommand comm = new SqlCommand(sql, conn);
                comm.ExecuteNonQuery();
                conn.Close();
                dataGridView1.Rows.Remove(dataGridView1.CurrentRow);
            }
            catch (Exception)
            {
                MessageBox.Show("请选择有效行");
            }



        }

        private void button4_Click(object sender, EventArgs e)
        {
           
            if (textBox1.Text == "")
            {
                InitGridView();
                GetFood();
            }
            else
            {
                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = "Data Source=(local);Initial Catalog=Restaurant;Integrated Security=true";
                conn.Open();
                string s = "";
                s = textBox1.Text.ToString();
                string sql = string.Format("select * from FoodItem where foodName Like '{0}%'", s);
                string sql2 = string.Format("Insert * from FoodItem where foodName Like '{0}%'", s);
                SqlCommand comm = new SqlCommand(sql,conn);
                SqlCommand comm2 = new SqlCommand(sql2, conn);
                comm.ExecuteNonQuery();
                SqlDataReader dr = comm.ExecuteReader();
                FoodItem Food = new FoodItem();
                InitGridView();
                int count = dataGridView1.Rows.Count;
                dataGridView1.Rows.Add();

                dataGridView1.Rows[count-1].Cells["pos"].Value = count;
                dataGridView1.Rows[count-1].Cells["FoodID"].Value = Food.FoodID;
                dataGridView1.Rows[count-1].Cells["FoodName"].Value = Food.FoodName;
                dataGridView1.Rows[count-1].Cells["ClickCount"].Value = Food.ClickCount;
                dataGridView1.Rows[count-1].Cells["StyleName"].Value = Food.StyleName;
                dataGridView1.Rows[count-1].Cells["Price"].Value = Food.Price;
                dataGridView1.Rows[count-1].Cells["ImagePath"].Value = Food.ImagePath;
                dataGridView1.Rows[count-1].Cells["IsHot"].Value = Food.IsHot;
                while (dr.Read())
                {
                    //读取并保存数据
                    Food.FoodID = int.Parse(dr["FoodID"].ToString());
                    Food.FoodName = dr["FoodName"].ToString();
                    Food.ClickCount = int.Parse(dr["ClickCount"].ToString());
                    Food.StyleName = dr["StyleName"].ToString();
                    Food.Price = float.Parse(dr["Price"].ToString());
                    Food.ImagePath = dr["imagePath"].ToString();
                    Food.IsHot = dr["IsHot"].ToString();
                    FillGrid(Food);
                }
                conn.Close(); dr.Close(); 
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
           
        }

        private void button6_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();//清空购物车
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            修改页面 frm1 = new 修改页面();
            if (dataGridView1.Visible == false)
            {
                MessageBox.Show("当前数据为空，无法修改");
                frm1.Hide();
            }
            else
            {
                frm1.dgv = dataGridView1;
                frm1.Show();
            }
        }
    }
}


