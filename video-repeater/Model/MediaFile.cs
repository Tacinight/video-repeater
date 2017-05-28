using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace VideoRepeater.Model
{
    public class MediaFile
    {
        public string Name { get; set; }
        public StorageFile VideoFile { get; set; }
        public string ImageFile { get; set; }

        public MediaFile(string name, StorageFile videofile)
        {
            Name = name;
            VideoFile = videofile;
        }
    }
}
