namespace Springboard365.Xrm.Authentication
{
    using System.Threading.Tasks;

    public interface IAuthenticationService
    {
        Task<Token> AcquireTokenAsync(string resource, string tenant, ClientCredentials clientCredentials, UserCredentials userCredentials);
    }
}