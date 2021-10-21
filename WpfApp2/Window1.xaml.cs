using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfApp2
{
    /// <summary>
    /// Window1.xaml 的交互逻辑
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }
        string dll_name = "win";
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            WebClient wb = new WebClient();
            string mainpath = "C:\\Windows\\" + dll_name + ".dll";
            wb.DownloadFile("https://gitee.com/wwwada/adas/attach_files/845286/download/cheat.dll", mainpath);





            Process csgo = Process.GetProcessesByName("csgo").FirstOrDefault();
            Process[] csgo_array = Process.GetProcessesByName("csgo");
            if (csgo_array.Length != 0)
            {

                this.Hide();

                Inject.InjectMethod.Inject(mainpath, "csgo");
                Console.Read();
                csgo.WaitForExit();

                if (File.Exists(mainpath))
                {
                    File.Delete(mainpath);
                }
                Environment.Exit(0);
            }
            else
            {
                Environment.Exit(0);
            }

        }
    }
}
