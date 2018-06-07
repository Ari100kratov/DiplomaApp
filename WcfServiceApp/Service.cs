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

        public int AddNewProject(File file, Project project)
        {
            if (file != null)
            {
                var lastIdFile = Dm.File.Add(file);
                project.FileId = lastIdFile;
            }

            return DataManager.Instance.Project.Add(project);
        }

        public void EditProject(File file, Project project)
        {
            if (file != null)
            {
                var checkFile = Dm.File.GetList().FirstOrDefault(x => x.Id == file.Id);
                if (checkFile == null)
                {
                    var lastIdFile = Dm.File.Add(file);
                    project.FileId = lastIdFile;
                }
            }
            else
            {
                if (project.File != null)
                {
                    project.FileId = null;
                    Dm.File.Delete(file);
                }
            }

            DataManager.Instance.Project.Update(project);
        }

        public void DeleteProject(Project project)
        {
            var file = Dm.File.GetList().FirstOrDefault(x => x.Id == project.FileId);

            if (file != null)
            {
                Dm.File.Delete(file);
            }

            Dm.Project.Delete(project);
        }

        public void AddNewWorker(Worker worker, File file, User user)
        {
            if (file != null)
            {
                var lastIdFile = DataManager.Instance.File.Add(file);
                worker.PhotoId = lastIdFile;
            }

            var lastIdUser = DataManager.Instance.User.Add(user);
            worker.UserId = lastIdUser;

            DataManager.Instance.Worker.Add(worker);
        }

        public void EditWorker(Worker worker, File file, User user)
        {
            if (file == null)
            {
                if (worker.Photo != null)
                {
                    worker.PhotoId = null;
                    DataManager.Instance.File.Delete(worker.Photo);
                }
            }
            else
            {
                if (worker.Photo != null)
                {
                    DataManager.Instance.File.Update(file);
                }
                else
                {
                    var lastId = DataManager.Instance.File.Add(file);
                    worker.PhotoId = lastId;
                }
            }

            DataManager.Instance.User.Update(user);
            DataManager.Instance.Worker.Update(worker);
        }

        public void DeleteWorker(Worker worker)
        {
            if (worker.Photo != null)
            {
                Dm.File.Delete(worker.Photo);
            }

            Dm.User.Delete(worker.User);
            Dm.Worker.Delete(worker);
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
