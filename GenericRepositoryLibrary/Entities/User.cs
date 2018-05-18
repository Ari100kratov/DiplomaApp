using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelParametersLibrary.Attributes;
using ModelParametersLibrary.Interfaces;
using System.ServiceModel;
using System.Runtime.Serialization;

namespace GenericRepositoryLibrary.Entities
{
    [DataContract]
    public partial class User : IKeyedModel
    {
        private DataManager Dm => DataManager.Instance;

        [DataMember]
        [PrimaryKey]
        [FieldDb]
        public int Id { get; set; }

        [DataMember]
        [FieldDb]
        public string Email { get; set; }

        [DataMember]
        [FieldDb]
        public string Password { get; set; }

        [DataMember]
        [FieldDb]
        public int RoleId { get; set; }

        public Worker Worker => Dm.Worker.GetList().FirstOrDefault(x => x.UserId == this.Id);
    }
}
