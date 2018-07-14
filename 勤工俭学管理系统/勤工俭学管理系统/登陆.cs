//登陆
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
    public partial class 登陆 : Form
    {
        public 登陆()
        {
            InitializeComponent();
        }

        private void 登陆_Load(object sender, EventArgs e)
        {
            this.comboBox1.SelectedIndex = 0;//设置下拉框默认选择
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string user_name = textBox1.Text;
            string user_pass = textBox2.Text;
            string user_type = comboBox1.SelectedItem.ToString();
            Login login = new Login(user_name,user_pass,user_type);//定义一个登陆Login类并且传递参数，返回标识值
            int flag = login.Logining();
            if (flag == 15)//根据标识值选择窗口 15 为超级管理
            {
                Console.WriteLine("成功登陆");
                超级管理 superfrom = new 超级管理();
                superfrom.Show(); 
            }
            else if (flag == 11) // 11为删除管理用户
            {
                删除管理窗口 defrom = new 删除管理窗口();
                defrom.Show();
            }
            else if(flag == 12) // 12为修改管理用户
            {
                修改管理窗口 refrom = new 修改管理窗口();
                refrom.Show();
            }
            else if(flag == 13) // 13为发布管理用户
            {
                发布管理窗口 pufrom = new 发布管理窗口();
                pufrom.Show();
            }
            else if (flag/10000 == 2)//flag/10000后如果值为2则是学生用户
            {
                学生 sfrom = new 学生(flag-20000);//flag - 20000表示学生用户id
                sfrom.Show();
            }
            else if(flag/10000 == 3)//flag/10000后如果值为3则是招聘方用户
            {
                Console.WriteLine(""+flag);
                招聘方 sfrom = new 招聘方(flag - 30000);//flag - 30000表示招聘方id
                sfrom.Show();
            }
            else
            {
                MessageBox.Show("登陆失败");
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            注册用户 regis = new 注册用户();
            regis.Show();
        }
    }
}
