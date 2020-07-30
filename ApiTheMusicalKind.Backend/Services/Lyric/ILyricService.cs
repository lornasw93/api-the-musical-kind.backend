namespace ApiTheMusicalKind.Backend.Services.Lyric
{
    public interface ILyricService
    {
        string Get(string resourceUrl);
        int Count(string resourceUrl);
    }
}
