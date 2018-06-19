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

        [OperationContract]
        void AddNewProject(File file, Project project, User user, string comment);

        [OperationContract]
        void EditProject(File file, Project project, string comment, User user);

        [OperationContract]
        void DeleteProject(Project project);


        [OperationContract]
        void AddNewWorker(Worker worker, File photo, File resume, User user);

        [OperationContract]
        void EditWorker(Worker worker, File photo, File resume, User user);

        [OperationContract]
        void DeleteWorker(Worker worker);

        [OperationContract]
        void AddNewTask(Task task, List<File> lstFiles, User user, string comment);

        [OperationContract]
        void EditTask(Task task, List<File> lstFiles, List<File> lstDelete, User user, string comment);

        [OperationContract]
        void DeleteTask(Task task);

        [OperationContract]
        void EditStatusProject(Project project, int status, User user, string comment);

        [OperationContract]
        void EditStatusTask(Task task, int status, User user, string comment);

        [OperationContract]
        void EditPriorityTask(Task task, int priority);

        [OperationContract]
        void EditLogin(User user, string mail, string password);

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

        [OperationContract]
        List<Solution> GetSolutions();

        [OperationContract]
        List<SolutionFile> GetSolutionFiles();
        #endregion 
    }
}
