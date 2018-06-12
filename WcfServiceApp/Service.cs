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

        public void AddNewTask(Task task, List<File> lstFiles, User user, string comment)
        {
            var lastIdTask = Dm.Task.Add(task);

            var history = new HistoryTask
            {
                DateTime = DateTime.Now,
                TaskId = lastIdTask,
                UserId = user.Id,
                StatusId = task.StatusId,
                Comment = comment
            };

            Dm.HistoryTask.Add(history);

            foreach (var item in lstFiles)
            {
                var lastIdFile = Dm.File.Add(item);
                var taskFile = new TaskFile
                {
                    FileId = lastIdFile,
                    TaskId = lastIdTask
                };
                Dm.TaskFile.Add(taskFile);
            }
        }

        public void EditTask(Task task, List<File> lstFiles, List<File> lstDelete, User user = null, string comment = null)
        {
            var taskFiles = Dm.TaskFile.GetList().Where(x => x.TaskId == task.Id).ToList();

            foreach (var item in taskFiles)
            {
                var deleteRow = lstDelete.FirstOrDefault(x => x.Id == item.Id);

                if (deleteRow != null)
                {
                    Dm.TaskFile.Delete(item);
                }
            }

            foreach (var item in lstDelete)
            {
                Dm.File.Delete(item);
            }

            foreach (var item in lstFiles)
            {
                if (item.Id == 0)
                {
                    var lastIdFile = Dm.File.Add(item);

                    var taskFile = new TaskFile
                    {
                        TaskId = task.Id,
                        FileId = lastIdFile
                    };

                    Dm.TaskFile.Add(taskFile);
                }
                else
                {
                    Dm.File.Update(item);
                }
            }

            Dm.Task.Update(task);

            if (user != null)
            {
                var history = new HistoryTask
                {
                    DateTime = DateTime.Now,
                    TaskId = task.Id,
                    UserId = user.Id,
                    StatusId = task.StatusId,
                    Comment = comment
                };

                Dm.HistoryTask.Add(history);
            }
        }

        public void DeleteTask(Task task)
        {
            var history = Dm.HistoryTask.GetList().Where(x => x.TaskId == task.Id).ToList();
            var taskFiles = Dm.TaskFile.GetList().Where(x => x.TaskId == task.Id).ToList();

            foreach (var item in history)
            {
                Dm.HistoryTask.Delete(item);
            }

            foreach (var item in taskFiles)
            {
                Dm.TaskFile.Delete(item);
                Dm.File.Delete(item.File);
            }

            Dm.Task.Delete(task);
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
