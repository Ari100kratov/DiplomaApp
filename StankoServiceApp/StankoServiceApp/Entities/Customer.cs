using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StankoServiceApp.ServiceReference
{
    public partial class Customer
    {

        public List<Project> Projects => App.Service.GetProjects().Where(x => x.CustomerId == this.Id).ToList();
    }
}
