using venkatApi.Models;
namespace venkatApi.Interfaces
{
    public interface Interface
    {
        Task<dynamic> RegisterNewuser(HttpRequest req  , Userdata user );
    }
}
