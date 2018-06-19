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
    public partial class SolutionFile : IKeyedModel
    {
        DataManager Dm => DataManager.Instance;

        [DataMember]
        [PrimaryKey]
        [FieldDb]
        public int Id { get; set; }

        [DataMember]
        [FieldDb]
        public int FileId { get; set; }

        [DataMember]
        [FieldDb]
        public int SolutionId { get; set; }

        public File File => Dm.File.GetList().FirstOrDefault(x => x.Id == this.FileId);

        public Solution Solution => Dm.Solution.GetList().FirstOrDefault(x => x.Id == this.SolutionId);
    }
}
