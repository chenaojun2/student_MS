//修改
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace 勤工俭学管理系统
{
    public partial class 修改 : Form
    {
        private int C_id;
        private MySqlConnection conn;   // mysql连接
        private MySqlDataAdapter myadp; // mysql数据适配器
        private DataSet myds;   // 数据集
        private BindingSource BindingSource = new BindingSource();
        public 修改(int c_id)
        {
            C_id = c_id;
            InitializeComponent();
        }

        private void 修改_Load(object sender, EventArgs e)
        {
            string str = "Server=localhost;User ID=root;Password=8888;Database=pt_job_ms;CharSet='utf8';";
            conn = new MySqlConnection(str);//实例化链接
            conn.Open();
            string sql = "select Work_time as 工作时间,Work_adress as 工作地址,Work_number as 工作人数,Work_salary as 时薪" +
                    ",Work_content as 工作内容,Full_salary as 全勤奖,Atend_max as 全勤奖需求,Work_duration as 工作时长 from work where C_id = " + C_id + "";
            myadp = new MySqlDataAdapter(sql, conn);
            myds = new DataSet();
            myadp.Fill(myds, "table1");//填充数据
            BindingSource.DataSource = myds.Tables["table1"];
            dataGridView1.DataSource = BindingSource;//绑定数据
        }

        private void button1_Click(object sender, EventArgs e)
        {

           if(myds.HasChanges())
            {
                MySqlCommandBuilder mySqlCommandBuilder = new MySqlCommandBuilder(myadp);
                try
                {
                    int a = dataGridView1.CurrentRow.Index;
                    myadp.Update(myds, "table1");//利用datagirdview更新数据数据
                    dataGridView1.Refresh();
                    string sql = "update work set Flag = 2 where Work_time = '"+dataGridView1.Rows[a].Cells[0].Value.ToString()+"' and Work_adress = '"+dataGridView1.Rows[a].Cells[1].Value.ToString()+"'" +
                        " and Work_content = '"+dataGridView1.Rows[a].Cells[4].Value.ToString()+"'";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);//将flag值置2，表示这条记录是申请的记录
                    cmd.ExecuteNonQuery();
                }
                catch
                {
                    MessageBox.Show("数据修改不正确");//报错
                }
               

            }
        }
    }
}
