//注册学生
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
    public partial class 注册学生 : Form
    {
        public 注册学生()
        {
            InitializeComponent();
        }

        private void 注册学生_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
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
            string sql = "select * from company,student,Manager where C_user_name = '" + user_name + "' OR  S_user_name = '" + user_name + "' OR M_user_name = '" + user_name + "'";
            MySqlCommand cmd = new MySqlCommand(sql, con);
            reader = cmd.ExecuteReader();
            if (user_name == "" || sure_pass == "" || s_name == "" || p_name == "" || sex == "" || major == "" || clas == "" || bank_name == "" || time == "")
            {
                MessageBox.Show("请填写完整");//判断资料是否完整
            }
            else if (reader.Read())
            {
                MessageBox.Show("此账号已存在");//判断账号是否存在
            }
            else if (user_pass == sure_pass)//判断两次密码是否一致
            {
                string sql1 = "'" + user_name + "','" + user_pass + "','"+s_name+"','" + sex + "','" + major + "','" + clas + "','" + p_name + "','"+time+"','"+bank_name+"'";
                Regis regis = new Regis(2, sql1);
                regis.Regising();
            }
            else
            {
                MessageBox.Show("密码有误");
            }
        }
    }
}
