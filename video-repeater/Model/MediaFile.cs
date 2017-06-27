using Windows.Storage;

namespace VideoRepeater.Model
{
    public class MediaFile
    {
        public string Name { get; set; }
        public StorageFile VideoFile { get; set; }
        public string ImageFile { get; set; }

        public MediaFile(string name, StorageFile videofile, string image)
        {
            Name = name;
            VideoFile = videofile;
            ImageFile = image;
        }
    }
}
