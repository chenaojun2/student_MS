using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace 勤工俭学管理系统
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            new 登陆().Show();
            Application.Run();
        }
    }
}
