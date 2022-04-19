namespace LogicLayer.Interfaces
{
    public interface IAuthLogic
    {
        string AuthenticateUser(string email, string password);
    }
}