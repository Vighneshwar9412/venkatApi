using System.Net;
using System.Runtime.Serialization;
using ApplicationApi.Entity.Models;
using ApplicationApi.Models;

namespace ApplicationApi.Responses
{
    public class ApiResponse
    {
        [DataMember]
        public HttpStatusCode status { set; get; }
        [DataMember]
        public Boolean IsSuccess { set; get; }
        [DataMember]
        public Userdata Body { set; get; }
        [DataMember]
        public dynamic Users { set; get; }
        [DataMember]
        public userLoginCredentialdata Logindata { set; get; }  
    }
}
