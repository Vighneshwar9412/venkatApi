using System.Linq;
using ApplicationApi.Models;

namespace ApplicationApi.DAL.database
{
    public  class UserData
    {
        private static List<Userdata> usersData = new List<Userdata>();

        private Userdata _data;
        private string _email;
        public UserData(Userdata data)
        {
            _data = data;

        }
        /*
        public List<Userdata> addNewUser()
        {
            try
            {
                usersData.Add(_data);
            }
            catch (Exception)
            {
                throw new Exception("Fail to Add data in db ");

            }
            
            return usersData;

        }*/
        public Boolean IsuserExist( ) {

            Boolean flag = false;
            _email = _data.email;

            usersData.ForEach(userData => { if (userData.email == _email) { flag = true; } });
            
            return flag;

        }
        public List<Userdata> getAllUser()
        {
             
            return usersData;

        }

    }
}
