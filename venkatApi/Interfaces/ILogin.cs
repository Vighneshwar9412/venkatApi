using ApplicationApi.DAL.database;
using ApplicationApi.Models;

namespace ApplicationApi.Interfaces
{
    public interface ILogin
    {

        public dynamic LoginRepository();

        public Boolean pass_uName_cheeck();


    }
}
