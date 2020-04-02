using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace PrestationDeServicesWCFService
{
    [DataContract]
    public class Prestation
    {
        [DataMember]
        public String Id { get; set; }
        [DataMember]
        public String Nom { get; set; }
        [DataMember]
        public String Type { get; set; }
    }
}