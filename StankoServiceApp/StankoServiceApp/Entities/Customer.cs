using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StankoServiceApp.Entities
{
    public partial class Customer
    {
        

        public int Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        //public List<Project> Projects => App.Service.GetProjects().Where(x => x.CustomerId == this.Id).ToList();
    }
}
