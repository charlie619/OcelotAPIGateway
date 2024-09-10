namespace AuthService_JWT.Service
{
    public interface ITokenService
    {
        string BuildToken(string key, string issuer, IEnumerable<string> audience, string userName);
    }
}
