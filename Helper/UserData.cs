using SecureAuthPOC.Models;

namespace SecureAuthPOC.Helper
{
    public class UserData
    {
        // static UserData()
        //{
        //    //GetData();
        //}
        public   List<Users> GetData()
        {
            List<Users> users = new List<Users>();
            users.Add(new Users { email = "vignesh@gmail.com", phonenumber = "9876543210" });
            users.Add(new Users { email = "dinesh@gmail.com", phonenumber = "9876543210" });
            return users;
        }
    }
}
