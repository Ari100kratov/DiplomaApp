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
    public partial class Worker : IKeyedModel
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
        public string Surname { get; set; }

        [DataMember]
        [FieldDb]
        public string Patronymic { get; set; }

        [DataMember]
        [FieldDb]
        public DateTime DateOfBirth { get; set; }

        [DataMember]
        [FieldDb]
        public DateTime DateOfEmploy { get; set; }

        [DataMember]
        [FieldDb]
        public string Phone { get; set; }

        [DataMember]
        [FieldDb]
        public int? PhotoId { get; set; }

        [DataMember]
        [FieldDb]
        public int PositionId { get; set; }

        [DataMember]
        [FieldDb]
        public int UserId { get; set; }

        [DataMember]
        [FieldDb]
        public int? ResumeId { get; set; }

        public File Photo => Dm.File.GetList().FirstOrDefault(x => x.Id == this.PhotoId);

        public File Resume => Dm.File.GetList().FirstOrDefault(x => x.Id == this.ResumeId);

        public List<Project> Projects => Dm.Project.GetList().Where(x => x.WorkerId == this.Id).ToList();

        public List<Task> Tasks => Dm.Task.GetList().Where(x => x.WorkerId == this.Id).ToList();

        public User User => Dm.User.GetList().FirstOrDefault(x => x.Id == this.UserId);
    }
}
