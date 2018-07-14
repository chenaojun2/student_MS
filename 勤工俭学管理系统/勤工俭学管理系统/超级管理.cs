//超级管理
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace 勤工俭学管理系统
{
    public partial class 超级管理 : Form
    {
        private MySqlConnection conn;   // mysql连接
        private MySqlDataAdapter myadp; // mysql数据适配器
        private DataSet myds;   // 数据集
        private BindingSource BindingSource = new BindingSource();

        public 超级管理()
        {
            InitializeComponent();
        }

        private void 超级管理_Load(object sender, EventArgs e)
        {
            string str = "Server=localhost;User ID=root;Password=8888;Database=pt_job_ms;CharSet='utf8';";
            conn = new MySqlConnection(str);//实例化链接
            conn.Open();
            string sql = "select Work_id as 工号,M_name as 名字,Power as 权限 from manager where Power != '5'";
            myadp = new MySqlDataAdapter(sql, conn);
            myds = new DataSet();
            myadp.Fill(myds, "table1");
            BindingSource.DataSource = myds.Tables["table1"];
            dataGridView1.DataSource = BindingSource;//获取数据和数据绑定
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (myds.HasChanges())//判断数据是否发生了改变
            {
                MySqlCommandBuilder mySqlCommandBuilder = new MySqlCommandBuilder(myadp);
                myadp.Update(myds, "table1");//更新数据
                dataGridView1.Refresh();
                
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string user_name = textBox1.Text;
            MySqlDataReader reader;
            int k = 0;//表示是否查到此人的标志值
            string sql1 = "select * from company where C_user_name = '" + user_name + "'";//企业用户表查询语句
            string sql2 = "select * from Manager where M_user_name = '" + user_name + "'";//管理用户表查询语句
            string sql3 =  "select * from student where S_user_name = '" + user_name + "'";//学生用户表查询语句

            MySqlCommand cmd = new MySqlCommand(sql1, conn);//查看用户是否在企业表中
            reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                int c_id = int.Parse(reader[0].ToString());
                reader.Close();
                Console.WriteLine("" + c_id);
                string sql11 = "delete from company where C_id = " + c_id + "";//删除该用户
                MySqlCommand cmd1 = new MySqlCommand(sql11, conn);
                cmd1.ExecuteNonQuery();
                k = 1;
            }
            reader.Close();


            MySqlCommand cmd2 = new MySqlCommand(sql2, conn);//查看用户是否在管理表中
            reader = cmd2.ExecuteReader();
            if (reader.Read())
            {
                int work_id = int.Parse(reader[0].ToString());
                reader.Close();
                Console.WriteLine(""+work_id);
                string sql11 = "delete from Manager where Work_id = " + work_id + "";//删除该用户
                MySqlCommand cmd1 = new MySqlCommand(sql11, conn);
                cmd1.ExecuteNonQuery();
                k = 1;
            }
            reader.Close();


            MySqlCommand cmd3 = new MySqlCommand(sql3, conn);//查看用户是否在学生表中
            reader = cmd3.ExecuteReader();
            if (reader.Read())
            {
                int s_id = int.Parse(reader[0].ToString());
                reader.Close();
                Console.WriteLine("" + s_id);
                string sql11 = "delete from student where Stu_id = " + s_id + "";//删除该用户
                MySqlCommand cmd1 = new MySqlCommand(sql11, conn);
                cmd1.ExecuteNonQuery();
                k = 1;
            }
            reader.Close();


            if (k == 0)
                MessageBox.Show("查无此人");
            else
                MessageBox.Show("销户成功");
            
        }
    }
}
