using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using ModelParametersLibrary.Attributes;
using ModelParametersLibrary.Interfaces;

namespace GenericRepositoryLibrary.Entities
{
    [DataContract]
    public partial class Project : IKeyedModel
    {
        private DataManager Dm => DataManager.Instance;

        [DataMember]
        [PrimaryKey]
        [FieldDb]
        public int Id { get; set; }

        [DataMember]
        [FieldDb]
        public string Name { get; set; }

        [DataMember]
        [FieldDb]
        public DateTime StartDate { get; set; }

        [DataMember]
        [FieldDb]
        public Nullable<DateTime> EndDate { get; set; }

        [DataMember]
        [FieldDb]
        public Nullable<DateTime> CompletionDate { get; set; }

        [DataMember]
        [FieldDb]
        public int StatusId { get; set; }

        [DataMember]
        [FieldDb]
        public int? FileId { get; set; }

        [DataMember]
        [FieldDb]
        public int? CustomerId { get; set; }

        [DataMember]
        [FieldDb]
        public int WorkerId { get; set; }

        [DataMember]
        [FieldDb]
        public int TypePeriodId { get; set; }

        public File File => Dm.File.GetList().FirstOrDefault(x => x.Id == this.FileId);

        public Customer Customer => Dm.Customer.GetList().FirstOrDefault(x => x.Id == this.CustomerId);

        public Worker Worker => Dm.Worker.GetList().FirstOrDefault(x => x.Id == this.WorkerId);

        public List<Task> Tasks => Dm.Task.GetList().Where(x => x.ProjectId == this.Id).ToList();

        public List<HistoryProject> History => Dm.HistoryProject.GetList().Where(x => x.ProjectId == this.Id).ToList();
    }
}
