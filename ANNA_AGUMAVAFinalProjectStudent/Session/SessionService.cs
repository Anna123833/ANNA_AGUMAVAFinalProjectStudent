using ANNA_AGUMAVAFinalProjectStudent.AuthServices;
using ANNA_AGUMAVAFinalProjectStudent.User;

namespace ANNA_AGUMAVAFinalProjectStudent.Session;

internal class SessionService
{
    private Users? currentUser = null;
    private AuthService authService;
    public bool IsLoggedIn
    {
        get
        {
            if(currentUser is not null)
            {
                return true;
            }
            return false;
        }
    }
    public SessionService()
    {
        authService = new AuthService();
    }
    public bool Login(string userName, string password)
    {
        Users? users = authService.GetUser(userName, password);
        if(users is not null)
        {
            currentUser = users;
            return true;
        }
        return false;
    }
    public bool LogOut()
    {
        if (IsLoggedIn)
        {
            currentUser = null;
            return true;
        }
        return false;
    }
}
