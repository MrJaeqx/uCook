using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace uCook_TimeLineHost
{
    [DataContract]
    public class TimeLineData
    {
        public TimeLineData()
        {
            Name = "Hello ";
            SayHello = false;
        }

        [DataMember]
        public bool SayHello { get; set; }

        [DataMember]
        public string Name { get; set; }
    }
}