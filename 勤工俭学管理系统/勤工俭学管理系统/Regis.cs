//Regis类
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace 勤工俭学管理系统
{
    class Regis
    {
        private int Level;
        private string Sql;
        public Regis(int level,string sql)
        {
            Sql = sql;
            Level = level;
        }

        public void Regising()
        {
            string str = "Server=localhost;User ID=root;Password=8888;Database=pt_job_ms;CharSet='utf8';";
            string sql;
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

            if (Level == 1)//level=1，表示注册用户为管理用户
            {
                sql = "insert into manager (M_user_name,M_user_pass,P_number,M_name) values ("+Sql+")";//构造sql语句
                Console.WriteLine(sql);
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.ExecuteNonQuery();
            }
            else if(Level == 2)//level = 2，表示注册用户为学生用户
            {
                sql = "insert into student (S_user_name,S_user_pass,S_name,Sex,Major,Class,P_number,Time,Bank_name) values (" + Sql + ")";
                Console.WriteLine(sql);
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.ExecuteNonQuery();
            }
            else if(Level == 3)//level =3 ，表示注册用户为企业用户
            {
                sql = "insert into company (C_user_name,C_user_pass,Legal_person,C_number) values (" + Sql + ")";
                Console.WriteLine(sql);
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
