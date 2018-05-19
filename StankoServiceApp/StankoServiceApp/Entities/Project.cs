using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StankoServiceApp.Entities
{
    public partial class Project
    {
        public int Id { get; set; }

        public DateTime StartDate { get; set; }

        public Nullable<DateTime> EndDate { get; set; }

        public Nullable<DateTime> CompletionDate { get; set; }

        public int StatusId { get; set; }

        public int? FileId { get; set; }

        public int CustomerId { get; set; }

        public int WorkerId { get; set; }

        public int TypePeriodId { get; set; }

        //public File File => Dm.File.GetList().FirstOrDefault(x => x.Id == this.FileId);

        //public Customer Customer => Dm.Customer.GetList().FirstOrDefault(x => x.Id == this.CustomerId);

        //public Worker Worker => Dm.Worker.GetList().FirstOrDefault(x => x.Id == this.WorkerId);

        //public List<Task> Tasks => Dm.Task.GetList().Where(x => x.ProjectId == this.Id).ToList();

        //public List<HistoryProject> History => Dm.HistoryProject.GetList().Where(x => x.ProjectId == this.Id).ToList();
    }
}
