using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;


namespace wpfdrop
{
    [Serializable()]
    public class Words
    {
        public List<string> s2 { get; set; }
        public List<string> s3 { get; set; }
        public List<string> s1 { get; set; }
        public List<string> s4 { get; set; }

        public string keysq { get; set; }

        public string pathsq { get; set; }

        public string rulesq { get; set; }

        public string actionq { get; set; }

        public string image { get; set; }

    }
}
