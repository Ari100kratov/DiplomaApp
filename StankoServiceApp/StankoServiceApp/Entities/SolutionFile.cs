using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StankoServiceApp.ServiceReference
{
    public partial class SolutionFile
    {
        public Solution Solution => App.Service.GetSolutions().FirstOrDefault(x => x.Id == this.SolutionId);

        public File File => App.Service.GetFiles().FirstOrDefault(x => x.Id == this.FileId);
    }
}
