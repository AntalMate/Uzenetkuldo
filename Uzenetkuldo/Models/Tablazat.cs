using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Uzenetkuldo.Models
{
    [DataContract]   
    public class Tablazat
    {
        [DataMember]
        public int Id { get; set; }
    }
}
