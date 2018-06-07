using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.ServiceModel;
using StankoserviceEnums;

namespace StankoServiceApp.ServiceReference
{
    public partial class User
    {
        Worker Worker => App.Service.GetWorkers().FirstOrDefault(x => x.UserId == this.Id);

        public Role RoleUser
        {
            get
            {
                return (Role)this.RoleId;
            }
            set
            {
                this.RoleId = (int)value;
            }
        }
    }
}
