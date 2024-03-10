using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Логика взаимодействия для Tasks.xaml
    /// </summary>
    public partial class Tasks : Window
    {
        public static BindingList<Task> tasks = new BindingList<Task>();
        public Tasks()
        {
            InitializeComponent();
            using (Context db = new Context())
            {
                if (db.Tasks.Count() > 0)
                {
                    foreach (var t in db.Tasks)
                    {
                        tasks.Add(t);
                    }
                    dgTasks.ItemsSource = tasks;
                }
            }
        }

        private void New_Task(object sender, RoutedEventArgs e)
        {
            NewTask newtask = new NewTask();
            newtask.ShowDialog();
        }

        public void Refresh(object sender, RoutedEventArgs e)
        {
            using (Context db = new Context())
            {
                tasks.Clear();
                foreach (var t in db.Tasks)
                {
                    tasks.Add(t);
                }
                dgTasks.ItemsSource = tasks;
            }
        }

        private void DeleteTask(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;

            using(Context db = new Context())
            {
                Task task = db.Tasks.FirstOrDefault(x => x.Name==btn.Tag.ToString());
                db.Tasks.Remove(task);
                db.SaveChanges();
            }
            Refresh(sender, e);
        }
    }
}
