using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    public class Song
    {
        public string mTitle;
        public string mArtist;
        public string mExtension;
        public string Title { get => mTitle; set => mTitle = value; }
        public string Artist { get => mArtist; set => mArtist = value; }
        public string Extension { get => mExtension; set => mExtension = value; }
        public Song()
        {

        }
        public Song(string title,  string artist)
        {
            mTitle = title;
            mArtist = artist;
        }
        public Song(string title, string artist, string extension)
        {
            mTitle = title;
            mArtist = artist;
            mExtension = extension;
        }
    }
}
