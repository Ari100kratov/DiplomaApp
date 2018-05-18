using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelParametersLibrary.Attributes;
using ModelParametersLibrary.Interfaces;
using System.ServiceModel;

namespace GenericRepositoryLibrary.Entities
{

    public partial class User : IKeyedModel
    {
        [PrimaryKey]
        [FieldDb]
        public int Id { get; set; }

        [FieldDb]
        public string Email { get; set; }

        [FieldDb]
        public string Password { get; set; }

        [FieldDb]
        public int RoleId { get; set; }
    }
}
