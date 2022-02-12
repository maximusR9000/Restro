using Restro.Models;

namespace Restro.Services
{
    public class UserAuthenticationService : IUserAuthenticationService
    {
        private readonly ProjectDBContext _projectDBContext;
        public UserAuthenticationService(ProjectDBContext projectDBContext)
        {
            this._projectDBContext = projectDBContext;
        }

        public bool ValidateUser(string username, string password)
        {
            var user = this._projectDBContext.Users.SingleOrDefault(user => user.Email.Equals(username) && user.Password.Equals(password));
            if (user == null)
                return false;
            return true;
        }

        public User GetUser(string email, string password)
        {
            return this._projectDBContext.Users.SingleOrDefault(user => user.Email.Equals(email) && user.Password.Equals(password));
        }

        public bool AddUser(string email, string password)
        {
            User tUser = new User()
            {
                Email = email, 
                Password = password, 
                Role = "User"
            };

            this._projectDBContext.Users.Add(tUser);
            this._projectDBContext.SaveChanges();

            return true;
        }
    } 
}
