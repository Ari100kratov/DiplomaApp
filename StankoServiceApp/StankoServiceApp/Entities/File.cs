using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StankoServiceApp.Entities
{
    public partial class File
    {
        public int Id { get; set; }

        public string FileName { get; set; }

        public string Title { get; set; }

        public byte[] Data { get; set; }
    }
}
