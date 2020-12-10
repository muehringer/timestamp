using System.Collections.Generic;
using System.Threading.Tasks;
using TimeStamp.Application.ViewModels;

namespace TimeStamp.Application.Interfaces
{
    public interface IHackerNewsApp
    {
        Task<(List<DetailsBestStoriesVm>, string)> GetDetailsBestStories(int firstTop);
    }
}
