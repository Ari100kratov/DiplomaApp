using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StankoServiceApp.ServiceReference
{
    public partial class Worker
    {
        //public int Id { get; set; }

        //public string Name { get; set; }

        //public string Surname { get; set; }

        //public string Patronymic { get; set; }

        //public DateTime DateOfBirth { get; set; }

        //public DateTime DateOfEmploy { get; set; }

        //public string Phone { get; set; }

        //public int PhotoId { get; set; }

        //public int PositionId { get; set; }

        //public int UserId { get; set; }

        //public File Photo => Dm.File.GetList().FirstOrDefault(x => x.Id == this.PhotoId);

        //public List<Project> Projects => Dm.Project.GetList().Where(x => x.WorkerId == this.Id).ToList();

        //public List<Task> Tasks => Dm.Task.GetList().Where(x => x.WorkerId == this.Id).ToList();

        public User User => App.Service.GetUsers().FirstOrDefault(x => x.Id == this.UserId);
    }
}
