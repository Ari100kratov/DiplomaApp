using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StankoServiceApp.ServiceReference
{
    public partial class Task
    {
        public Worker Worker => App.Service.GetWorkers().FirstOrDefault(x => x.Id == this.WorkerId);

        public Project Project => App.Service.GetProjects().FirstOrDefault(x => x.Id == this.ProjectId);

        public List<HistoryTask> History => App.Service.GetHistoryTasks().Where(x => x.TaskId == this.Id).ToList();

        public List<TaskFile> Files => App.Service.GetTaskFiles().Where(x => x.TaskId == this.Id).ToList();
    }
}
