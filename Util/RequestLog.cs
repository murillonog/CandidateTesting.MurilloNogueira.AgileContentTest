using System.Net.Http;
using System.Threading.Tasks;

namespace CandidateTesting.MurilloNogueira.AgileContentTest.Util
{
    public class RequestLog
    {
        private static readonly HttpClient client = new HttpClient();
        public string Log { get; set; }

        public async Task GetLogAsync(string url)
        {
            var response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                Log = await response.Content.ReadAsStringAsync();
            }
            else
            {
                Log = string.Empty;
            }
        }
    }
}
