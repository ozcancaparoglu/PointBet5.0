using NLog;

namespace Logging
{
    public class LogRequestModel
    {
        public string EntityType { get; set; }
        public int EntityId { get; set; }
        public string Message { get; set; }
        public int ProcessBy { get; set; }
        public LogLevel LogLevel { get; set; }
    }
}