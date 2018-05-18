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
        public CustomerRepository Customer => new CustomerRepository();
        public FileRepository File => new FileRepository();
        public PositionRepository Position => new PositionRepository();
        public ProjectRepository Project => new ProjectRepository();
        public TaskRepository Task => new TaskRepository();
        public WorkerRepository Worker => new WorkerRepository();
        public HistoryProjectRepository HistoryProject => new HistoryProjectRepository();
        public HistoryTaskRepository HistoryTask => new HistoryTaskRepository();

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
