using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MySql.Data.MySqlClient;

namespace WpfApp2
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.MouseDown += delegate { DragMove(); };
        }
        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);

            // Begin dragging the window
            this.DragMove();
        }
        public MainWindow()
        {
            InitializeComponent();



        }

        static String connetStr = "server=localhost;port=3306;user=wzwz5200;password=wzwz5200; database=wzwz5200;";
        MySqlConnection conn = new MySqlConnection(connetStr);
        private bool check()
        {
            bool result = false;
            string sql = "select * from c_key where kami = @para1";
            MySqlCommand cmd = new MySqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("para1", _6.Text);


            MySqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                result = true;
            }

            return result;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                conn.Open();
                if (check())
                {
                    Window1 Mn = new Window1();
                    Mn.Show();

                    this.Close();
                }
                else
                {
                    MessageBox.Show("卡密错误");
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
