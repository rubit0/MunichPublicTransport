using System.Collections.Generic;

namespace MunichPublicTransport.Models
{
    public class Line
    {
        public List<object> Tram { get; set; }
        public List<object> Nachttram { get; set; }
        public List<object> Sbahn { get; set; }
        public List<object> Ubahn { get; set; }
        public List<object> Bus { get; set; }
        public List<object> Nachtbus { get; set; }
        public List<object> Otherlines { get; set; }
    }
}