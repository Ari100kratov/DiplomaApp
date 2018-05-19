using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StankoServiceApp.Entities
{
    public partial class HistoryTask
    {
        public int Id { get; set; }

        public DateTime DateTime { get; set; }

        public int UserId { get; set; }

        public int StatusId { get; set; }

        public string Comment { get; set; }

        public int TaskId { get; set; }

        //public Task Task => Dm.Task.GetList().FirstOrDefault(x => x.Id == this.TaskId);

        //public User User => Dm.User.GetList().FirstOrDefault(x => x.Id == this.UserId);
    }
}
