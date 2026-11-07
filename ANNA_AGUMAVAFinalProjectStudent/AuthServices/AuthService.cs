using ANNA_AGUMAVAFinalProjectStudent.User;
using System.Security.Cryptography;
using System.Text;

namespace ANNA_AGUMAVAFinalProjectStudent.AuthServices;
internal class AuthService
{
    private List<Users> users = new List<Users>();
    private static readonly byte[] fixedSalt = Encoding.UTF8.GetBytes("MyProject");
    private static string GetHashPasswords(string password)
    {
        return HashPassword(password, fixedSalt);
    }
    public bool Register(string userName, string password)
    {
        Users? ExistingUser = users.FirstOrDefault(u => u.UserName == userName);
        if(ExistingUser is not null)
        {
            return true;
        }
        Users newUser = new Users(userName, GetHashPasswords(password));
        users.Add(newUser);
        return true;
    }
    public Users? GetUser(string userName, string password) 
    {
        return users.FirstOrDefault(u => u.UserName == userName && u.PasswordHash == GetHashPasswords(password));
    }
    static string HashPassword(string password, byte[] salt)
    {
        using (var sha256 = SHA256.Create())
        {
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
            byte[] saltedPassword = new byte[passwordBytes.Length + salt.Length];

            Buffer.BlockCopy(passwordBytes, 0, saltedPassword, 0, passwordBytes.Length);
            Buffer.BlockCopy(salt, 0, saltedPassword, passwordBytes.Length, salt.Length);

            byte[] hashedBytes = sha256.ComputeHash(saltedPassword);

            byte[] hashedPasswordWithSalt = new byte[hashedBytes.Length + salt.Length];
            Buffer.BlockCopy(salt, 0, hashedPasswordWithSalt, 0, salt.Length);
            Buffer.BlockCopy(hashedBytes, 0, hashedPasswordWithSalt, salt.Length, hashedBytes.Length);

            return Convert.ToBase64String(hashedPasswordWithSalt);
        }
    }
}
