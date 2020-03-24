using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace PicturesApp.Data
{
    public class ImageData
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public String Path { get; set; }
    }
}
