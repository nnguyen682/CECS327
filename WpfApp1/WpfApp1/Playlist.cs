using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    class Playlist
    {
        private string mName;
        private IList<Song> mSongs;

        public Playlist(string name)
        {
            mName = name;
            mSongs = null;
        }

        public void addSong(Song newSong)
        {
            mSongs.Add(newSong);
        }

        public void deleteSong(Song song)
        {
            mSongs.Remove(song);
        }
    }
}
