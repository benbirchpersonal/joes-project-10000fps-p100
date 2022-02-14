using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MajorProjectDesktop
{
    internal class User
    {
        private string _username;
        private string _password;
        private int[] _currentLocation = new int[2];

        public string Username { get => _username; set => _username = value; }
        public string Password { get => _password; set => _password = value; }
        public int[] CurrentLocation { get => _currentLocation; set => _currentLocation = value; }

        public User(int[] start)
        {
            CurrentLocation = start;
        }

        public void Movement()
        {
            //if (Input.GetKey(Keycode.W)
            //{

            //}
        }
    }
}
