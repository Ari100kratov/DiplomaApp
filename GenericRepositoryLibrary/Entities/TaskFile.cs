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
    public partial class TaskFile : IKeyedModel
    {
        private DataManager Dm => DataManager.Instance;

        [DataMember]
        [PrimaryKey]
        [FieldDb]
        public int Id { get; set; }

        [DataMember]
        [FieldDb]
        public int TaskId { get; set; }

        [DataMember]
        [FieldDb]
        public int FileId { get; set; }

        public Task Task => DataManager.Instance.Task.GetList().FirstOrDefault(x => x.Id == this.TaskId);

        public File File => DataManager.Instance.File.GetList().FirstOrDefault(x => x.Id == this.FileId);
    }
}
