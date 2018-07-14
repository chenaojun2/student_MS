//工资
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
    public partial class 工资 : Form
    {
        private int C_id;
        private MySqlConnection conn;   // mysql连接
        private MySqlDataAdapter myadp; // mysql数据适配器
        private DataSet myds;   // 数据集
        private BindingSource BindingSource = new BindingSource();

        public 工资(int c_id)
        {
            C_id = c_id;
            InitializeComponent();
        }

        private void 工资_Load(object sender, EventArgs e)
        {
            string str = "Server=localhost;User ID=root;Password=8888;Database=pt_job_ms;CharSet='utf8';";
            conn = new MySqlConnection(str);//实例化链接
            conn.Open();
            string sql = "select Stu_id as 学生id,S_name as 学生姓名,Sex as 性别,P_number as 电话号码,Bank_name as 银行卡号, Work_salary*Atten_number*Work_duration+Full_salary*flag as 工资 from work_p where C_id = " + C_id+" and Confirm = 1";//用select语句获取工资信息
            Console.WriteLine(sql);
            myadp = new MySqlDataAdapter(sql, conn);
            myds = new DataSet();
            myadp.Fill(myds, "table1");//数据填充
            BindingSource.DataSource = myds.Tables["table1"];
            dataGridView1.DataSource = BindingSource;//数绑定
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int a = dataGridView1.CurrentRow.Index;
            int stu_id = int.Parse(dataGridView1.Rows[a].Cells[0].Value.ToString());
            string sql = "update work_p set Atten_number = 0 where Stu_id = " + stu_id + "";//点击工资发放后，考勤次数置零
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.ExecuteNonQuery();
            sql = "update work_p set flag = 0 where Stu_id = " + stu_id + "";//是否满足考勤奖的标志置零
            cmd = new MySqlCommand(sql, conn);
            cmd.ExecuteNonQuery();
        }
    }
}
