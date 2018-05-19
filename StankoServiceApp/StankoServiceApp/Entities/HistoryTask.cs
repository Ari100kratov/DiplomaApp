using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StankoServiceApp.ServiceReference
{
    public partial class HistoryTask
    {
        public Task Task => App.Service.GetTasks().FirstOrDefault(x => x.Id == this.TaskId);

        public User User => App.Service.GetUsers().FirstOrDefault(x => x.Id == this.UserId);
    }
}
