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

        public void AddNewProject(File file, Project project, User user, string comment)
        {
            if (file != null)
            {
                var lastIdFile = Dm.File.Add(file);
                project.FileId = lastIdFile;
            }

            var lastId = Dm.Project.Add(project);

            var history = new HistoryProject
            {
                Comment = comment,
                DateTime = DateTime.Now,
                ProjectId = project.Id,
                StatusId = project.StatusId,
                UserId = user.Id
            };

            Dm.HistoryProject.Add(history);
        }

        public void EditProject(File file, Project project, string comment, User user = null)
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

            if (user != null)
            {
                var history = new HistoryProject
                {
                    Comment = comment,
                    DateTime = DateTime.Now,
                    ProjectId = project.Id,
                    StatusId = project.StatusId,
                    UserId = user.Id
                };

                Dm.HistoryProject.Add(history);
            }

            Dm.Project.Update(project);

        }

        public void DeleteProject(Project project)
        {
            var file = Dm.File.GetList().FirstOrDefault(x => x.Id == project.FileId);
            var histroy = Dm.HistoryProject.GetList().Where(x => x.ProjectId == project.Id).ToList();
            foreach (var item in histroy)
            {
                Dm.HistoryProject.Delete(item);
            }

            if (file != null)
            {
                Dm.File.Delete(file);
            }

            Dm.Project.Delete(project);
        }

        public void AddNewWorker(Worker worker, File photo, File resume, User user)
        {
            if (photo != null)
            {
                var lastIdPhoto = Dm.File.Add(photo);
                worker.PhotoId = lastIdPhoto;
            }
            if (resume != null)
            {
                var lastIdResume = Dm.File.Add(resume);
                worker.ResumeId = lastIdResume;
            }

            var lastIdUser = Dm.User.Add(user);
            worker.UserId = lastIdUser;

            Dm.Worker.Add(worker);
        }

        public void EditWorker(Worker worker, File photo, File resume, User user)
        {
            if (photo == null)
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
                    DataManager.Instance.File.Update(photo);
                }
                else
                {
                    var lastId = DataManager.Instance.File.Add(photo);
                    worker.PhotoId = lastId;
                }
            }

            if (resume == null)
            {
                if (worker.Resume != null)
                {
                    worker.ResumeId = null;
                    Dm.File.Delete(worker.Resume);
                }
            }
            else
            {
                if (worker.Resume != null)
                {
                    Dm.File.Update(resume);
                }
                else
                {
                    var lastId = Dm.File.Add(resume);
                    worker.ResumeId = lastId;
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

            if (worker.Resume != null)
            {
                Dm.File.Delete(worker.Resume);
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
