using System.Threading.Tasks;
using TimeStamp.Infrastructure.Contracts;

namespace TimeStamp.Infrastructure.Data.Interfaces.ServicesExternal
{
    public interface IHackerNewsRepository
    {
        Task<BestStoriesResponse> GetBestStories();
        Task<DetailsStoryResponse> GetDetailStory(DetailsStoryRequest request);
    }
}
