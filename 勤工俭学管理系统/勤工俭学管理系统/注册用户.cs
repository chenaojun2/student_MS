//注册用户
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace 勤工俭学管理系统
{
    public partial class 注册用户 : Form
    {
        public 注册用户()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            注册管理 regis_m = new 注册管理();//进入管理注册界面
            regis_m.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            注册学生 regis_s = new 注册学生();//进入学生注册页面
            regis_s.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            注册公司 regis_c = new 注册公司();//进入公司注册页面
            regis_c.Show();
        }

        private void 注册用户_Load(object sender, EventArgs e)
        {

        }
    }
}

