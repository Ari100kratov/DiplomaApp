using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StankoServiceApp.ServiceReference
{
    public partial class Project
    {
        public File File => App.Service.GetFiles().FirstOrDefault(x => x.Id == this.FileId);

        public Customer Customer => App.Service.GetCustomers().FirstOrDefault(x => x.Id == this.CustomerId);

        public Worker Worker => App.Service.GetWorkers().FirstOrDefault(x => x.Id == this.WorkerId);

        public List<Task> Tasks => App.Service.GetTasks().Where(x => x.ProjectId == this.Id).ToList();

        public List<HistoryProject> History => App.Service.GetHistoryProjects().Where(x => x.ProjectId == this.Id).ToList();
    }
}
