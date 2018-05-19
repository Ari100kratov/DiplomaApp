using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StankoServiceApp.Entities
{
    public partial class Position
    {
        public int Id { get; set; }

        public string PositionName { get; set; }

        //public List<Worker> Workers => Dm.Worker.GetList().Where(x => x.PositionId == this.Id).ToList();
    }
}
