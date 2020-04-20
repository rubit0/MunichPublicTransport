using System;
using MunichPublicTransport.Misc;
using Newtonsoft.Json;

namespace MunichPublicTransport.Models
{
    public class Departure
    {
        [JsonConverter(typeof(MillisecondsUnixTimeConverter))]
        public DateTimeOffset DepartureTime { get; set; }
        public string Product { get; set; }
        public string Label { get; set; }
        public string Destination { get; set; }
        public bool Live { get; set; }
        public int Delay { get; set; }
        public bool Cancelled { get; set; }
        public string LineBackgroundColor { get; set; }
        public string DepartureId { get; set; }
        public bool Sev { get; set; }
        public string Platform { get; set; }
    }
}