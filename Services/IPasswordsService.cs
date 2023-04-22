namespace Services
{
    public interface IPasswordsService
    {
        int GetPasswordStrength(string password);
    }
}