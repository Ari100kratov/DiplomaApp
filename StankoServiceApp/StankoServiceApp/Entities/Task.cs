using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StankoServiceApp.Entities
{
    public partial class Task
    {
        public int Id { get; set; }

        public string TaskName { get; set; }

        public int? WorkerId { get; set; }

        public int? ProjectId { get; set; }

        public Nullable<DateTime> EndDate { get; set; }

        public int StatusId { get; set; }

        public int? FileId { get; set; }

        //public Worker Worker => Dm.Worker.GetList().FirstOrDefault(x => x.Id == this.WorkerId);

        //public Project Project => Dm.Project.GetList().FirstOrDefault(x => x.Id == this.ProjectId);

        //public List<HistoryTask> History => Dm.HistoryTask.GetList().Where(x => x.TaskId == this.Id).ToList();
    }
}
