using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StankoServiceApp.ServiceReference
{
    public partial class HistoryProject
    {
        public Project Project => App.Service.GetProjects().FirstOrDefault(x => x.Id == this.ProjectId);

        public User User => App.Service.GetUsers().FirstOrDefault(x => x.Id == this.UserId);
    }
}
