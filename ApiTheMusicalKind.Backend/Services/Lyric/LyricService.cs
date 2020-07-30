namespace ApiTheMusicalKind.Backend.Services.Lyric
{
    public class LyricService : BaseService, ILyricService
    {
        public string Get(string resourceUrl)
        {
            return Item(resourceUrl);
        }

        public int GetCount(string resourceUrl)
        {
            return Count(resourceUrl);
        }

        //private static string Item(string resourceUrl)
        //{
        //    var baseAddress = new Uri("https://api.lyrics.ovh/v1/");

        //    using var httpClient = new HttpClient { BaseAddress = baseAddress };
        //    using var response = httpClient.GetAsync(resourceUrl);

        //    var responseData = response.Result.Content.ReadAsStringAsync();

        //    var result = JsonConvert.DeserializeObject<Models.Lyric>(responseData.Result);

        //    return result.Lyrics;
        //}
    }
}
