using System.Text.Json.Serialization;

namespace Solidify.Application.Community.Helper
{
    public abstract class EngineerInfo
    {
        public int Id { get; set; }
        public string EngineerId { get; set; }
        public string? EngineerName { get; set; }
        public string? ProfileImageUrl { get; set; }
    }
}
