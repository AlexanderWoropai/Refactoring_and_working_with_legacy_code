using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryForRefactoring
{
    public class FileSourceFactory
    {
        public IFileSource Create(string type, AllConfigs allConfigs)
        {
            if (type == "TXT") return new TxtFileSource(allConfigs);
            if (type == "YAML") return new YamlFileSource(allConfigs);
            return null;
        }
    }
}
