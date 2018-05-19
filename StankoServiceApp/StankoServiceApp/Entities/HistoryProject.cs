using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StankoServiceApp.Entities
{
    public partial class HistoryProject
    {
        public int Id { get; set; }

        public DateTime DateTime { get; set; }

        public int UserId { get; set; }

        public int StatusId { get; set; }

        public string Comment { get; set; }

        public int ProjectId { get; set; }

        //public Project Project => Dm.Project.GetList().FirstOrDefault(x => x.Id == this.ProjectId);

        //public User User => Dm.User.GetList().FirstOrDefault(x => x.Id == this.UserId);
    }
}
