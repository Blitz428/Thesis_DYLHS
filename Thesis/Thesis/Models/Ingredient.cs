using System;
using System.Collections.Generic;
using System.Text;

namespace Thesis.Models
{
    public class Ingredient
    {
        public string _Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Created_by { get; set; }
        public enum Type { type1, type2, type3, type4 }
        public double Alcohol { get; set; }
        public int Kcal { get; set; }
        public double Fat { get; set; }
        public double Protein { get; set; }
        public double Carbon { get; set; }
        public bool Verified { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
