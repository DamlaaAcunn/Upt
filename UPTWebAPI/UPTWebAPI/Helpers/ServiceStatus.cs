using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace MYBSHWebAPI.Helpers
{
    #region Status Object Class
    [Serializable]
    [DataContract]
    public class ServiceStatus
    {
        #region Public properties.       
        [JsonProperty("StatusCode")]
        [DataMember]
        public int StatusCode { get; set; }
      
        [JsonProperty("StatusMessage")]
        [DataMember]
        public string StatusMessage { get; set; }
        
        [JsonProperty("ReasonPhrase")]
        [DataMember]
        public string ReasonPhrase { get; set; }

        #endregion
    }

    #endregion
}