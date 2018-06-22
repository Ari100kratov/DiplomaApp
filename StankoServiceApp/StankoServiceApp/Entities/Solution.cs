using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StankoServiceApp.ServiceReference
{
    public partial class Solution
    {

        public List<SolutionFile> SolutionFiles => App.Service.GetSolutionFiles().Where(x => x.SolutionId == this.Id).ToList();
    }
}
