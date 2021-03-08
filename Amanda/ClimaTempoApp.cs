using System.Collections.Generic;

namespace Amanda
{
    class ClimaTempoApp
    {
        public class coord
        {
            public double lon { get; set; }
            public double lat { get; set; }
        }
        public class weather
        {
            public string main { get; set; }
            public string description { get; set; }
        }
        public class main
        {
            public double temp { get; set; }
            public double feels_like { get; set; }
            public double temp_min { get; set; }
            public double temp_max { get; set; }
            public double pressure { get; set; }
            public double humidity { get; set; }
        }
        public class wind
        {
            public double speed { get; set; }
            public double deg { get; set; }
        }
        public class root
        {
            public coord coord { get; set; }
            public wind wind { get; set; }
            public main main { get; set; }
            public string name { get; set; }
            public List<weather> weather { get; set; }
        }
    }
}
