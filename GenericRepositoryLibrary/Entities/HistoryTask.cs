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
    public partial class HistoryTask : IKeyedModel
    {
        private DataManager Dm => DataManager.Instance;

        [DataMember]
        [PrimaryKey]
        [FieldDb]
        public int Id { get; set; }

        [DataMember]
        [PrimaryKey]
        public DateTime DateTime { get; set; }

        [DataMember]
        [PrimaryKey]
        public int UserId { get; set; }

        [DataMember]
        [PrimaryKey]
        public int StatusId { get; set; }

        [DataMember]
        [PrimaryKey]
        public string Comment { get; set; }

        [DataMember]
        [PrimaryKey]
        public int TaskId { get; set; }

        public Task Task => Dm.Task.GetList().FirstOrDefault(x => x.Id == this.TaskId);

        public User User => Dm.User.GetList().FirstOrDefault(x => x.Id == this.UserId);
    }
}
