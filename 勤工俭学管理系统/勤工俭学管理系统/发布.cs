using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

//发布页面
namespace 勤工俭学管理系统
{
    public partial class 发布 : Form
    {
        private int C_id;
        private MySqlConnection conn;
        public 发布(int c_id)
        {
            C_id = c_id;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string Work_time;
            string Work_adress;
            int Work_number;
            string Work_salary;
            string Work_content;
            string Full_salary;
            int Work_duration;
            int Atend_max;

            string str = "Server=localhost;User ID=root;Password=8888;Database=pt_job_ms;CharSet='utf8';";
            conn = new MySqlConnection(str);//实例化链接
            conn.Open();
            try
            {
                Work_adress = text_work_adress.Text;//获取工作地址
                Work_time = text_work_time.Text;//获取工作时间
                Work_number = int.Parse(text_work_number.Text);//获取工作人数
                Work_salary = text_work_salary.Text;//获取工作时薪
                Work_content = text_work_content.Text;//获取工作内容
                Full_salary = text_full_salary.Text;//获取全勤奖
                Work_duration = int.Parse(text_work_duration.Text);//获取工作时长
                Atend_max = int.Parse(text_atennd_max.Text);//获取全勤需求次数
                string sql = "insert into work(Work_time,Work_adress,Work_number,Work_salary" +
                    ",Work_content,Full_salary,C_id,Atend_max,Work_duration) values ('" + Work_time + "','" + Work_adress + "'," + Work_number + "," +
                    "'" + Work_salary + "','" + Work_content + "','" + Full_salary + "','" + C_id + "'," + Atend_max + "," + Work_duration + ")";//插入语句
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("申请成功");
            }
            catch
            {
                MessageBox.Show("申请失败");
            }
        }

        

        private void 发布_Load(object sender, EventArgs e)
        {

        }
    }
}
