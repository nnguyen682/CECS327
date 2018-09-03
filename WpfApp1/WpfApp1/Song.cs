using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    class Song
    {
        private string mTitle;
        private string mAlbumTitle;
        private string mArtist;
        private string mMp3Directory;
        private string mAlbumPngDirectory;

        public Song(string title, string album, string artist)
        {
            string path = System.Environment.CurrentDirectory;
            mTitle = title;
            mAlbumTitle = album;
            mArtist = artist;
            mMp3Directory = path.Substring(0, path.LastIndexOf("bin")) + "MusicLibrary\\" + mArtist + "-" + title + ".mp3";
            mAlbumPngDirectory = path.Substring(0, path.LastIndexOf("bin")) + "Images\\" + mArtist + "-" + title + ".png";
        }
    }
}
