using System;
using System.Collections.Generic;
using System.Text;

namespace Thesis.Models
{
    public class Rating
    {
        public int _Id { get; set; }
        public string Created_by { get; set; }
        public string Review { get; set; }
        public int Ratings {  get; set; }
        public DateTime Timestamp { get; set; }

    }
}
