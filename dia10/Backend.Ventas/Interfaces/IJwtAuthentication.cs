
namespace Backend.Ventas.Interfaces
{
    public interface IJwtAuthentication
    {
        string Authenticate(string username, string password);        
    }
}
