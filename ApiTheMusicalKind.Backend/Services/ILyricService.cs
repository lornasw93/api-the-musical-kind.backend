namespace ApiTheMusicalKind.Backend.Services
{
    public interface ILyricService
    {
        string Get(string resourceUrl);
        int Count(string resourceUrl);
    }
}
