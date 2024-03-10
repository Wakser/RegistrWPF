using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RegistrWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Autorization_Button(object sender, RoutedEventArgs e)
        {
            Autorization window = new Autorization();
            this.Hide(); 
            window.ShowDialog();
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(login_text.Text.Length > 2 && password_text.Text.Length > 4) 
            {
                User user = new User();
                user.login = login_text.Text;
                user.password = password_text.Text;
                using(Context db = new Context())
                {
                    if(db.Users.Where(x => x.login == login_text.Text).Count() == 0)
                    {
                        db.Users.Add(user);
                        db.SaveChanges();
                    }
                    else
                    {
                        MessageBox.Show("Пользователь с таким username уже существует");
                    }
                }
            }
            else
            {
                MessageBox.Show("Неправильный ввод логина или пароля");
            }
        }
    }
}