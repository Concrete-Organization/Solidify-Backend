using System.Text.Json.Serialization;

namespace Solidify.Application.Community.Helper
{
    public abstract class EngineerInfo
    {
        [JsonIgnore]
        public string UserId { get; set; }
        public string? EngineerName { get; set; }
        public string? ProfileImageUrl { get; set; }
    }
}
