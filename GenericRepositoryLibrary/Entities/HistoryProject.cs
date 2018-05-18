﻿using System;
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
    public partial class HistoryProject : IKeyedModel
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
        public int ProjectId { get; set; }

        public Project Project => Dm.Project.GetList().FirstOrDefault(x => x.Id == this.ProjectId);

        public User User => Dm.User.GetList().FirstOrDefault(x => x.Id == this.UserId);
    }
}
