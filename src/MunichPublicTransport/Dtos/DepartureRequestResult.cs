using System.Collections.Generic;
using MunichPublicTransport.Models;

namespace MunichPublicTransport.Dtos
{
    public class DepartureRequestResult
    {
        public List<ServingLine> ServingLines;
        public List<Departure> Departures { get; set; }
    }
}