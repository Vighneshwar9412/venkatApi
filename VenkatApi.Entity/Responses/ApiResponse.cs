using System.Net;
using System.Runtime.Serialization;
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

        public List<Userdata> Users { set; get; }
    }
}
