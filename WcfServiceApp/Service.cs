using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GenericRepositoryLibrary;
using GenericRepositoryLibrary.Entities;

namespace WcfServiceApp
{
    public class Service : IService
    {
        public User Authorization(string email, string password)
        {
            return DataManager.Instance.User.GetList().FirstOrDefault(x => x.Email == email && x.Password == password);
        }
    }
}
