using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPT.Entities
{
  
    public class CustomerResultResponse
    {
        public List<UserViewModel> Result { get; set; }
        public APIResponseEntity APIResponse = new APIResponseEntity();

    }
    public class APIResponseEntity
    {
        #region Public Serializable properties.
        public string ResponseCode { get; set; }
        public string ResponseType { get; set; }
        public string ResponseDescription { get; set; }


        #endregion

        #region Public Constructor.
        public APIResponseEntity()
        {

        }
        public APIResponseEntity(string responseCode, string responseType, string responseDescription)
        {
            ResponseCode = responseCode;
            ResponseType = responseType;
            ResponseDescription = responseDescription;
        }
        #endregion
    }
}
