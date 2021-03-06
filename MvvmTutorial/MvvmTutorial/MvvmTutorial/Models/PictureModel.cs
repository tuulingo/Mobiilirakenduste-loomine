﻿using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace MvvmTutorial.Models
{
    public class PictureModel
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public ImageSource Image { get; set; }

    }
}
