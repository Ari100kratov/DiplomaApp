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
        public int PhotoId { get; set; }

        [DataMember]
        [FieldDb]
        public int PositionId { get; set; }

        [DataMember]
        [FieldDb]
        public int UserId { get; set; }
    }
}
