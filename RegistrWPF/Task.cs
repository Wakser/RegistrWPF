using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistrWPF
{
    public class Task
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; } = GlobalName.UserName;
        public string Description { get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;

    }
}
