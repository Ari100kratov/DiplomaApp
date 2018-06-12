using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StankoServiceApp.ServiceReference
{
    public partial class TaskFile
    {
        public File File => App.Service.GetFiles().FirstOrDefault(x => x.Id == this.FileId);

        public Task Task => App.Service.GetTasks().FirstOrDefault(x => x.Id == this.TaskId);
    }
}
