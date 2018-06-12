using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelParametersLibrary.Attributes;
using ModelParametersLibrary.Interfaces;
using System.Runtime.Serialization;

namespace GenericRepositoryLibrary.Entities
{
    [DataContract]
    public partial class Task : IKeyedModel
    {
        private DataManager Dm => DataManager.Instance;

        [DataMember]
        [PrimaryKey]
        [FieldDb]
        public int Id { get; set; }

        [DataMember]
        [FieldDb]
        public string TaskName { get; set; }

        [DataMember]
        [FieldDb]
        public int? WorkerId { get; set; }

        [DataMember]
        [FieldDb]
        public int? ProjectId { get; set; }

        [DataMember]
        [FieldDb]
        public Nullable<DateTime> EndDate { get; set; }

        [DataMember]
        [FieldDb]
        public int StatusId { get; set; }

        [DataMember]
        [FieldDb]
        public int PriorityId { get; set; }

        [DataMember]
        [FieldDb]
        public string Description { get; set; }

        [DataMember]
        [FieldDb]
        public Nullable<DateTime> CompletionDate { get; set; }

        [DataMember]
        [FieldDb]
        public int ManagerId { get; set; }

        public User Manager => Dm.User.GetList().FirstOrDefault(x => x.Id == this.ManagerId);

        public Worker Worker => Dm.Worker.GetList().FirstOrDefault(x => x.Id == this.WorkerId);

        public List<TaskFile> Files => Dm.TaskFile.GetList().Where(x => x.TaskId == this.Id).ToList();

        public Project Project => Dm.Project.GetList().FirstOrDefault(x => x.Id == this.ProjectId);

        public List<HistoryTask> History => Dm.HistoryTask.GetList().Where(x => x.TaskId == this.Id).ToList();
    }
}
