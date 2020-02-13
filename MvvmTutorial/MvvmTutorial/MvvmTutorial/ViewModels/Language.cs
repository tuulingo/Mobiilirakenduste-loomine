using System;
using System.Collections.Generic;
using System.Text;

namespace MvvmTutorial
{
    class Language
    {
        public string Name { get; set; }
        public string ShortName { get; set; }
        public string ImageUrl { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
