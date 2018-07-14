//删除管理
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace 勤工俭学管理系统
{
    public partial class 删除管理窗口 : Form
    {
        private MySqlConnection conn;   // mysql连接
        private MySqlDataAdapter myadp; // mysql数据适配器
        private DataSet myds;   // 数据集
        private BindingSource BindingSource = new BindingSource();

        public 删除管理窗口()
        {
            InitializeComponent();
        }

        private void 删除管理窗口_Load(object sender, EventArgs e)
        {
            string str = "Server=localhost;User ID=root;Password=8888;Database=pt_job_ms;CharSet='utf8';";
            conn = new MySqlConnection(str);//实例化链接
            conn.Open();
            string sql = "select Work_time as 工作时间,Work_adress as 工作地址,Work_number as 工作人数,Work_salary as 时薪,Work_content as 工作内容" +
                ",Full_salary as 全勤奖,Atend_max 全勤奖需求,Work_duration as 工作时长 from work where Flag = 1";//获取通过审核的表
            myadp = new MySqlDataAdapter(sql, conn);
            myds = new DataSet();
            myadp.Fill(myds, "table1");//数据填充
            BindingSource.DataSource = myds.Tables["table1"];
            dataGridView1.DataSource = BindingSource;//数据绑定
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int a = dataGridView1.CurrentRow.Index;
            string sql = "delete from work where Work_time = '" + dataGridView1.Rows[a].Cells[0].Value.ToString() + "' and Work_adress = '" + dataGridView1.Rows[a].Cells[1].Value.ToString() + "'" +
                        " and Work_content = '" + dataGridView1.Rows[a].Cells[4].Value.ToString() + "'";//执行删除操作
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.ExecuteNonQuery();

            dataGridView1.Rows.RemoveAt(a);
            MessageBox.Show("删除成功");
        }
    }
}
