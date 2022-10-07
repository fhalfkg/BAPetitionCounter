using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows;

namespace BAPetitionCounter
{
    public class Info
    {
        [JsonPropertyName("agreCo")]
        public int Agreed { get; set; }
    }

    internal class PetitionInfoFetcher
    {
        async internal static Task<int> Fetch(string url)
        {
            try
            {
                HttpClient client = new();

                client.DefaultRequestHeaders.UserAgent.ParseAdd("PostmanRuntime/7.29.2");
                var response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                var result = response.Content.ReadAsStream();
                var content = await JsonSerializer.DeserializeAsync<Info>(result);
                if (content != null)
                {
                    return content.Agreed;
                }
                else
                {
                    return -1;
                }
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show(ex.Message);
                return -1;
            }
        }
    }
}
