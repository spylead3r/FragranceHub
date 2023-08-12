using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FragranceHub.Data.Models
{
    public class Accords
    {
        [Key]
        public Guid Id { get; set; }

        public int Woody { get; set; }
        public int Citrus { get; set; }
        public int Floral { get; set; }
        public int Spicy { get; set; }
        public int Fruity { get; set; }
        public int Aromatic { get; set; }
        public int Green { get; set; }
        public int Musky { get; set; }
        public int Herbal { get; set; }

    }
}
