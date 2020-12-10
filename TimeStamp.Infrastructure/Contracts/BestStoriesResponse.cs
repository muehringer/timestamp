using Newtonsoft.Json;
using System.Collections.Generic;

namespace TimeStamp.Infrastructure.Contracts
{
    public class BestStoriesResponse
    {
        public List<int> IdsStories { get; set; }
        [JsonIgnore]
        public bool Success { get; set; }
        [JsonIgnore]
        public BestStoriesErrorResponse Error { get; set; }
    }

    public class BestStoriesErrorResponse
    {
        public string Code { get; set; }
        public string Message { get; set; }
    }
}
