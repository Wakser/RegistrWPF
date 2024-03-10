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
    /// Логика взаимодействия для NewTask.xaml
    /// </summary>
    public partial class NewTask : Window
    {
        public NewTask()
        {
            InitializeComponent();
        }

        private void CreateNewTask(object sender, RoutedEventArgs e)
        {
            Task task = new Task();
            task.Name = task_name.Text;
            task.Description = task_desc.Text;
            using(Context db = new Context())
            {
                db.Tasks.Add(task);
                db.SaveChanges();
            }
            this.Close();
        }
    }
}
