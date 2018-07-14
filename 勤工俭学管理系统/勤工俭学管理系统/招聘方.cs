//招聘方
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
    public partial class 招聘方 : Form
    {
        private int C_id;
        private MySqlConnection conn;   // mysql连接
        private MySqlDataAdapter myadp; // mysql数据适配器
        private DataSet myds;   // 数据集
        private BindingSource BindingSource = new BindingSource();

        public 招聘方(int c_id)
        {
            C_id = c_id;
            InitializeComponent();
        }

        private void 招聘方_Load(object sender, EventArgs e)
        {
            string str = "Server=localhost;User ID=root;Password=8888;Database=pt_job_ms;CharSet='utf8';";
            conn = new MySqlConnection(str);//实例化链接
            conn.Open();
            string sql = "select Stu_id as 学号,S_name as 姓名,Sex as 性别,Work_adress as 工作地址,Work_content as 工作内容 from work_p where C_id = '"+ C_id + "' and Confirm = 1";
            myadp = new MySqlDataAdapter(sql, conn);//查询已经成功入职的学生信息
            myds = new DataSet();
            myadp.Fill(myds, "table1");//数据填充
            BindingSource.DataSource = myds.Tables["table1"];
            dataGridView1.DataSource = BindingSource;//数据绑定
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string str = "Server=localhost;User ID=root;Password=8888;Database=pt_job_ms;CharSet='utf8';";
            conn = new MySqlConnection(str);//实例化链接
            conn.Open();
            int a =   dataGridView1.CurrentRow.Index;
            int stu_id = int.Parse(dataGridView1.Rows[a].Cells[0].Value.ToString());
            string sql = "update work_p set Atten_number = Atten_number + 1 where Stu_id = " + stu_id + "";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.ExecuteNonQuery();

            MySqlDataReader reader;
            sql = "select * from work_p where Stu_id = " + stu_id + "";
            cmd = new MySqlCommand(sql, conn);//查询该学生的学生信息
            reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                int at_number = int.Parse(reader[10].ToString());
                int at_max = int.Parse(reader[14].ToString());
                if(at_max <= at_number)//判断是否满足全勤奖条件
                {
                    reader.Close();
                    sql = "update work_p set flag = 1 where Stu_id = " + stu_id + "";//如果满足，则将记录是否满足置数为1
                    cmd = new MySqlCommand(sql, conn);
                    cmd.ExecuteNonQuery();
                }
                else
                {
                    reader.Close();
                    sql = "update work_p set flag = 0 where Stu_id = " + stu_id + "";
                    cmd = new MySqlCommand(sql, conn);
                    cmd.ExecuteNonQuery();
                }
            }

            dataGridView1.Rows.RemoveAt(a);

            MessageBox.Show("签到成功！");
           
        }

        private void 发布信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            发布 put = new 发布(C_id);
            conn.Close();//进入发布窗口
            put.Show();
        }

        private void 修改信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            修改 xiu = new 修改(C_id);
            conn.Close();//进入修改窗口
            xiu.Show();
        }

        private void 工作聘用ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            聘用 pin = new 聘用(C_id);//进入聘用窗口
            conn.Close();
            pin.Show();
        }

        private void 工资发放ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            工资 gon = new 工资(C_id);
            conn.Close();//进入工资窗口
            gon.Show();
        }
    }
}
