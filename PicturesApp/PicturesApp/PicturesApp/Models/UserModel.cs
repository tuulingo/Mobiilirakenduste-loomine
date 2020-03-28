using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace PicturesApp.Models
{
    public class UserModel
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string ProfilePicturePath { get; set; }
        public UserModel()
        {
        }

    }
}
