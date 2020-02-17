using System;
using System.Collections.Generic;
using System.Text;

namespace MvvmTutorial
{
    public class Language
    {
        public string Name { get; set; }
        public string ShortName { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
