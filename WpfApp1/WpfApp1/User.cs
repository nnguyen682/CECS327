using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    public class User
    {
        public string mUsername;
        public string mPassword;
        public string mProfilePNGDirectory;
        public string mName;
        public string mEmail;
        public string mBirthday;
        public IList<Playlist> mPlaylists;

        public User(string name, string pass, string flName, string email, string birthday)
        {
            string path = System.Environment.CurrentDirectory;
            mUsername = name;
            mPassword = pass;
            mName = flName;
            mEmail = email;
            mBirthday = birthday;
            mProfilePNGDirectory = path.Substring(0, path.LastIndexOf("bin")) + "Images\\" + mUsername + ".png";
            mPlaylists = null;
        }

        void addPlaylist(Playlist newPlaylist)
        {
            mPlaylists.Add(newPlaylist);
        }

        void deletePlaylist(Playlist playlist)
        {
            mPlaylists.Remove(playlist);
        }
    }
}
