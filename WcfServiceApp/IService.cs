using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using GenericRepositoryLibrary.Entities;

namespace WcfServiceApp
{
    [ServiceContract]
    public interface IService
    {
        [OperationContract]
        User Authorization(string email, string password);

        
        #region //Возвращение List всех моделей

        [OperationContract]
        List<Customer> GetCustomers();

        [OperationContract]
        List<File> GetFiles();

        [OperationContract]
        List<HistoryProject> GetHistoryProjects();

        [OperationContract]
        List<HistoryTask> GetHistoryTasks();

        [OperationContract]
        List<Position> GetPositions();

        [OperationContract]
        List<Project> GetProjects();

        [OperationContract]
        List<Task> GetTasks();

        [OperationContract]
        List<User> GetUsers();

        [OperationContract]
        List<Worker> GetWorkers();

        [OperationContract]
        List<TaskFile> GetTaskFiles();
        #endregion 
    }
}
