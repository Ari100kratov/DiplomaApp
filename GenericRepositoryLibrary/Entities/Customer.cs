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
    public partial class Customer : IKeyedModel
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
        public string Address { get; set; }

        [DataMember]
        [FieldDb]
        public string Phone { get; set; }

        [DataMember]
        [FieldDb]
        public string Email { get; set; }

        public List<Project> Projects => DataManager.Instance.Project.GetList().Where(x => x.CustomerId == this.Id).ToList();
    }
}
