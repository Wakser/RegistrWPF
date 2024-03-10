using MaterialDesignThemes.Wpf;
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
using System.Windows.Shapes;

namespace RegistrWPF
{
    /// <summary>
    /// Логика взаимодействия для Autorization.xaml
    /// </summary>
    public partial class Autorization : Window
    {
        public Autorization()
        {
            InitializeComponent();
        }

        private void Registration(object sender, RoutedEventArgs e)
        {
            MainWindow window = new MainWindow();
            this.Hide();
            window.ShowDialog();
            this.Close();
        }

        private void LogIn(object sender, RoutedEventArgs e)
        {
            using (Context db = new Context())
            {
                var list = db.Users.Where(x => x.login == u_login.Text);
                if (list.Count() > 0)
                {
                    if(list.First().password == u_password.Text)
                    {
                        GlobalName.UserName = u_login.Text;
                        Tasks tasks = new Tasks();
                        this.Hide();
                        tasks.ShowDialog();
                        this.Close();
                    }
                }    
                else
                {
                    MessageBox.Show("Error");
                }
            }
        }
    }
}
