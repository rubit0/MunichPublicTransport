using System.Collections.Generic;

namespace MunichPublicTransport.Models
{
    public class Departures
    {
        public List<ServingLine> ServingLines;
        public List<Departure> NextDepartures;
    }
}