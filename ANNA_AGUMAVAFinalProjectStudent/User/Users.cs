namespace ANNA_AGUMAVAFinalProjectStudent.User;

internal class Users
{
    private static int id = 1;
    public int Id { get; set; } = id++;
    public string UserName { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty;
    public Users() { }
    public Users(string userName, string PasswordHash)
    {
        this.UserName = userName;
        this.PasswordHash = PasswordHash;
    }
}
