//修改个人信息
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
    public partial class 修改个人信息 : Form
    {
        private int s_id;
        public 修改个人信息(int stu_id)
        {
            s_id = stu_id;
            InitializeComponent();
        }

        private void 修改个人信息_Load_1(object sender, EventArgs e)
        {
            string user_name = textBox1.Text;
            string user_pass = textBox2.Text;
            string sure_pass = textBox3.Text;
            string s_name = textBox4.Text;
            string sex = textBox5.Text;
            string major = textBox6.Text;
            string clas = textBox10.Text;
            string p_name = textBox9.Text;
            string time = textBox7.Text;
            string bank_name = textBox8.Text;

            MySqlDataReader reader;
            string str = "Server=localhost;User ID=root;Password=8888;Database=pt_job_ms;CharSet='utf8';";
            MySqlConnection con = new MySqlConnection(str);//实例化链接
            try
            {
                con.Open();//开启连接
                Console.WriteLine("链接已建立");
            }
            catch
            {
                Console.WriteLine("链接失败");
            }

            string sql = "select * from student where Stu_id = " + s_id + "";
            MySqlCommand cmd = new MySqlCommand(sql, con);
            reader = cmd.ExecuteReader();
           
            if (reader.Read())
            {//获取当前的用户信息
                Console.WriteLine("" + reader[1].ToString());
                textBox1.Text = reader[1].ToString();
                textBox2.Text = reader[2].ToString();
                textBox3.Text = reader[2].ToString();
                textBox4.Text = reader[3].ToString();
                textBox5.Text = reader[4].ToString();
                textBox6.Text = reader[5].ToString();
                textBox10.Text = reader[6].ToString();
                textBox9.Text = reader[7].ToString();
                textBox7.Text = reader[8].ToString();
                textBox8.Text = reader[9].ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string user_name = textBox1.Text;//获取用户名
            string user_pass = textBox2.Text;//获取用户密码
            string sure_pass = textBox3.Text;//获取确认密码
            string s_name = textBox4.Text;//获取学生姓名
            string sex = textBox5.Text;//获取性别
            string major = textBox6.Text;//获取专业
            string clas = textBox10.Text;//获取班级
            string p_name = textBox9.Text;//获取电话
            string time = textBox7.Text;//获取空闲时间
            string bank_name = textBox8.Text;//获取银行卡号

            string str = "Server=localhost;User ID=root;Password=8888;Database=pt_job_ms;CharSet='utf8';";
            MySqlConnection con = new MySqlConnection(str);//实例化链接
            try
            {
                con.Open();//开启连接
                Console.WriteLine("链接已建立");
            }
            catch
            {
                Console.WriteLine("链接失败");
            }

            MySqlDataReader reader;
            string sql1 = "select * from company,student,Manager where C_user_name = '" + user_name + "' OR  S_user_name = '" + user_name + "' OR M_user_name = '" + user_name + "'";
            MySqlCommand cmd1 = new MySqlCommand(sql1, con);
            reader = cmd1.ExecuteReader();
            
            if(sure_pass != user_pass)
            {
                MessageBox.Show("密码错误");
            }
           else if (reader.Read())
            {
                MessageBox.Show("此账号已存在");//判断账号是否存在
            }
            else
            {
                string sql = "update student " +
                "set S_user_name = '" + user_name + "', S_user_pass = '" + user_pass + "', S_name = '" + s_name + "', Sex = '" + sex + "', Major = '" + major + "', Class = '" + clas + "', P_number = '" + p_name + "', Time = '" + time + "' , Bank_name = '" + bank_name + "'" +
                    "where Stu_id = " + s_id + "";
                MySqlCommand cmd = new MySqlCommand(sql, con);//执行更新操作
                cmd.ExecuteNonQuery();
            }
        }
    }
}
