using System;
using System.Collections.Generic;
using System.Text;

namespace HelloWorld.Domain.Models
{
    public  class Location
    {
        public string Id { get; set; } 

        public double[] Coordinates { get; set; }

        public string Description { get; set; }
        public string Image { get; set; }

        public override string ToString()
        {
            return Description;
        }

        public override bool Equals(object obj)
        {
            if(obj is Location location)
            {
                return location.Id == this.Id;
            }
            return base.Equals(obj);
        }
    }
}
