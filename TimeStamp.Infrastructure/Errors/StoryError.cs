using System.ComponentModel;

namespace TimeStamp.Infrastructure.Errors
{
    public enum StoryError
    {
        [Description("No best stories found.")]
        GetDetailsBestStories_400_NoBestStoriesFound
    }
}
