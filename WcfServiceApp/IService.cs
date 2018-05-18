using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using GenericRepositoryLibrary.Entities;

namespace WcfServiceApp
{
    [ServiceContract]
    public interface IService
    {
        [OperationContract]
        User Authorization(string email, string password);
    }
}
