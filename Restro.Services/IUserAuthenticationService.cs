using Restro.Models;

namespace Restro.Services
{
    public interface IUserAuthenticationService
    {
        bool ValidateUser(string username, string password);
        User GetUser(string email, string password);
        bool AddUser(string email, string password);
    }
}
