using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GenericRepositoryLibrary;
using GenericRepositoryLibrary.Entities;

namespace WcfServiceApp
{
    public class Service : IService
    {
        private DataManager Dm => DataManager.Instance;

        public User Authorization(string email, string password)
        {
            return Dm.User.GetList().FirstOrDefault(x => x.Email == email && x.Password == password);
        }

        #region //Реализация получения List всех моделей
        public List<Customer> GetCustomers()
        {
            return Dm.Customer.GetList();
        }

        public List<TaskFile> GetTaskFiles()
        {
            return Dm.TaskFile.GetList();
        }

        public List<File> GetFiles()
        {
            return Dm.File.GetList();
        }

        public List<HistoryProject> GetHistoryProjects()
        {
            return Dm.HistoryProject.GetList();
        }

        public List<HistoryTask> GetHistoryTasks()
        {
            return Dm.HistoryTask.GetList();
        }

        public List<Position> GetPositions()
        {
            return Dm.Position.GetList();
        }

        public List<Project> GetProjects()
        {
            return Dm.Project.GetList();
        }

        public List<Task> GetTasks()
        {
            return Dm.Task.GetList();
        }

        public List<User> GetUsers()
        {
            return Dm.User.GetList();
        }

        public List<Worker> GetWorkers()
        {
            return Dm.Worker.GetList();
        }

        #endregion
    }
}
