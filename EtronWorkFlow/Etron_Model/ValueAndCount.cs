using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Etron_Model
{
    [DataContract]
    public class ValueAndCount
    {
        [DataMember]
        public List<ContractDisplay> Content { set; get; }

        [DataMember]
        public Int32 Count { set; get; }
    }
}
