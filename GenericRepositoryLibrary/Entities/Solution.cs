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
    public partial class Solution : IKeyedModel
    {
        DataManager Dm => DataManager.Instance;

        [DataMember]
        [PrimaryKey]
        [FieldDb]
        public int Id { get; set; }

        [DataMember]
        [FieldDb]
        public string Comment { get; set; }

        [DataMember]
        [FieldDb]
        public DateTime DateTime { get; set; }

        public List<SolutionFile> SolutionFiles => Dm.SolutionFile.GetList().Where(x => x.SolutionId == this.Id).ToList();
    }
}
