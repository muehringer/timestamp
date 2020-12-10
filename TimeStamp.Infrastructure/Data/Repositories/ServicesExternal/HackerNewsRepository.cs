using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using TimeStamp.Infrastructure.Constants;
using TimeStamp.Infrastructure.Contracts;
using TimeStamp.Infrastructure.Data.Interfaces.ServicesExternal;

namespace TimeStamp.Infrastructure.Data.Repositories.ServicesExternal
{
    public class HackerNewsRepository : IHackerNewsRepository
    {
        private readonly HttpClient _httpClient;

        public HackerNewsRepository()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(Environment.GetEnvironmentVariable("https://hacker-news.firebaseio.com/"));
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(RepositoryConstants.MEDIA_TYPE));
        }

        public async Task<BestStoriesResponse> GetBestStories()
        {
            BestStoriesResponse response = new BestStoriesResponse();
           
            using (var get = await _httpClient.GetAsync(RepositoryConstants.URL_GET_BEST_STORIES))
            {
                if (get.IsSuccessStatusCode)
                {
                    response = JsonConvert.DeserializeObject<BestStoriesResponse>(await get.Content.ReadAsStringAsync());
                    response.Success = true;
                }
                else
                {
                    response.Error = JsonConvert.DeserializeObject<BestStoriesErrorResponse>(await get.Content.ReadAsStringAsync());
                    response.Success = false;
                }
            }

            return response;
        }

        public async Task<DetailsStoryResponse> GetDetailStory(DetailsStoryRequest request)
        {
            DetailsStoryResponse response = new DetailsStoryResponse();

            using (var get = await _httpClient.GetAsync(RepositoryConstants.URL_GET_DETAIL_STORY + request.IdStorie + ".json"))
            {
                if (get.IsSuccessStatusCode)
                {
                    response = JsonConvert.DeserializeObject<DetailsStoryResponse>(await get.Content.ReadAsStringAsync());
                    response.Success = true;
                }
                else
                {
                    response.Error = JsonConvert.DeserializeObject<DetailsStoryErrorResponse>(await get.Content.ReadAsStringAsync());
                    response.Success = false;
                }
            }

            return response;
        }
    }
}
