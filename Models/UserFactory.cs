using System;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace Models
{
    [DataContract]
    public class UserFactory
    {
        [DataMember]
        public Guid Id = Guid.NewGuid();
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public int Age { get; set; }
        [DataMember]
        public string City { get; set; }
    }
}
