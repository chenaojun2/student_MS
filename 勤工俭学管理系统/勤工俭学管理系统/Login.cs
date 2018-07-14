//Login类
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace 勤工俭学管理系统
{
    class Login
    {
        private string user_name;
        private string user_pass;
        private string user_type;
        private MySqlDataReader reader;

        public Login(string name,string pass,string type)
        {
            user_name = name;//通过参数获取用户名
            user_pass = pass;//通过参数获取密码
            user_type = type;//通过参数获取用户类型
        }

        public int Logining()
        {
            int flag = 0;//作为返回值，标识返回的是什么用户，同时还有学生和企业的相关id，由于此处的代码问题，系统只能暂时支持10000用户
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

            if ( user_type == "管理")//如果是管理用户
            {
                Console.WriteLine("检验管理");
                string sql = "select * from Manager where M_user_name = '" + user_name + "'and M_user_pass = '" + user_pass + "'";
                MySqlCommand cmd = new MySqlCommand(sql, con);
                reader = cmd.ExecuteReader();//读取数据
                if (reader.Read())
                {
                    flag = int.Parse(reader[3].ToString())+10;//用户标识
                }
                else
                flag = 0;
            }
            else if(user_type=="学生")//如果是学生用户
            {
                Console.WriteLine("检验学生");
                string sql = "select * from student where S_user_name = '" + user_name + "'and S_user_pass = '" + user_pass + "'";
                MySqlCommand cmd = new MySqlCommand(sql, con);//同上
                reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    flag = int.Parse(reader[0].ToString()) + 20000;
                }
                else
                    flag = 0;
            }
            else if(user_type=="公司")//如果是企业用户
            {
                Console.WriteLine("检验公司");
                string sql = "select * from company where C_user_name = '" + user_name + "'and C_user_pass = '" + user_pass + "'";
                Console.WriteLine(sql);
                MySqlCommand cmd = new MySqlCommand(sql, con);//同上
                reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    flag = int.Parse(reader[0].ToString()) + 30000;
                    Console.WriteLine("" + flag);
                }
                else
                    flag = 0;
            }
            con.Close();
            return flag;
        }
    }
}
