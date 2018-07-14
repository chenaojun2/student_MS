//聘用
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
    public partial class 聘用 : Form
    {
        private int C_id;
        private MySqlConnection conn;   // mysql连接
        private MySqlDataAdapter myadp; // mysql数据适配器
        private DataSet myds;   // 数据集
        private BindingSource BindingSource = new BindingSource();

        public 聘用(int c_id)
        {
            C_id = c_id;
            InitializeComponent();
        }

        private void 聘用_Load(object sender, EventArgs e)
        {
            string str = "Server=localhost;User ID=root;Password=8888;Database=pt_job_ms;CharSet='utf8';";
            conn = new MySqlConnection(str);//实例化链接
            conn.Open();
            string sql = "select Stu_id as 学生id,S_name as 学生姓名,Sex as 性别,P_number as 电话号码,Time as 空闲时间,Work_time as 工作时间,Work_content as 工作内容, Work_adress as 工作地点 from work_candi  where C_id = "+C_id+"";
            //获取候选表信息
            Console.WriteLine(sql);
            myadp = new MySqlDataAdapter(sql, conn);
            myds = new DataSet();
            myadp.Fill(myds, "table1");//填充数据
            BindingSource.DataSource = myds.Tables["table1"];
            dataGridView1.DataSource = BindingSource;//绑定数据
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int a = dataGridView1.CurrentRow.Index;
            int stu_id = int.Parse(dataGridView1.Rows[a].Cells[0].Value.ToString());
            try
            {
                string sql = "insert into work_p (Stu_id,S_name,Sex,P_number,Bank_name,Work_time,Work_adress,Work_content,Work_salary,Full_salary,C_id,Work_duration,Atend_max) " +
                    "select Stu_id,S_name,Sex,P_number,Bank_name,Work_time,Work_adress,Work_content,Work_salary,Full_salary,C_id,Work_duration,Atend_max from work_candi where Stu_id = " + stu_id + "";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();//确认聘用后将数据插入工作人员表
            }
            catch
            {
                MessageBox.Show("聘用失败，可能已经参与了其他兼职");
                string work_time = dataGridView1.Rows[a].Cells[5].Value.ToString();//获取工作时间
                string work_content = dataGridView1.Rows[a].Cells[6].Value.ToString();//获取工作内容
                string work_adress = dataGridView1.Rows[a].Cells[7].Value.ToString();//获取工作地址

                string sql1 = "update work set Work_number = Work_number + 1 where Work_time = '" + work_time + "' and Work_adress = '" + work_adress + "' and Work_content = '" + work_content + "'";
                Console.WriteLine(sql1);
                //聘用失败后，将招聘信息的人数加1
                MySqlCommand cmd1 = new MySqlCommand(sql1, conn);
                cmd1.ExecuteNonQuery();
            }
            string desql = "delete from work_candi where Stu_id = "+stu_id+"";
            MySqlCommand decmd = new MySqlCommand(desql, conn);
            decmd.ExecuteNonQuery();

            dataGridView1.Rows.RemoveAt(a);
        }
    }
}
