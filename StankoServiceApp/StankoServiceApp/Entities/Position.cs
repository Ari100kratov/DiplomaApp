using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StankoServiceApp.ServiceReference
{
    public partial class Position
    {
        public List<Worker> Workers => App.Service.GetWorkers().Where(x => x.PositionId == this.Id).ToList();
    }
}
