using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeStamp.Infrastructure.Constants;
using TimeStamp.Infrastructure.Contracts;
using TimeStamp.Infrastructure.Data.Interfaces.ServicesExternal;
using TimeStamp.Infrastructure.Data.Repositories.ServicesExternal;
using TimeStamp.Infrastructure.Errors;
using TimeStamp.Infrastructure.Helpers;

namespace TimeStamp.Domain.Entities
{
    public class Story
    {
        private IHackerNewsRepository _hackerNewsRepository;

        public async Task<(List<DetailsBestStoriesResponse>, string)> GetDetailsBestStories(int firstTop)
        {
            List<DetailsBestStoriesResponse> response = new List<DetailsBestStoriesResponse>();

            _hackerNewsRepository = new HackerNewsRepository();

            var bestStories = await _hackerNewsRepository.GetBestStories();

            if (!bestStories.Success)
                return (null, EnumHelper.GetDescription(StoryError.GetDetailsBestStories_400_NoBestStoriesFound));

            if (bestStories.IdsStories.Count == 0)
                return (null, EnumHelper.GetDescription(StoryError.GetDetailsBestStories_400_NoBestStoriesFound));

            var bestStoriesTopLimit = bestStories.IdsStories.Take(RepositoryConstants.LIMIT_BEST_STORIES).ToList();

            foreach (var item in bestStoriesTopLimit)
            {
                var detailStory = await _hackerNewsRepository.GetDetailStory(new DetailsStoryRequest() { IdStorie = item });

                response.Add(new DetailsBestStoriesResponse()
                {
                    Title = detailStory.Title,
                    Uri = detailStory.Url,
                    PostedBy = detailStory.By,
                    Time = detailStory.Time.UtcDateTime,
                    Score = detailStory.Score,
                    CommentCount = detailStory.Kids.Count
                });
            }

            return (response.OrderByDescending(x => x.Score).ToList(), null);
        }
    }
}
