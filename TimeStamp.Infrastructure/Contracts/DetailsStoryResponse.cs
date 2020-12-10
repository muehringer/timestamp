using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace TimeStamp.Infrastructure.Contracts
{
    public class DetailsStoryResponse
    {
        public string By { get; set; }
        public int Descendants { get; set; }
        public int Id { get; set; }
        public List<int> Kids { get; set; }
        public int Score { get; set; }
        public string Text { get; set; }
        public DateTimeOffset Time { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }
        public string Url { get; set; }
        [JsonIgnore]
        public bool Success { get; set; }
        [JsonIgnore]
        public DetailsStoryErrorResponse Error { get; set; }
    }

    public class DetailsStoryErrorResponse
    {
        public string Code { get; set; }
        public string Message { get; set; }
    }
}
