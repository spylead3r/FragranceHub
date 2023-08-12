using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FragranceHub.Data.Models
{
    public class FragranceAccords
    {
        public Guid FragranceId { get; set; }
        public Fragrance Fragrance { get; set; } = null!;

        public Guid AccordsId { get; set; }

        public Accords Accords { get; set; } = null!;
    }
}
