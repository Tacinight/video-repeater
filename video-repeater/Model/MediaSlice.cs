using System;

namespace VideoRepeater.Model
{
    public class MediaSlice
    {
        public TimeSpan Entry { get; set; }
        public TimeSpan Exit { get; set; }
        public TimeSpan Duration { get; set; }

        public MediaSlice(TimeSpan entry, TimeSpan exit)
        {
            Entry = entry;
            Exit = exit;
            Duration = Exit - Entry;
        }
    }
}
