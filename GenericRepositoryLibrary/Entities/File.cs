using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using ModelParametersLibrary.Attributes;
using ModelParametersLibrary.Interfaces;

namespace GenericRepositoryLibrary.Entities
{
    [DataContract]
    public partial class File : IKeyedModel
    {
        [DataMember]
        [PrimaryKey]
        [FieldDb]
        public int Id { get; set; }

        [DataMember]
        [FieldDb]
        public string FileName { get; set; }

        [DataMember]
        [FieldDb]
        public string Title { get; set; }

        [DataMember]
        [FieldDb]
        public byte[] Data { get; set; }

        [DataMember]
        [FieldDb]
        public Nullable<DateTime> ChangeDate { get; set; }
    }
}
