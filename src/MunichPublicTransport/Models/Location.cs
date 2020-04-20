using System.Collections.Generic;

namespace MunichPublicTransport.Models
{
    public class Location
    {
        public string Type { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Id { get; set; }
        public int DivaId { get; set; }
        public string Place { get; set; }
        public string Name { get; set; }
        public bool HasLiveData { get; set; }
        public bool HasZoomData { get; set; }
        public List<string> Products { get; set; }
        public int Distance { get; set; }
        public Line Lines { get; set; }
    }
}