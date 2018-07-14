//学生
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
    public partial class 学生 : Form
    {
        private int S_id;
        private MySqlConnection conn;   // mysql连接
        private MySqlDataAdapter myadp; // mysql数据适配器
        private DataSet myds;   // 数据集
        private BindingSource BindingSource = new BindingSource();

        public 学生(int s_id)
        {
            S_id = s_id;
            Console.WriteLine("" + S_id);
            InitializeComponent();
        }

        private void 学生_Load(object sender, EventArgs e)
        {
            string str = "Server=localhost;User ID=root;Password=8888;Database=pt_job_ms;CharSet='utf8';";
            conn = new MySqlConnection(str);//实例化链接
            conn.Open();
            string sql = "select Work_time as 工作时间,Work_adress as 工作地址,Work_number as 工作人数,Work_salary as 时薪" +
                    ",Work_content as 工作内容,Full_salary as 全勤奖,Atend_max as 全勤奖需求,Work_duration as 工作时长 from work where Flag = 1 and Work_number > 0";
            myadp = new MySqlDataAdapter(sql, conn);
            myds = new DataSet();
            myadp.Fill(myds, "table1");//填充数据
            BindingSource.DataSource = myds.Tables["table1"];
            dataGridView1.DataSource = BindingSource;//数据绑定

            DataSet myds1 = new DataSet();
            MySqlDataAdapter myda1 = new MySqlDataAdapter(
                "select distinct Work_duration from work", conn
                );
            myda1.Fill(myds1, "table1");
            comboBox1.DataSource = myds1.Tables["table1"];
            comboBox1.DisplayMember = "Work_duration";//为combox的选择赋值

            DataSet myds2 = new DataSet();
            MySqlDataAdapter myda2 = new MySqlDataAdapter(
                "select distinct Work_salary from work", conn
                );
            myda2.Fill(myds2, "table1");
            comboBox2.DataSource = myds2.Tables["table1"];
            comboBox2.DisplayMember = "Work_salary";//为combox的选择赋值

            //检测是否被聘用;
            MySqlDataReader reader;
            sql = "select * from work_p where Stu_id = " + S_id + " and Confirm = 0";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                Console.WriteLine("被聘用");
                DialogResult dr = MessageBox.Show("你已被" + reader[6].ToString() + "成功聘用!,点击确认前往工作", "", MessageBoxButtons.YesNo);
                reader.Close();
                if(dr == DialogResult.Yes)
                {
                    sql = "update work_p set Confirm = 1 where Stu_id = " + S_id + "";//点击确认就修改Confirm值
                    Console.WriteLine(sql);
                    cmd = new MySqlCommand(sql, conn);
                    cmd.ExecuteNonQuery();
                }
            }
            reader.Close();


        }

        private void button1_Click(object sender, EventArgs e)//申请工作
        {
            int a = dataGridView1.CurrentRow.Index;
            string work_time = dataGridView1.Rows[a].Cells[0].Value.ToString();//获取工作时间
            string work_content = dataGridView1.Rows[a].Cells[4].Value.ToString();//获取工作内容
            string work_adress = dataGridView1.Rows[a].Cells[1].Value.ToString();//获取工作地址


            try
            {
                string sql = "insert into work_candi (Stu_id,S_name,Sex,P_number,Time,Work_time,Work_adress,Work_content,Bank_name,Work_salary,Full_salary,C_id,Atend_max,Work_duration) select " +
                    "Stu_id,S_name,Sex,P_number,Time,Work_time,Work_adress,Work_content,Bank_name,Work_salary,Full_salary,C_id,Atend_max,Work_duration from student,work" +
                    " where Work_time = '" + work_time + "' and Work_adress = '" + work_adress + "' and Work_content = '" + work_content + "'and Stu_id = " + S_id + "";
                Console.WriteLine(sql);
                MySqlCommand cmd = new MySqlCommand(sql, conn);//进行对工作候选表的插入工作
                cmd.ExecuteNonQuery();

                string sql1 = "update work set Work_number = Work_number - 1 where Work_time = '" + work_time + "' and Work_adress = '" + work_adress + "' and Work_content = '" + work_content + "'";
                MySqlCommand cmd1 = new MySqlCommand(sql1, conn);//执行工作的工作人数要求减一操作
                cmd1.ExecuteNonQuery();

                MessageBox.Show("申请成功");
            }
            catch
            {
                MessageBox.Show("您已经申请过工作");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string tip = textBox1.Text.ToString();//获取查询内容
            //利用百分号进行关键字查询
            string sql = "select Work_time as 工作时间,Work_adress as 工作地址,Work_number as 工作人数,Work_salary as 时薪" +
                   ",Work_content as 工作内容,Full_salary as 全勤奖,Atend_max as 全勤奖需求,Work_duration as 工作时长 from work where Flag = 1 and Work_content Like '%"+tip+"%'";
            Console.WriteLine(sql);
            myadp = new MySqlDataAdapter(sql, conn);
            myds = new DataSet();
            myadp.Fill(myds, "table1");
            BindingSource.DataSource = myds.Tables["table1"];
            dataGridView1.DataSource = BindingSource;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Console.WriteLine(comboBox1.Text);
            
            int Work_duration = int.Parse(comboBox1.Text);//获取筛选条件
            string Work_salary = comboBox2.Text;
            string sql = "select Work_time as 工作时间,Work_adress as 工作地址,Work_number as 工作人数,Work_salary as 时薪" +
                   ",Work_content as 工作内容,Full_salary as 全勤奖,Atend_max as 全勤奖需求,Work_duration as 工作时长 from work where Flag = 1 and Work_duration = "+Work_duration+" " +
                   "and Work_salary = '"+Work_salary+"'";//按照筛选条件进行查询
            Console.WriteLine(sql);
            myadp = new MySqlDataAdapter(sql, conn);
            myds = new DataSet();
            myadp.Fill(myds, "table1");
            BindingSource.DataSource = myds.Tables["table1"];
            dataGridView1.DataSource = BindingSource;
        }

        private void label4_Click(object sender, EventArgs e)
        {
            修改个人信息 a = new 修改个人信息(S_id);
            a.Show();
        }
    }
    
}
