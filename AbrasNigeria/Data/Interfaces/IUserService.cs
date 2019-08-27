using AbrasNigeria.Models;
using System.Collections.Generic;


namespace AbrasNigeria.Data.Interfaces
{
    public interface IUserService
    {
        User Authenticate(string username, string password);
        IEnumerable<User> GetAll();
        User CreateUser(User user, string passord);
        void UpdateUser(User user, string password = null);
        User GetById(int id);
        void Delete(int id);
    }
}
