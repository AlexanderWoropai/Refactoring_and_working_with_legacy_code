using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RLCLab
{
    public class FileSourceFactory
    {
        public IFileSource Create(string type) 
        {
            if (type == "TXT") return new TxtFileSource();
            if (type == "YAML") return new YamlFileSource();
            return null;
        }
    }
}
