using Azure.Core;
using Azure;

namespace AlbumStorer
{
    public class SpotifyTest
    {
        public async Task<string> GetSpotifyAlbum()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://spotify23.p.rapidapi.com/albums/?ids=1SqpXb3ugUynp0iZgOSWrI"),
                Headers =
            {
                { "X-RapidAPI-Key", "f0e39b92d7msh07cf16641e6814dp19344djsnc81ac049dc3b" },
                { "X-RapidAPI-Host", "spotify23.p.rapidapi.com" },
            },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                
                return body;
            }

         
        }
    }
     
}
