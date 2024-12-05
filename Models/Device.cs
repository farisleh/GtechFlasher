using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTechFlasher.Models
{
    public class Device
    {
        public string? SerialNumber { get; set; }
        public string? FirmwareVersion { get; set; }
        public string? Vbatt { get; set; }
        public string? LocationFixTime { get; set; }
        public decimal? Latitude { get; set; }
        public decimal? Longitude { get; set; }
        public string? Timestamp { get; set; }
    }
}
