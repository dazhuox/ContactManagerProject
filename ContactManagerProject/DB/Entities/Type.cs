using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManagerProject
{
    internal class Type
    {
        public Type(char code, string description)
        {
            Code = code;
            Description = description;
        }

        public char Code { get; set; }
        public string Description { get; set; }
    }
}
