using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    class User
    {
        private string mUsername;
        private string mPassword;
        private string mProfilePNGDirectory;
        private IList<Playlist> mPlaylists;

        public User(string name, string pass)
        {
            string path = System.Environment.CurrentDirectory;
            mUsername = name;
            mPassword = pass;
            mProfilePNGDirectory = path.Substring(0, path.LastIndexOf("bin")) + "Images\\" + mUsername + ".png";
            mPlaylists = null;
        }

        public void addPlaylist(Playlist newPlaylist)
        {
            mPlaylists.Add(newPlaylist);
        }

        public void deletePlaylist(Playlist playlist)
        {
            mPlaylists.Remove(playlist);
        }
    }
}
