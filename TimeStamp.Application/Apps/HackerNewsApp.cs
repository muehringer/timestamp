using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using TimeStamp.Application.Interfaces;
using TimeStamp.Application.ViewModels;
using TimeStamp.Domain.Entities;

namespace TimeStamp.Application.Apps
{
    public class HackerNewsApp : IHackerNewsApp
    {
        private Story story;
        private IMapper _mapper;

        public HackerNewsApp(IMapper mapper)
            => _mapper = mapper;

        public async Task<(List<DetailsBestStoriesVm>, string)> GetDetailsBestStories(int firstTop)
        {
            story = new Story();

            var detailsBestStories = await story.GetDetailsBestStories(firstTop);

            if (detailsBestStories.Item1.Count > 0)
                return (_mapper.Map<List<DetailsBestStoriesVm>>(detailsBestStories.Item1), null);
            else
                return (null, detailsBestStories.Item2);
        }
    }
}
