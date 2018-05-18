using GenericRepositoryLibrary.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericRepositoryLibrary
{
    public sealed class DataManager
    {

        public UserRepository User => new UserRepository();

        static DataManager _active = null;
        static object _syncRoot = new object();

        public static DataManager Instance
        {
            get
            {
                if (_active == null)
                    lock (_syncRoot)
                        if (_active == null)
                            _active = new DataManager();

                return _active;
            }
        }

        public DataManager()
        {

        }
    }
}
