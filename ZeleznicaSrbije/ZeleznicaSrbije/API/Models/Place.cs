using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeleznicaSrbije.API.Models
{
    public class Place
    {
        private int id;
        private string placeName;
        private double x;
        private double y;

        public int Id { get { return id; } set { id = value; } }    
        public double X { get { return x; } set { x = value; } }
        public double Y { get { return y; } set { y = value; } }

        public string PlaceName { get { return placeName; } set { placeName = value; } }

    }
}
