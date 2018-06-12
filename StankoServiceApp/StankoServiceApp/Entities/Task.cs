using StankoserviceEnums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace StankoServiceApp.ServiceReference
{
    public partial class Task
    {
        public StatusTask GetStatusTask => (StatusTask)this.StatusId;

        public PriorityTask GetPriorityTask => (PriorityTask)this.PriorityId;

        public BitmapImage StatusIcon
        {
            get
            {
                switch (this.StatusId)
                {
                    case (0):
                        return Methods.ConvertFromBitmap(Properties.Resources.task1);
                    case (1):
                        return Methods.ConvertFromBitmap(Properties.Resources.task2);
                    case (2):
                        return Methods.ConvertFromBitmap(Properties.Resources.task3);
                    case (3):
                        return Methods.ConvertFromBitmap(Properties.Resources.task4);
                    case (4):
                        return Methods.ConvertFromBitmap(Properties.Resources.task5);
                    case (5):
                        return Methods.ConvertFromBitmap(Properties.Resources.task6);
                    default:
                        return Methods.ConvertFromBitmap(Properties.Resources.task1);
                }
            }
        }

        public BitmapImage PriorityIcon
        {
            get
            {
                switch (this.PriorityId)
                {
                    case (0):
                        return Methods.ConvertFromBitmap(Properties.Resources.priority1);
                    case (1):
                        return Methods.ConvertFromBitmap(Properties.Resources.priority2);
                    case (2):
                        return Methods.ConvertFromBitmap(Properties.Resources.priority3);
                    case (3):
                        return Methods.ConvertFromBitmap(Properties.Resources.priority4);
                    case (4):
                        return Methods.ConvertFromBitmap(Properties.Resources.priority5);
                    case (5):
                        return Methods.ConvertFromBitmap(Properties.Resources.priority6);
                    default:
                        return Methods.ConvertFromBitmap(Properties.Resources.priority1);
                }
            }
        }
        public User Manager => App.Service.GetUsers().FirstOrDefault(x => x.Id == this.ManagerId);

        public Worker Worker => App.Service.GetWorkers().FirstOrDefault(x => x.Id == this.WorkerId);

        public Project Project => App.Service.GetProjects().FirstOrDefault(x => x.Id == this.ProjectId);

        public List<HistoryTask> History => App.Service.GetHistoryTasks().Where(x => x.TaskId == this.Id).ToList();

        public List<TaskFile> Files => App.Service.GetTaskFiles().Where(x => x.TaskId == this.Id).ToList();
    }
}
