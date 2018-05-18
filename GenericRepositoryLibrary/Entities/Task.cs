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
    public partial class Task: IKeyedModel
    {
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
        public int? FileId { get; set; }
    }
}
