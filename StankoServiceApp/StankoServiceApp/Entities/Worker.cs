using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace StankoServiceApp.ServiceReference
{
    public partial class Worker
    {
        public File Photo => App.Service.GetFiles().FirstOrDefault(x => x.Id == this.PhotoId);

        public List<Project> Projects => App.Service.GetProjects().Where(x => x.WorkerId == this.Id).ToList();

        public List<Task> Tasks => App.Service.GetTasks().Where(x => x.WorkerId == this.Id).ToList();

        public User User => App.Service.GetUsers().FirstOrDefault(x => x.Id == this.UserId);
    }
}
