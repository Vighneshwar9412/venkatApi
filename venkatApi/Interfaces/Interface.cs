using ApplicationApi.Models;
using ApplicationApi.Responses;


namespace ApplicationApi.Interfaces
{
    public interface Interface
    {
        public  Task<ApiResponse> RegisterNewuser( Userdata user) ;
        public  Task<Boolean> IsuserExist(Userdata user);
    }
    
}
