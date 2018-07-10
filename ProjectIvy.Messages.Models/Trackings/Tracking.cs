using System;
using Newtonsoft.Json;

namespace ProjectIvy.Messages.Models.Trackings
{
    public class Tracking
    {
        [JsonProperty("ac")]
        public decimal? Accuracy { get; set; }

        [JsonProperty("al")]
        public decimal? Altitude { get; set; }

        [JsonProperty("lt")]
        public decimal Latitude { get; set; }

        [JsonProperty("ln")]
        public decimal Longitude { get; set; }

        [JsonProperty("t")]
        public DateTime Timestamp { get; set; }

        [JsonProperty("s")]
        public decimal? Speed { get; set; }

        [JsonProperty("u")]
        public int UserId { get; set; }
    }
}
