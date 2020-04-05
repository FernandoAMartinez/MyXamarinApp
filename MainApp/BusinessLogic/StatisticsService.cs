using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Entity;

namespace BusinessLogic
{
    public class StatisticsService
    {
        private const string HostHeader = "Your-Host-HeaderInfo";
        private const string KeyHeader = "Your-Key-HeaderInfo";

        private static StatisticsService statisticsService;
        public static StatisticsService Instance
        {
            get
            {
                if (statisticsService == null)
                    statisticsService = new StatisticsService();
                return statisticsService;
            }
        }
        private ICustomSerializable jsonSerializer;
        public StatisticsService()
        {
            jsonSerializer = new JsonSerializer();
        }
        public async Task<Statistics> GetUpdatedCasesAsync(string country)
        {
            using (var apiClient = new HttpClient())
            {
                apiClient.DefaultRequestHeaders.Accept.Clear();
                apiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                apiClient.DefaultRequestHeaders.Add("x-rapidapi-host", HostHeader);
                apiClient.DefaultRequestHeaders.Add("x-rapidapi-key", KeyHeader);

                //Call to RapidAPI endpoint - COVID19 - Statistics
                //Created by KishCom and publised in RapidAPI: https://rapidapi.com/KishCom/api/covid-19-coronavirus-statistics
                var responseMessage = await apiClient.GetAsync($"https://covid-19-coronavirus-statistics.p.rapidapi.com/v1/stats?country={country}");

                if (responseMessage.IsSuccessStatusCode)
                {
                    var response = responseMessage.Content;
                    var json = await response.ReadAsStringAsync();
                    Statistics statistics = jsonSerializer.Deserialize<Statistics>(json);
                    return statistics;
                }
                else return null;
            }
        }
    }
}
