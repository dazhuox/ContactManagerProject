using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManagerProject
{
    internal class ContactImage
    {
        public ContactImage(int id, byte[] image)
        {
            this.id = id;
            Image = image;
        }
        public int id { get; }
        public byte[] Image { get; set; }
    }
}


